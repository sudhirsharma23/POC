using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace QueueService
{
    public class SQSClient
    {
        private AmazonSQSClient AmazonSQSClient;

        public SQSClient(string serviceUrl)
        {
            var config = new AmazonSQSConfig()
            {
                ServiceURL = serviceUrl
            };

#if DEBUG
            AWSCredentials AWSCredentials;
            CredentialProfile basicProfile;
            var sharedFile = new SharedCredentialsFile();
            sharedFile.TryGetProfile("ESSC_N_programmatic", out basicProfile);
            AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials);
            AmazonSQSClient = new AmazonSQSClient(AWSCredentials, config);
#else
            AmazonSQSClient = new AmazonSQSClient(config);

#endif
        }

        public SendMessageResponse SendMessage(string queueUrl, string message)
        {
            SendMessageRequest request = new SendMessageRequest
            {
                MessageBody = message,
                QueueUrl = queueUrl
            };

            var response = AmazonSQSClient.SendMessageAsync(request).GetAwaiter().GetResult();

            return response;
        }
    }
}
