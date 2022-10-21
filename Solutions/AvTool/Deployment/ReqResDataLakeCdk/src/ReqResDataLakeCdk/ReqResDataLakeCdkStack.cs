using Amazon.CDK;
using Amazon.CDK.AWS.Glue;
using Amazon.CDK.AWS.IAM;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.S3.Deployment;
using Constructs;
using static Amazon.CDK.AWS.Glue.CfnCrawler;
using static Amazon.CDK.AWS.Glue.CfnDatabase;

namespace ReqResDataLakeCdk
{
    public class ReqResDataLakeCdkStack : Stack
    {
        internal ReqResDataLakeCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var title = "av-req-res";
            var uniqueString = "SF482XHS7M";
            var dataLakeBucketName = $"{title}-data-lake-{uniqueString}-bucket".ToLower();
            var dataLakeBucket = new Bucket(this, "CDK-" + dataLakeBucketName.ToUpper(), new BucketProps
            {
                BucketName = dataLakeBucketName,
                AccessControl = BucketAccessControl.PRIVATE,
                Versioned = true,
                Encryption = BucketEncryption.S3_MANAGED,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
                RemovalPolicy = RemovalPolicy.DESTROY
            });
            Compliance.Tag(dataLakeBucket);

            var bucketDeployment = new BucketDeployment(this, "CDK" + dataLakeBucketName.ToUpper() + "-Bucket-Deployment", new BucketDeploymentProps
            {
                DestinationBucket = dataLakeBucket,
                Sources = new[] { Source.Asset("../../Data") }
            });
            Compliance.Tag(bucketDeployment);

            var athenaQueryResultBucketName = $"{title}-data-lake-{uniqueString}-athena-result-bucket".ToLower();
            var athenaQueryResultBucket = new Bucket(this, "CDK-" + athenaQueryResultBucketName.ToUpper(), new BucketProps
            {
                BucketName = athenaQueryResultBucketName,
                AccessControl = BucketAccessControl.PRIVATE,
                Versioned = true,
                Encryption = BucketEncryption.S3_MANAGED,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
                RemovalPolicy = RemovalPolicy.DESTROY
            });
            Compliance.Tag(athenaQueryResultBucket);

            var roleName = "Av-Glue-Crawler-Role";
            var glueCrawlerRole = new Role(this, $"CDK-{roleName}".ToUpper(), new RoleProps
            {
                RoleName = roleName,
                Description = "AV Glue Crawler Role",
                AssumedBy = new ServicePrincipal("glue.amazonaws.com"),
                ManagedPolicies = new[]
                {
                    ManagedPolicy.FromAwsManagedPolicyName("AmazonS3FullAccess"),
                    ManagedPolicy.FromAwsManagedPolicyName("service-role/AWSGlueServiceRole")
                }

            });
            Compliance.Tag(glueCrawlerRole);

            var databaseName = $"{title}-{uniqueString}-db";
            var glueDatabase = new CfnDatabase(this, $"CDK-{title}-{uniqueString}-db".ToUpper(), new CfnDatabaseProps
            {
                CatalogId = Account,
                DatabaseInput = new DatabaseInputProperty
                {
                    Name = databaseName.ToLower(),
                    Description = databaseName,
                }
            });
            Compliance.Tag(glueDatabase);

            var glueCrawler = new CfnCrawler(this, "CDK-" + dataLakeBucketName.ToUpper() + "-CRAWLER", new CfnCrawlerProps
            {
                Name = $"{title}-{uniqueString}-crawler",
                Role = glueCrawlerRole.RoleArn,
                DatabaseName = databaseName.ToLower(),
                Targets = new TargetsProperty
                {
                    S3Targets = new[]
                  {
                        new S3TargetProperty
                        {
                            Path = $"s3://{dataLakeBucketName}"
                        }
                    }
                }
            });
            Compliance.Tag(glueCrawler);

        }
    }
}
