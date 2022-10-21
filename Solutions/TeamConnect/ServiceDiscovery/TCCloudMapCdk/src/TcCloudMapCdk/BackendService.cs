using Amazon.CDK.AWS.ServiceDiscovery;
using System.Collections.Generic;

namespace TcCloudMapCdk
{
    public class BackendService
    {
        public static Service ConstructBackendService(HttpNamespace tcHttpNs)
        {
            Service backendService = tcHttpNs.CreateService("backend", new BaseServiceProps
            {
                Name = "backend",
                Description = "Backend Services, including API, SQS Queue, S3 bucket"
            });
            Compliance.Tag(backendService);

            _ = backendService.RegisterNonIpInstance("hit-item-bucket", new NonIpInstanceBaseProps
            {
                InstanceId = "hit-item-bucket",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "arn", "arn:aws:s3:::report-hit-item-bucket"},
                    { "rid", "report-hit-item-bucket"}
                }
            });

            _ = backendService.RegisterNonIpInstance("hit-item-queue", new NonIpInstanceBaseProps
            {
                InstanceId = "hit-item-queue",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "arn", "arn:aws:sqs:us-west-2:638844603513:report-hit-item-queue"},
                    { "queue-name", "report-hit-item-queue"},
                    { "rid", "https://sqs.us-west-2.amazonaws.com/638844603513/report-hit-item-queue"},
                    { "service-url", "https://sqs.us-west-2.amazonaws.com"}
                }
            });

            _ = backendService.RegisterNonIpInstance("items-table", new NonIpInstanceBaseProps
            {
                InstanceId = "items-table",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "rid", "big-table"}
                }
            });
            _ = backendService.RegisterNonIpInstance("transation-type-api-dev", new NonIpInstanceBaseProps
            {
                InstanceId = "transation-type-api-dev",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "api-name", "transaction-type-api"},
                    { "stage", "dev"},
                    { "rid", "https://hptp5ggfp4.execute-api.us-west-2.amazonaws.com/TxReport-DEV"}
                }
            });
            _ = backendService.RegisterNonIpInstance("transation-type-api-sb", new NonIpInstanceBaseProps
            {
                InstanceId = "transation-type-api-sb",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "api-name", "transaction-type-api"},
                    { "stage", "sb"},
                    { "rid", "https://hptp5ggfp4.execute-api.us-west-2.amazonaws.com/TxReport-SB"}
                }
            });
            _ = backendService.RegisterNonIpInstance("transaction-type-lambda", new NonIpInstanceBaseProps
            {
                InstanceId = "transaction-type-lambda",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "arn", "arn:aws:lambda:us-west-2:638844603513:function:ReportTransactionType"},
                    { "rid", "ReportTransactionType"}
                }
            });
            _ = backendService.RegisterNonIpInstance("hit-item-transporter-lambda", new NonIpInstanceBaseProps
            {
                InstanceId = "hit-item-transporter-lambda",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "arn", "arn:aws:lambda:us-west-2:638844603513:function:HitItemTransporter"},
                    { "rid", "HitItemTransporter"}
                }
            });
            _ = backendService.RegisterNonIpInstance("hit-item-processor-lambda", new NonIpInstanceBaseProps
            {
                InstanceId = "hit-item-processor-lambda",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "arn", "arn:aws:lambda:us-west-2:638844603513:function:HitItemProcessor"},
                    { "rid", "HitItemProcessor"}
                }
            });

            return backendService;
        }
    }
}
