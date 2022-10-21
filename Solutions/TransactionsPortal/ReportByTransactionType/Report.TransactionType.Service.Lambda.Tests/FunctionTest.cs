
using Amazon.KeyManagementService;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Report.TransactionType.Common;
using Report.TransactionType.Repo;
using Report.TransactionType.Service.Fake;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace Report.TransactionType.Service.Lambda.Tests
{
    public class FunctionTest
    {

        public FunctionTest()
        {
            Environment.SetEnvironmentVariable("S3_VPCE_URL", "https://bucket.vpce-02827e4454c491980-wky4t9ss.s3.us-west-2.vpce.amazonaws.com");
            Environment.SetEnvironmentVariable("HitItem_Bucket_Name", "report-hit-item-bucket");
            Environment.SetEnvironmentVariable("CMK_KeyID", "arn:aws:kms:us-west-2:638844603513:alias/teamConnect-kms");
            Environment.SetEnvironmentVariable("Programmatic_Role", "tmct_n1_default_devops");
            Environment.SetEnvironmentVariable("Report_Table_Name", "ReportItems");
            Environment.SetEnvironmentVariable("Report_Queue_Url", "https://sqs.us-west-2.amazonaws.com/638844603513/report-hit-item-queue");
            Environment.SetEnvironmentVariable("Report_Service_Url", "https://sqs.us-west-2.amazonaws.com");

        }

        [Fact]
        public void CanGetCountByTransactionType()
        {
            var function = new Function(new FakeServiceFactory());
            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext
            {
                InvokedFunctionArn = "arn:aws:lambda:us-west-2:638844603513:function:ReportTransactionType"
            };
            APIGatewayProxyResponse response = function.FunctionHandler(request, context).GetAwaiter().GetResult();
            Assert.NotNull(response);
            Assert.NotNull(response.Headers["Access-Control-Allow-Origin"]);
            ReportItem reportItem = JsonConvert.DeserializeObject<ReportItem>(response.Body);
            Assert.Equal("Count By Transaction Type", reportItem.Title);

            Assert.True(reportItem.DataItems.Count == 21);

        }

        [Fact]
        public void CanGetCountByTransactionTypeDefault()
        {
            try
            {
                var function = new Function();
                var request = new APIGatewayProxyRequest();
                var context = new TestLambdaContext()
                {
                    InvokedFunctionArn = "arn:aws:lambda:us-west-2:638844603513:function:ReportTransactionType"
                };
                APIGatewayProxyResponse response = function.FunctionHandler(request, context).GetAwaiter().GetResult();
                Assert.NotNull(response);
                Assert.NotNull(response.Headers["Access-Control-Allow-Origin"]);
                ReportItem reportItem = JsonConvert.DeserializeObject<ReportItem>(response.Body);
                Assert.Equal("Count By Transaction Type", reportItem.Title);

                Assert.True(reportItem.DataItems.Count == 21);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Fact]
        public void CanGetCountByTransactionTypeException()
        {
            var fakeServiceFactory = new FakeServiceFactory();
            ServiceDescriptor descriptor = fakeServiceFactory.services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IReportTransactionTypeService));
            _ = fakeServiceFactory.services.Remove(descriptor);
            _ = fakeServiceFactory.services.AddTransient<IReportTransactionTypeService, ReportTransactionTypeServiceManagerWithException>();
            fakeServiceFactory.serviceProvider = fakeServiceFactory.services.BuildServiceProvider();

            var function = new Function(fakeServiceFactory);
            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext()
            {
                InvokedFunctionArn = "arn:aws:lambda:us-west-2:638844603513:function:ReportTransactionType"
            };
            APIGatewayProxyResponse response = function.FunctionHandler(request, context).GetAwaiter().GetResult();
            Assert.NotNull(response);
            Assert.NotNull(response.Headers["Access-Control-Allow-Origin"]);
            Assert.Equal(response.StatusCode, Convert.ToInt32(HttpStatusCode.InternalServerError));
            Assert.Equal("Service Error", response.Body);
        }

        [Fact]
        public void CanGetCMKKeyFromKMSVpcEndpoint()
        {
#if DEBUG
            var config = new AmazonKeyManagementServiceConfig()
            {
                ServiceURL = "https://vpce-0c40ff3797d66db81-xjyolqfi.kms.us-west-2.vpce.amazonaws.com",
                AuthenticationRegion = "us-west-2"
            };
            var testText = "This is a test";
            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(Environment.GetEnvironmentVariable("Programmatic_Role"), out CredentialProfile basicProfile);
            _ = AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials);
            var client = new AmazonKeyManagementServiceClient(awsCredentials, config);
            var testData = Encoding.ASCII.GetBytes(testText);
            Amazon.KeyManagementService.Model.EncryptResponse response = client.EncryptAsync(new Amazon.KeyManagementService.Model.EncryptRequest
            {
                Plaintext = new MemoryStream(testData),
                KeyId = Environment.GetEnvironmentVariable("CMK_KeyID")
            }).GetAwaiter().GetResult();
            Assert.True(response.HttpStatusCode == HttpStatusCode.OK);
            var encryptedText = Convert.ToBase64String(response.CiphertextBlob.ToArray());
            Assert.NotNull(encryptedText);
            Amazon.KeyManagementService.Model.DecryptResponse decryptResponse = client.DecryptAsync(new Amazon.KeyManagementService.Model.DecryptRequest
            {
                CiphertextBlob = response.CiphertextBlob,
                KeyId = Environment.GetEnvironmentVariable("CMK_KeyID")
            }).GetAwaiter().GetResult();
            using var reader = new StreamReader(decryptResponse.Plaintext);
            var decryptedText = reader.ReadToEnd();
            Assert.Equal(testText, decryptedText);
#else
            
#endif
        }

        [Fact]
        public void CanGetSecretFromSMVpcEndpoint()
        {
#if DEBUG
            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(Environment.GetEnvironmentVariable("Programmatic_Role"), out CredentialProfile basicProfile);
            _ = AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials);
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(awsCredentials, new AmazonSecretsManagerConfig
            {
                ServiceURL = "https://vpce-0cc784d2336616519-z50yjrip.secretsmanager.us-west-2.vpce.amazonaws.com",
                AuthenticationRegion = "us-west-2"
            });

            var request = new GetSecretValueRequest
            {
                SecretId = "dev/teamConnect/api",
                VersionStage = "AWSCURRENT"
            };
            GetSecretValueResponse response = client.GetSecretValueAsync(request).Result;
            Dictionary<string, string> secrets = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.SecretString);

            Assert.Equal("HeyThere", secrets["passCode"]);
#else
            
#endif
        }

        [Fact]
        public void CanGetFileFromS3VpcEndpoint()
        {
#if DEBUG
            var client = new S3Client();
            var content = "This is a test";
            S3Client.SaveFileAsync(Encoding.ASCII.GetBytes(content), "2020-9-31/" + Guid.NewGuid().ToString() + ".txt").GetAwaiter().GetResult();
#else

#endif
        }
    }
}
