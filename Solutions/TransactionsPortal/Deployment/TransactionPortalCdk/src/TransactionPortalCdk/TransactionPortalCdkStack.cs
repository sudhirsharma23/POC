using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.IAM;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.Lambda.EventSources;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.SQS;
using Constructs;
using System.Collections.Generic;

namespace TransactionPortalCdk
{
    public class TransactionPortalCdkStack : Stack
    {
        internal TransactionPortalCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var tableName = "ReportItem";
            var dynamoDBTable = new Table(this, "CdkTable", new TableProps
            {
                BillingMode = BillingMode.PAY_PER_REQUEST,
                TableName = tableName,
                PartitionKey = new Attribute
                {
                    Name = "PK",
                    Type = AttributeType.STRING
                }
            });

            var bucketName = "report-hit-item-bucket-3";
            var s3Bucket = new Bucket(this, "Cdk-Report-Hit-Item-Bucket", new BucketProps
            {
                BucketName = bucketName,
                LifecycleRules = new ILifecycleRule[]
                {
                    new LifecycleRule
                    {
                        Expiration = Duration.Days(1)
                    }
                },
                AutoDeleteObjects = true,
                RemovalPolicy = RemovalPolicy.DESTROY
            });

            var lambdaHandlerRole = new Role(this, "Cdk-Lambda-Handler-Role", new RoleProps()
            {
                RoleName = "LambdaHandlerRole",
                Description = "Role assumed by the Lambda Function",
                AssumedBy = new ServicePrincipal("lambda.amazonaws.com"),
            });

            lambdaHandlerRole.AddManagedPolicy(ManagedPolicy.FromAwsManagedPolicyName("CloudWatchFullAccess"));
            lambdaHandlerRole.AddManagedPolicy(ManagedPolicy.FromAwsManagedPolicyName("CloudWatchLambdaInsightsExecutionRolePolicy"));
            var policyStatement = new PolicyStatement();
            policyStatement.AddResources(dynamoDBTable.TableArn);
            policyStatement.AddActions("dynamodb:DescribeTable");
            policyStatement.Effect = Effect.ALLOW;
            policyStatement.Sid = "LambdaTable2022";

            _ = lambdaHandlerRole.AddToPolicy(policyStatement);

            policyStatement = new PolicyStatement();
            policyStatement.AddResources("*");
            policyStatement.AddActions("xray:PutTraceSegments", "xray:PutTelemetryRecords");
            policyStatement.Effect = Effect.ALLOW;
            policyStatement.Sid = "LambdaXRay2022";

            _ = lambdaHandlerRole.AddToPolicy(policyStatement);

            var handler = new Function(this, "Cdk-Tx-Report-Type-Lambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_CORE_3_1,
                Timeout = Duration.Seconds(30),
                Environment = new Dictionary<string, string> {
                    {"Report_Table_Name", tableName },
                    {"Report_Queue_Url", "https://sqs.us-west-2.amazonaws.com/574531325560/report-hit-item-queue"},
                    {"Report_Service_Url", "https://sqs.us-west-2.amazonaws.com" }
                },
                Code = Code.FromAsset("../../ReportByTransactionType/Report.TransactionType.Service.Lambda/bin/Release/netcoreapp3.1/Report.TransactionType.Service.Lambda.zip"),
                Handler = "Report.TransactionType.Service.Lambda::Report.TransactionType.Service.Lambda.Function::FunctionHandler",
                FunctionName = "ReportTransactionType",
                MemorySize = 256,
                Role = lambdaHandlerRole,
                Tracing = Tracing.ACTIVE
            });

            _ = dynamoDBTable.GrantReadWriteData(lambdaHandlerRole);

            var reportHitItemQueueName = "report-hit-item-queue";
            var reportHitItemQueue = new Queue(this, "Cdk-report-hit-item-queue", new QueueProps
            {
                QueueName = reportHitItemQueueName,
                Encryption = QueueEncryption.KMS_MANAGED,
                VisibilityTimeout = Duration.Seconds(30),
                MaxMessageSizeBytes = 262144
            });
            _ = reportHitItemQueue.GrantSendMessages(handler);

            var apiGatewayIntegrationRole = new Role(this, "Cdk-APIGateway-Integration-Role", new RoleProps
            {
                RoleName = "APIGatewayIntegrationRole",
                Description = "Role Assumed by API Gateway",
                AssumedBy = new ServicePrincipal("lambda.amazonaws.com")
            });

