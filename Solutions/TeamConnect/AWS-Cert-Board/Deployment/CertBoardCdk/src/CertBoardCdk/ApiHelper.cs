using Amazon.CDK.AWS.APIGateway;
using System.Collections.Generic;

namespace CertBoardCdk
{
    public class ApiHelper
    {
        private const string status_200 = $"{{\"statusCode\":200}}";
        private const string corsOrigin = "https://teamconnect.firstam.net";
        public static void AddMethod(RestApi api, string methodName, string data)
        {
            Resource scrumResource = api.Root.AddResource(methodName);
            _ = scrumResource.AddMethod("GET", new MockIntegration(new IntegrationOptions
            {
                PassthroughBehavior = PassthroughBehavior.WHEN_NO_MATCH,
                RequestTemplates = new Dictionary<string, string> {
                    { "application/json", status_200}
                },
                IntegrationResponses = new IntegrationResponse[] {
                    new IntegrationResponse
                    {
                        StatusCode = "200",
                        ResponseParameters = new Dictionary<string, string>
                        {
                            { "method.response.header.Access-Control-Allow-Origin", $"'{corsOrigin}'"}
                        },
                        ResponseTemplates = new Dictionary<string, string>
                        {
                            { "application/json", data }
                        }
                    }
                }
            }), new MethodOptions
            {
                MethodResponses = new MethodResponse[] {
                    new MethodResponse
                    {
                        StatusCode = "200",
                        ResponseParameters = new Dictionary<string, bool>
                        {
                            { "method.response.header.Access-Control-Allow-Origin", true}
                        },
                        ResponseModels = new Dictionary<string, IModel>
                        {
                            { "application/json", Model.EMPTY_MODEL}
                        }
                    }
                }

            });
        }
    }
}
