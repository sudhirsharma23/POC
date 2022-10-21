using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using Report.TopTransactions.Service.Lambda;
using Amazon.Lambda.APIGatewayEvents;
using Transactions.Summary.API.Models;
using Newtonsoft.Json;

namespace Report.TopTransactions.Service.Lambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void CanGetTopTransactions()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();
            APIGatewayProxyResponse response = function.FunctionHandler(request, context);
            Assert.NotNull(response);
            List<TransactionSummaryItemDTO> reportItem = JsonConvert.DeserializeObject<List<TransactionSummaryItemDTO>>(response.Body);
            Assert.True(reportItem.Count > 0);

        }
    }
}