            var apiGateway = new RestApi(this, "Cdk-Rest-API", new RestApiProps
            {
                RestApiName = "TransactionReportAPI",
                EndpointConfiguration = new EndpointConfiguration
                {
                    Types = new[] { EndpointType.REGIONAL }
                },
                Deploy = true,
                DeployOptions = new StageOptions
                {
                    StageName = "dev",
                    DataTraceEnabled = true,
                    LoggingLevel = MethodLoggingLevel.INFO,
                    TracingEnabled = true,
                    Variables = new Dictionary<string, string> { { "lambdaAlias", "DEV" } }
                },
                DefaultCorsPreflightOptions = new CorsOptions
                {
                    AllowOrigins = Cors.ALL_ORIGINS,
                    AllowMethods = Cors.ALL_METHODS
                }
            });

            Amazon.CDK.AWS.APIGateway.Resource getTransactionTypeResource = apiGateway.Root.AddResource("transaction-type-report");
            _ = getTransactionTypeResource.AddMethod("GET", new LambdaIntegration(handler));

            _ = handler.GrantInvoke(apiGatewayIntegrationRole);


            var hitItemProcessorHandler = new Function(this, "Cdk-Hit-Item-Processor-Lambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_CORE_3_1,
                Timeout = Duration.Seconds(30),
                Environment = new Dictionary<string, string> {
                    {"Report_Table_Name", tableName },
                    {"Report_Queue_Url", "https://sqs.us-west-2.amazonaws.com/574531325560/report-hit-item-queue"},
                    {"Report_Service_Url", "https://sqs.us-west-2.amazonaws.com" },
                    {"HitItem_Bucket_Name", "report-hit-item-bucket-3" },
                },
                Code = Code.FromAsset("../../ReportByTransactionType/Report.TransactionType.HitItemProcessor.Lambda/bin/Release/netcoreapp3.1/Report.TransactionType.HitItemProcessor.Lambda.zip"),
                Handler = "Report.TransactionType.HitItemProcessor.Lambda::Report.TransactionType.HitItemProcessor.Lambda.HitItemProcessor::ProcessHitItem",
                FunctionName = "HitItemProcessor",
                MemorySize = 256,
                Role = lambdaHandlerRole,
                Tracing = Tracing.ACTIVE
            });

            hitItemProcessorHandler.AddEventSource(new SqsEventSource(reportHitItemQueue));
            _ = reportHitItemQueue.GrantConsumeMessages(hitItemProcessorHandler);
            _ = s3Bucket.GrantReadWrite(hitItemProcessorHandler);

            var hitItemTransporterHandler = new Function(this, "Cdk-Hit-Item-Transporter-Lambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_CORE_3_1,
                Timeout = Duration.Seconds(30),
                Environment = new Dictionary<string, string> {
                    {"Report_Table_Name", tableName },
                    {"Report_Queue_Url", "https://sqs.us-west-2.amazonaws.com/574531325560/report-hit-item-queue"},
                    {"Report_Service_Url", "https://sqs.us-west-2.amazonaws.com" },
                    {"HitItem_Bucket_Name", "report-hit-item-bucket-3" },
                },
                //Code = Code.FromAsset("../../ReportByTransactionType/HitItemTransporter.Lambda/bin/Release/netcoreapp3.1/HitItemTransporter.Lambda.zip"),
                Code = Code.FromAsset(System.Environment.GetEnvironmentVariable("HitItemTransporterLambdazip")),
                Handler = "HitItemTransporter.Lambda::HitItemTransporter.Lambda.HitItemTransporter::TransportHitItem",
                FunctionName = "HitItemTransporter",
                MemorySize = 256,
                Role = lambdaHandlerRole,
                Tracing = Tracing.ACTIVE
            });
            hitItemTransporterHandler.AddEventSource(new S3EventSource(s3Bucket, new S3EventSourceProps
            {
                Events = new[] { EventType.OBJECT_CREATED }
            }));
            _ = s3Bucket.GrantReadWrite(hitItemTransporterHandler);

            CommonValues.Tag(hitItemTransporterHandler);
            CommonValues.Tag(hitItemProcessorHandler);
            CommonValues.Tag(apiGateway);
            CommonValues.Tag(apiGatewayIntegrationRole);
            CommonValues.Tag(reportHitItemQueue);
            CommonValues.Tag(dynamoDBTable);
            CommonValues.Tag(handler);
            CommonValues.Tag(lambdaHandlerRole);
            CommonValues.Tag(s3Bucket);
        }
    }
}
