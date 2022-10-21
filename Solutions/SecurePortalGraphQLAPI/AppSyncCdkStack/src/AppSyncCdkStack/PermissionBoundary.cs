using Amazon.CDK;
using Amazon.JSII.Runtime.Deputy;
using Constructs;


namespace AppSyncCdkStack
{
    public class PermissionBoundary : DeputyBase, IAspect
    {
        private readonly string PermissionsBounaryArn = "arn:aws:iam::638844603513:policy/CAVM/FirstAm-GlobalPermissionsBoundary";

        public PermissionBoundary(string arn)
        {
            if (!string.IsNullOrEmpty(arn))
            {
                PermissionsBounaryArn = arn;
            }
        }

        public void Visit(IConstruct node)
        {
            if (node is Amazon.CDK.AWS.IAM.Role)
            {
                var roleResource = node.Node.FindChild("Resource") as Amazon.CDK.AWS.IAM.CfnRole;
                roleResource.AddPropertyOverride("PermissionsBoundary", PermissionsBounaryArn);
            }
        }
    }
}
