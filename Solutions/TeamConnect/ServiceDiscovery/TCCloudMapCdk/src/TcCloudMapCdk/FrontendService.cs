using Amazon.CDK.AWS.ServiceDiscovery;
using System.Collections.Generic;

namespace TcCloudMapCdk
{
    public class FrontendService
    {
        public static Service ConstructFrontendService(HttpNamespace tcHttpNs)
        {
            Service frontendService = tcHttpNs.CreateService("frontend", new BaseServiceProps
            {
                Name = "frontend",
                Description = "Frontend Services, including URLs of UI applications"
            });
            Compliance.Tag(frontendService);

            _ = frontendService.RegisterNonIpInstance("home", new NonIpInstanceBaseProps
            {
                InstanceId = "home",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "rid", "https://teamconnect.firstam.net/"}
                }
            });

            _ = frontendService.RegisterNonIpInstance("certifications", new NonIpInstanceBaseProps
            {
                InstanceId = "certifications",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "rid", "https://teamconnect.firstam.net/certifications/"}
                }
            });

            _ = frontendService.RegisterNonIpInstance("transactions-reports", new NonIpInstanceBaseProps
            {
                InstanceId = "transactions-reports",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "rid", "https://teamconnect.firstam.net/transactions/"}
                }
            });

            _ = frontendService.RegisterNonIpInstance("checklist", new NonIpInstanceBaseProps
            {
                InstanceId = "checklist",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "rid", "https://teamconnect.firstam.net/checklist/"}
                }
            });

            _ = frontendService.RegisterNonIpInstance("calculators", new NonIpInstanceBaseProps
            {
                InstanceId = "calculators",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "rid", "https://teamconnect.firstam.net/calculators/"}
                }
            });

            return frontendService;
        }
    }
}
