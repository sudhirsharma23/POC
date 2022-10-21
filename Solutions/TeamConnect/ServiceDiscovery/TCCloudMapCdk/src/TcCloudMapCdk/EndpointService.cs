using Amazon.CDK.AWS.ServiceDiscovery;
using System.Collections.Generic;

namespace TcCloudMapCdk
{
    public class EndpointService
    {
        public static Service ConstructEndpointService(HttpNamespace tcHttpNs)
        {
            Service vpcEndpoints = tcHttpNs.CreateService("vpc-endpoints", new BaseServiceProps
            {
                Name = "vpc-endpoints",
                Description = "VPC Endpoints for S3, API Gateway, and S3"
            });
            Compliance.Tag(vpcEndpoints);

            _ = vpcEndpoints.RegisterNonIpInstance("s3-vpce", new NonIpInstanceBaseProps
            {
                InstanceId = "s3-vpce",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "vpce", "s3"},
                    { "rid", "https://bucket.vpce-02827e4454c491980-wky4t9ss.s3.us-west-2.vpce.amazonaws.com"}
                }
            });
            _ = vpcEndpoints.RegisterNonIpInstance("kms-vpce", new NonIpInstanceBaseProps
            {
                InstanceId = "kms-vpce",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "vpce", "kms"},
                    { "rid", "https://vpce-0c40ff3797d66db81-xjyolqfi.kms.us-west-2.vpce.amazonaws.com"}
                }
            });
            _ = vpcEndpoints.RegisterNonIpInstance("secret-manager-vpce", new NonIpInstanceBaseProps
            {
                InstanceId = "secret-manager-vpce",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "vpce", "sm"},
                    { "rid", "https://vpce-0cc784d2336616519-z50yjrip.secretsmanager.us-west-2.vpce.amazonaws.com"}
                }
            });
            _ = vpcEndpoints.RegisterNonIpInstance("apigateway-vpce", new NonIpInstanceBaseProps
            {
                InstanceId = "apigateway-vpce",

                CustomAttributes = new Dictionary<string, string>
                {
                    { "vpce", "apigateway"},
                    { "rid", "vpce-047b8981391f61dc2"}
                }
            });

            return vpcEndpoints;
        }
    }
}
