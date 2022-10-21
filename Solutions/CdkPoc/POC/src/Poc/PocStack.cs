using Amazon.CDK;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.S3.Deployment;
using Amazon.CDK.AWS.CloudFront;
using Amazon.CDK.AWS.CloudFront.Origins;
using Constructs;

namespace Poc
{
    public class PocStack : Stack
    {
        private const string RootPath = "/*";

        internal PocStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var bucketName = "tx-portal-demo-web-hosting-bucket";
            var webHostingBucket = new Bucket(this, "TX-PORTAL-DEMO-WebHosting-Bucket", new BucketProps
            {
                BucketName = bucketName,
                AccessControl = BucketAccessControl.PRIVATE,
                Versioned = true,
                Encryption = BucketEncryption.S3_MANAGED,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL
            });

            Compliance.Tag(webHostingBucket);

            var originAccessIdentity = new OriginAccessIdentity(this, "TX-PORTAL-DEMO-Origin-Access-Identity", new OriginAccessIdentityProps
            {
                Comment = "cdk-transaction-portal-demo"
            });
            _ = webHostingBucket.GrantRead(originAccessIdentity);

            var cfDistribution = new Distribution(this, "TX-PORTAL-DEMO-Distribution", new DistributionProps
            {
                DefaultRootObject = "TransactionsSummary.html",
                DefaultBehavior = new BehaviorOptions
                {
                    Origin = new S3Origin(webHostingBucket, new S3OriginProps
                    {
                        OriginAccessIdentity = originAccessIdentity
                    })
                },
                WebAclId = "arn:aws:wafv2:us-east-1:638844603513:global/webacl/tmct-n-1-tmct-dev-web-acl/904d4d3f-549a-4b98-a832-2b3cb0d3666f",
                Enabled = true
            });

            _ = new BucketDeployment(this, "TX-PORTAL-DEMO-WebHosting-Bucket-Deployment", new BucketDeploymentProps
            {
                DestinationBucket = webHostingBucket,
                Sources = new[] { Source.Asset("../../TransactionsPortal/TransactionsSummaryUI") },
                Distribution = cfDistribution,
                DistributionPaths = new[] { RootPath }
            });

            Compliance.Tag(cfDistribution);
        }
    }
}
