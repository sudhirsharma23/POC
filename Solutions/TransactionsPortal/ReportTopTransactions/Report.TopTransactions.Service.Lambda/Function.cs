using System;
using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using Transactions.Service;
using Transactions.Summary.API.Handlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Report.TopTransactions.Service.Lambda
{
    public class Function
    {

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CA1822 // Mark members as static
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0060 // Remove unused parameter
        {
            try
            {
                ITransactionsService reportService = new ServiceFactory().GetTransactionsService();
                List<Transaction> txList = reportService.GetTransactions();
                var resp = JsonConvert.SerializeObject(TransactionSummaryHandler.GetTransactionSummaryItemDTOs(txList));
                var response = new APIGatewayProxyResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Body = resp,
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json" },
                        { "Access-Control-Allow-Origin", "*" }
                    }
                };
                Console.WriteLine("New version with layer");
                return response;
            }
            catch (Exception ex)
            {
                context.Logger.LogLine(ex.ToString());
                //var error = new APIGatewayProxyResponse()
                //{
                //    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                //    Body = ex.Message,
                //    Headers = new Dictionary<string, string>
                //    {
                //        {"Content-Type", "application/json" },
                //        { "Access-Control-Allow-Origin", "*" }
                //    }
                //};
                //return error;
                throw;
            }
        }
    }
}
