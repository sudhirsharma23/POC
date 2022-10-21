using Amazon.ServiceDiscovery.Model;
using AwsServiceDiscovery;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Report.TransactionType.Service.Fake
{
    public class FakeCloudMapAdapter : IServiceDiscovery
    {
        public async Task<ServiceDiscoveryResponse> DiscoverAsync(ServiceDiscoveryRequest request)
        {
            var jsonData = System.IO.File.ReadAllText($"./DiscoverInstanceResponse_{request.ServiceName}.json");
            DiscoverInstancesResponse serviceResp = await Task.Run(() => JsonConvert.DeserializeObject<DiscoverInstancesResponse>(jsonData));
            return ServiceDiscoveryResponseHelper.FindRid(serviceResp, request);
        }

        public async Task<ServiceDiscoveryResponse> DiscoverAsync(string srn)
        {
            return await DiscoverAsync(new ServiceDiscoveryRequest(srn));
        }

    }
}
