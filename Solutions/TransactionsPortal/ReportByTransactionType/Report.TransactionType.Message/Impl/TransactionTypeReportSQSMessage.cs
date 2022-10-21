using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SQS;
using Amazon.SQS.Model;
using AwsServiceDiscovery;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Report.TransactionType.Message.Impl
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class TransactionTypeReportSQSMessage : ITransactionTypeReportMessage
    {
        private AmazonSQSClient client;
        private AWSCredentials AWSCredentials;
        private readonly string queueUrl;
        private readonly string serviceUrl;

        public TransactionTypeReportSQSMessage()
        {
            //var sid = Environment.GetEnvironmentVariable("hit_item_queuue_sid");
            //Console.WriteLine($"sid: {sid}");
            //IServiceDiscovery sd = new CloudMapAdapter();
            //ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest(sid)).GetAwaiter().GetResult();
            //queueUrl = response.Rid;
            //serviceUrl = response.Attributes.FirstOrDefault(a => a.Key.Equals("service-url")).Value;
            queueUrl = Environment.GetEnvironmentVariable("Report_Queue_Url");
            serviceUrl = Environment.GetEnvironmentVariable("Report_Service_Url");

            Console.WriteLine($"queueUrl: {queueUrl}, servicUrl: {serviceUrl}");
            client = GetSQSClient(serviceUrl);
        }

        public AmazonSQSClient GetSQSClient(string serviceUrl)
        {
            var config = new AmazonSQSConfig()
            {
                ServiceURL = serviceUrl
            };
#if DEBUG
            var sharedFile = new SharedCredentialsFile();
            sharedFile.TryGetProfile(Environment.GetEnvironmentVariable("Programmatic_Role"), out CredentialProfile basicProfile);
            AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials);

            client = new AmazonSQSClient(AWSCredentials, config);
#else
            
            client = new AmazonSQSClient(config);

#endif
            return client;
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                await CallSQS(message);
                Console.WriteLine("Completed SQS");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
            }
        }

        private async Task CallSQS(string message)
        {
            var request = new SendMessageRequest
            {
                MessageBody = message,
                QueueUrl = queueUrl
            };

            SendMessageResponse response = await client.SendMessageAsync(request);

            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.Error.WriteLine($"{response.HttpStatusCode}");
            }

        }
    }
}
