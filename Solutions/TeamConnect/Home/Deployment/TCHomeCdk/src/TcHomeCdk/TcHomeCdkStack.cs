using Amazon.CDK;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.S3.Deployment;
using Constructs;

namespace TcHomeCdk
{
    public class TcHomeCdkStack : Stack
    {
        internal TcHomeCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {

            var homeTestName = "team-connect-home-test-bucket";
            var homeTestBucket = new Bucket(this, "CDK-" + homeTestName.ToUpper(), new BucketProps
            {
                BucketName = homeTestName,
                AccessControl = BucketAccessControl.PRIVATE,
                Versioned = true,
                Encryption = BucketEncryption.S3_MANAGED,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
            });
            Compliance.Tag(homeTestBucket);

            var tcLandingName = "team-connect-landing-bucket";
            var tcLandingBucket = new Bucket(this, "CDK-" + tcLandingName.ToUpper(), new BucketProps
            {
                BucketName = tcLandingName,
                AccessControl = BucketAccessControl.PRIVATE,
                Versioned = true,
                Encryption = BucketEncryption.S3_MANAGED,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
            });
            Compliance.Tag(tcLandingBucket);

            var bucketDeployment = new BucketDeployment(this, "CDK" + tcLandingName.ToUpper() + "-Bucket-Deployment", new BucketDeploymentProps
            {
                DestinationBucket = tcLandingBucket,
                Sources = new[] { Source.Asset("../../UI") }
            });
            Compliance.Tag(bucketDeployment);
        }
    }
}
