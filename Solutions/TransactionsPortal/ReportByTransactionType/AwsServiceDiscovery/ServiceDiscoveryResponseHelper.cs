using Amazon.ServiceDiscovery.Model;

namespace AwsServiceDiscovery
{
    public class ServiceDiscoveryResponseHelper
    {
        private const string ParamName = "Missing request parameter in FindRid";

        public static ServiceDiscoveryResponse FindRid(DiscoverInstancesResponse serviceResp, ServiceDiscoveryRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(ParamName);
            }
            if (serviceResp == null || serviceResp.Instances == null || serviceResp.Instances.Count == 0)
            {
                throw new Exception($"No service found {request.Namespace}::{request.ServiceName}::{request.Instance}");
            }

            HttpInstanceSummary? instance = string.IsNullOrEmpty(request.Instance) ? serviceResp.Instances.FirstOrDefault() : serviceResp.Instances.FirstOrDefault(inst => inst.InstanceId == request.Instance);

            return instance == null
                ? throw new Exception($"No instance found {request.Instance}")
                : new ServiceDiscoveryResponse(instance.Attributes.FirstOrDefault(attr => attr.Key == "rid").Value, instance.Attributes);
        }
    }
}
