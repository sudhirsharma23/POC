using Amazon.CDK;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.S3.Deployment;
using Constructs;

namespace QuickQuoteCdk
{
    public class QuickQuoteCdkStack : Stack
    {
        public QuickQuoteCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var quickQuoteBucketName = "team-connect-quick-quote-bucket";
            var quickQuoteBucket = new Bucket(this, "CDK-" + quickQuoteBucketName.ToUpper(), new BucketProps
            {
                BucketName = quickQuoteBucketName,
                AccessControl = BucketAccessControl.PRIVATE,
                Versioned = true,
                Encryption = BucketEncryption.S3_MANAGED,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
            });
            Compliance.Tag(quickQuoteBucket);

            var bucketDeployment = new BucketDeployment(this, "CDK" + quickQuoteBucketName.ToUpper() + "-Bucket-Deployment", new BucketDeploymentProps
            {
                DestinationBucket = quickQuoteBucket,
                DestinationKeyPrefix = "quickquotes",
                Sources = new[] { Source.Asset("../../UI") }
            });
            Compliance.Tag(bucketDeployment);
        }
    }
}
