
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.XRay.Recorder.Core;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using Newtonsoft.Json;
using Report.TransactionType.Common;
using Report.TransactionType.Repo;
using Report.TransactionType.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Amazon.Lambda.SQSEvents.SQSEvent;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Report.TransactionType.HitItemProcessor.Lambda
{
    public class HitItemProcessor
    {
        private bool coldStart = true;
        private readonly IServiceFactory serviceFactory;

        public HitItemProcessor() : this(new ServiceFactory())
        {

        }

        public HitItemProcessor(IServiceFactory serviceFactory)
        {
            AWSSDKHandler.RegisterXRayForAllServices();
            this.serviceFactory = serviceFactory;
        }

        public async Task ProcessHitItem(SQSEvent sQSEvent, ILambdaContext context)
        {
            try
            {
                var alias = context?.InvokedFunctionArn[(context.InvokedFunctionArn.LastIndexOf(":") + 1)..];
                if (string.IsNullOrEmpty(alias))
                {
                    alias = string.Empty;
                }

                ICloudWatchClient client = serviceFactory.GetCloudWatchClient();
                var lambdaNameDimension = new Dimension
                {
                    Name = "Lambda Name",
                    Value = "HitItemProcessor"
                };
                var methodDimension = new Dimension
                {
                    Name = "Event Trigger",
                    Value = "SQSEvent"
                };
                if (coldStart)
                {
                    var coldStartMetric = new MetricDatum
                    {
                        MetricName = "ColdStart",
                        Unit = StandardUnit.Count,
                        Value = 1,
                        Dimensions = new List<Dimension> { lambdaNameDimension, methodDimension }
                    };
                    var putMetricRequest = new PutMetricDataRequest
                    {
                        MetricData = new List<MetricDatum> { coldStartMetric },
                        Namespace = $"Hit Item Processor Metrics {alias}"
                    };
                    await client.PutMetricDataAsync(putMetricRequest);
                    coldStart = false;
                }
                foreach (SQSMessage message in sQSEvent.Records)
                {
                    AWSXRayRecorder.Instance.BeginSubsegment("DeserializeObject", DateTime.Now);

                    var body = message.Body;
                    ReportItem item = JsonConvert.DeserializeObject<ReportItem>(body);

                    AWSXRayRecorder.Instance.AddAnnotation("Report-Date", item.DateString);
                    AWSXRayRecorder.Instance.AddMetadata("Report-Data", item.DataItems);
                    AWSXRayRecorder.Instance.EndSubsegment(DateTime.Now);

                    await S3Client.SaveFileAsync(Encoding.ASCII.GetBytes(body), HitItemProcessorHelper.GetItemFileName(item));

                    var itemCountMetric = new MetricDatum
                    {
                        MetricName = "ProcessedItemCount",
                        Unit = StandardUnit.Count,
                        Value = 1,
                        Dimensions = new List<Dimension> { lambdaNameDimension, methodDimension }
                    };
                    var putMetricRequest2 = new PutMetricDataRequest
                    {
                        MetricData = new List<MetricDatum> { itemCountMetric },
                        Namespace = $"Hit Item Processor Metrics {alias}"
                    };
                    await client.PutMetricDataAsync(putMetricRequest2);

                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
                context.Logger.LogLine(e.Message);
            }
        }
    }
}
