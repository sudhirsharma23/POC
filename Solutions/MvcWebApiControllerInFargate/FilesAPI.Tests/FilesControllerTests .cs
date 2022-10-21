using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using CP.DTO;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace FilesAPI.Tests
{
    public class FilesControllerTests
    {

        [Fact]
        public void TestGetFiles()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/FilesController-GetFiles.json");
            APIGatewayProxyRequest request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            APIGatewayProxyResponse response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            Assert.Contains("62149", response.Body);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);

        }

        [Fact]
        public void TestGetFile()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/FilesController-GetFile.json");
            APIGatewayProxyRequest request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            APIGatewayProxyResponse response = lambdaFunction.FunctionHandlerAsync(request, context).GetAwaiter().GetResult();

            Assert.Equal(200, response.StatusCode);
            ConsumerFileDto fileDto = JsonConvert.DeserializeObject<ConsumerFileDto>(response.Body);
            Assert.True(fileDto.ConsumerFileId > 0);
            Assert.Equal("Feng", fileDto.FirstName);
            Assert.Equal("Men", fileDto.LastName);
            Assert.Equal("QA SANDPOINT REGION", fileDto.FASTRegion);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);

        }

    }
}
