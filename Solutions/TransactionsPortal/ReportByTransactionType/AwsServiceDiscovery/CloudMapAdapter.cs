using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;

namespace AwsServiceDiscovery
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class CloudMapAdapter : IServiceDiscovery
    {
        private static AmazonServiceDiscoveryClient? client;

        public CloudMapAdapter()
        {
#if DEBUG
            var roleName = Environment.GetEnvironmentVariable("Programmatic_Role");
            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(roleName, out CredentialProfile basicProfile);
            if (!AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials))
            {
                throw new Exception($"{roleName} failed");
            }
            client = new AmazonServiceDiscoveryClient(awsCredentials);
#else
            client = new AmazonServiceDiscoveryClient();
#endif

        }

        public async Task<ServiceDiscoveryResponse> DiscoverAsync(ServiceDiscoveryRequest request)
        {
            if (client == null)
            {
                throw new Exception("Service Discovery Client is null");
            }
            DiscoverInstancesResponse serviceResp = await client.DiscoverInstancesAsync(new DiscoverInstancesRequest
            {
                HealthStatus = "ALL",
                MaxResults = 10,
                NamespaceName = request.Namespace,
                ServiceName = request.ServiceName,
                QueryParameters = request.queryParameters
            });

            return ServiceDiscoveryResponseHelper.FindRid(serviceResp, request);
        }

        public async Task<ServiceDiscoveryResponse> DiscoverAsync(string srn)
        {
            return await DiscoverAsync(new ServiceDiscoveryRequest(srn));
        }
    }
}
