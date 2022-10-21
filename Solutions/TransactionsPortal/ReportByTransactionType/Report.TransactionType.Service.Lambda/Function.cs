using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using Newtonsoft.Json;
using Report.TransactionType.Repo;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Report.TransactionType.Service.Lambda
{
    public class Function
    {
        private readonly IServiceFactory serviceFactory;
        private bool coldStart = true;

        public Function() : this(new ServiceFactory())
        {

        }

        public Function(IServiceFactory serviceFactory)
        {
            AWSSDKHandler.RegisterXRayForAllServices();
            this.serviceFactory = serviceFactory;
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
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
                    Value = "ReportTransactionType"
                };
                var methodDimension = new Dimension
                {
                    Name = "Event Trigger",
                    Value = "APIGateway"
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
                        Namespace = $"Transaction Type Report Service Metrics {alias}"
                    };
                    await client.PutMetricDataAsync(putMetricRequest);
                    coldStart = false;
                }

                IReportTransactionTypeService reportService = serviceFactory.GetReportTransactionTypeService();
                var reportItemsString = JsonConvert.SerializeObject(reportService.GetCountByTransactionType(DateTime.Parse("August 21, 2020")));
                var response = new APIGatewayProxyResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Body = reportItemsString,
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json" },
                        { "Access-Control-Allow-Origin", "*" }
                    }
                };

                var reportsMetric = new MetricDatum
                {
                    MetricName = "ReturnedReportCount",
                    Unit = StandardUnit.Count,
                    Value = 1,
                    Dimensions = new List<Dimension> { lambdaNameDimension, methodDimension }
                };
                var putMetricRequest2 = new PutMetricDataRequest
                {
                    MetricData = new List<MetricDatum> { reportsMetric },
                    Namespace = $"Transaction Type Report Service Metrics {alias}"
                };

                await client.PutMetricDataAsync(putMetricRequest2);

                await reportService.SendMessageAsync(reportItemsString);

                return response;
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.ToString());
                var error = new APIGatewayProxyResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    Body = ex.Message,
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json" },
                        { "Access-Control-Allow-Origin", "*" }
                    }
                };
                return error;
            }
        }
    }
}
