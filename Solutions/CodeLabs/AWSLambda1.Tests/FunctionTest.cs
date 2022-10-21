
using Amazon.Lambda.TestUtilities;
using Xunit;

namespace AWSLambda1.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var upperCase = function.FunctionHandler(new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest { Body = "hello world" }, context);

            Assert.Contains("FileID", upperCase.Body);
        }
    }
}
