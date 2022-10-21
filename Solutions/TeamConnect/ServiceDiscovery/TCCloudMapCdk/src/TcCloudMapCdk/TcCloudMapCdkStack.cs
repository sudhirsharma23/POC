using Amazon.CDK;
using Amazon.CDK.AWS.ServiceDiscovery;
using Constructs;

namespace TcCloudMapCdk
{
    public class TcCloudMapCdkStack : Stack
    {
        internal TcCloudMapCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var tcDnsName = "teamconnect";

            var tcHttpNs = new HttpNamespace(this, "CDK-HTTP-" + tcDnsName.ToUpper(), new HttpNamespaceProps
            {
                Name = tcDnsName,
                Description = "Namespace for registering all services and their instances in TeamConnect Web Site"
            });
            Compliance.Tag(tcHttpNs);

            _ = BackendService.ConstructBackendService(tcHttpNs);

            _ = EndpointService.ConstructEndpointService(tcHttpNs);

            _ = FrontendService.ConstructFrontendService(tcHttpNs);

        } 
    }
}
