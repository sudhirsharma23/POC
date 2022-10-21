using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System;
using System.Threading.Tasks;

namespace Report.TransactionType.Repo
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class CloudWatchClient : ICloudWatchClient
    {
        private readonly AmazonCloudWatchClient client;

        public CloudWatchClient()
        {
            client = GetClient();
        }

        public AmazonCloudWatchClient GetClient()
        {
#if DEBUG
            var roleName = Environment.GetEnvironmentVariable("Programmatic_Role");
            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(roleName, out CredentialProfile basicProfile);
            if (!AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials))
            {
                throw new Exception($"{roleName} failed");
            }
            var client = new AmazonCloudWatchClient(awsCredentials, RegionEndpoint.USWest2);
            return client;
#else
            var client  = new AmazonCloudWatchClient();
            return client; 
#endif
        }

        public async Task PutMetricDataAsync(PutMetricDataRequest request)
        {
            _ = await client.PutMetricDataAsync(request);
        }
    }
}
