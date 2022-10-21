using Amazon.CDK;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using System;

namespace TransactionPortalCdk
{
    public class PermissionsBoundary : DeputyBase, IAspect
    {
        private readonly string PermissionsBounaryArn = "arn:aws:iam::638844603513:policy/CAVM/FirstAm-GlobalPermissionsBoundary";

        public PermissionsBoundary(string arn)
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
