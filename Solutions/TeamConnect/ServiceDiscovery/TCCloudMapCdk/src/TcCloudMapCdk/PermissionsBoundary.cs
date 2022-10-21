using Amazon.CDK;
using Amazon.JSII.Runtime.Deputy;
using Constructs;

namespace TcCloudMapCdk
{
    public class PermissionsBoundary: DeputyBase, IAspect
    {
        private readonly string PermissionsBoundaryArn;

        public PermissionsBoundary(string arn)
        {
            if (!string.IsNullOrEmpty(arn))
            {
                PermissionsBoundaryArn = arn;
            }
        }

        public void Visit(IConstruct node)
        {
            if (node is Amazon.CDK.AWS.IAM.Role)
            {
                var roleResource = node.Node.FindChild("Resource") as Amazon.CDK.AWS.IAM.CfnRole;
                roleResource.AddPropertyOverride("PermissionsBoundary", PermissionsBoundaryArn);
            }
        }
    }
}
