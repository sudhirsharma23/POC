using Amazon.CDK;
using Amazon.CDK.AWS.AppSync.Alpha;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.WAFv2;
using Constructs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppSyncCdkStack
{
    public class AppSyncCdkStackStack : Stack
    {
        internal AppSyncCdkStackStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var tableName = "Consumer-File-Table";
            var dynamoDBTable = new Table(this, "Cdk-Consumer-File-Table", new TableProps
            {
                BillingMode = BillingMode.PAY_PER_REQUEST,
                TableName = tableName,
                PartitionKey = new Attribute
                {
                    Name = "consumerFileId",
                    Type = AttributeType.NUMBER
                },
                SortKey = new Attribute
                {
                    Name = "identityId",
                    Type = AttributeType.STRING
                }
            });

            CommonValues.Tag(dynamoDBTable);

            dynamoDBTable.AddGlobalSecondaryIndex(new GlobalSecondaryIndexProps
            {
                IndexName = "IdentityId-Index",
                PartitionKey = new Attribute { Name = "identityId", Type = AttributeType.STRING },
                ProjectionType = ProjectionType.ALL
            });

            var appSyncApi = new GraphqlApi(this, "Cdk-Consumer-File-Api", new GraphqlApiProps
            {
                Name = "Consumer-File-Api",
                Schema = Schema.FromAsset("../Schema/consumer-file.graphql"),
                AuthorizationConfig = new AuthorizationConfig
                {
                    DefaultAuthorization = new AuthorizationMode
                    {
                        AuthorizationType = AuthorizationType.API_KEY,
                        ApiKeyConfig = new ApiKeyConfig
                        {
                            Expires = Expiration.After(Duration.Days(90))
                        }
                    }
                },
                XrayEnabled = true
            });

            CommonValues.Tag(appSyncApi);

            DynamoDbDataSource consumerFileTableDS = appSyncApi.AddDynamoDbDataSource("ConsumerFileTableDS", dynamoDBTable, new DataSourceOptions
            {
                Description = "Consumer File DynamoDB Table Datasource",
                Name = "ConsumerFileTableDS"
            });

            _ = consumerFileTableDS.CreateResolver(new BaseResolverProps
            {
                TypeName = "Query",
                FieldName = "getConsumerFilesByIdentityId",
                RequestMappingTemplate = MappingTemplate.DynamoDbQuery(KeyCondition.Eq("identityId", "IdentityId"), "IdentityId-Index"),
                ResponseMappingTemplate = MappingTemplate.DynamoDbResultList()
            });

            var wafName = "Consumer-File-Api-WebAcl";

            var ipSet = new CfnIPSet(this, "Cdk-Consumer-File-Api-WebACL-IP-Set", new CfnIPSetProps
            {
                Name = wafName,
                Description = "Allowed IP Set",
                IpAddressVersion = "IPV4",
                Addresses = new string[]
                {
                    "65.210.204.255/32",
                    "10.0.0.0/8",
                    "65.210.204.251/32",
                    "65.203.0.0/16",
                    "65.210.204.253/32",
                    "65.210.204.252/32",
                    "65.210.204.254/32"
                },
                Scope = "REGIONAL",
            });

            CommonValues.Tag(ipSet);

            var wafAcl = new CfnWebACL(this, $"Cdk-{wafName}", new CfnWebACLProps
            {
                CustomResponseBodies = new Dictionary<string, CfnWebACL.CustomResponseBodyProperty>
                {
                    {"Custom-Response-1", new CfnWebACL.CustomResponseBodyProperty
                        {
                            ContentType = "APPLICATION_JSON",
                            Content = JsonConvert.SerializeObject(new { message = "Invalid Request (7)"})
                        }
                    }
                },

                DefaultAction = new CfnWebACL.DefaultActionProperty
                {
                    Block = new CfnWebACL.BlockActionProperty()
                    {
                        CustomResponse = new CfnWebACL.CustomResponseProperty
                        {
                            ResponseCode = 404,
                            CustomResponseBodyKey = "Custom-Response-1"
                        }
                    }
                },
                Name = wafName,
                Description = wafName,
                Scope = "REGIONAL",
                VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                {
                    CloudWatchMetricsEnabled = true,
                    MetricName = wafName,
                    SampledRequestsEnabled = true
                },
                Rules = new CfnWebACL.RuleProperty[]
                {
                    new CfnWebACL.RuleProperty
                    {
                        Name = wafName+"-Rule",
                        Action = new CfnWebACL.RuleActionProperty
                        {
                            Allow = new CfnWebACL.AllowActionProperty()
                        },
                        Statement = new CfnWebACL.StatementProperty
                        {
                            IpSetReferenceStatement = new CfnWebACL.IPSetReferenceStatementProperty
                            {
                                Arn = ipSet.AttrArn
                            }
                        },
                        VisibilityConfig = new CfnWebACL.VisibilityConfigProperty
                        {
                            CloudWatchMetricsEnabled = true,
                            MetricName = wafName+"-Rule",
                            SampledRequestsEnabled = true
                        }
                    }
                }
            });

            CommonValues.Tag(wafAcl);

            _ = new CfnWebACLAssociation(this, $"Cdk-{wafName}-Association", new CfnWebACLAssociationProps
            {
                WebAclArn = wafAcl.AttrArn,
                ResourceArn = appSyncApi.Arn
            });
        }
    }
}
