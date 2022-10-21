using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.S3.Deployment;
using Constructs;
using System.IO;

namespace CertBoardCdk
{
    public class CertBoardCdkStack : Stack
    {
        internal CertBoardCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var certBoardBucketName = "team-connect-certifications-bucket";
            var certBoardBucket = new Bucket(this, "CDK-" + certBoardBucketName.ToUpper(), new BucketProps
            {
                BucketName = certBoardBucketName,
                AccessControl = BucketAccessControl.PRIVATE,
                Versioned = true,
                Encryption = BucketEncryption.S3_MANAGED,
                BlockPublicAccess = BlockPublicAccess.BLOCK_ALL,
            });
            Compliance.Tag(certBoardBucket);

            var bucketDeployment = new BucketDeployment(this, "CDK" + certBoardBucketName.ToUpper() + "-Bucket-Deployment", new BucketDeploymentProps
            {
                DestinationBucket = certBoardBucket,
                DestinationKeyPrefix = "certifications",
                Sources = new[] { Source.Asset("../../UI") }
            });
            Compliance.Tag(bucketDeployment);

            var certRestApi = new RestApi(this, "CDK-" + "certifications-board-api".ToUpper(), new RestApiProps
            {
                RestApiName = "teamconnect-cert-api",
                EndpointConfiguration = new EndpointConfiguration
                {
                    Types = new[] { EndpointType.REGIONAL }
                },
                Deploy = true,
                DeployOptions = new StageOptions
                {
                    StageName = "DEV",
                    DataTraceEnabled = true,
                    LoggingLevel = MethodLoggingLevel.INFO,
                    TracingEnabled = true
                },
                DefaultCorsPreflightOptions = new CorsOptions
                {
                    AllowOrigins = Cors.ALL_ORIGINS,
                    AllowMethods = Cors.ALL_METHODS
                }
            });
            Compliance.Tag(certRestApi);

            var awsData = File.ReadAllText("../../Data/aws-data.json");
            ApiHelper.AddMethod(certRestApi, "aws-certified", awsData);

            var contributorData = File.ReadAllText("../../Data/contributor-data.json");
            ApiHelper.AddMethod(certRestApi, "contributor", contributorData);

            var hashiCorpData = File.ReadAllText("../../Data/hashicorp-data.json");
            ApiHelper.AddMethod(certRestApi, "hashicorp-certified", hashiCorpData);

            var kubernetesData = File.ReadAllText("../../Data/kubernetes-data.json");
            ApiHelper.AddMethod(certRestApi, "kubernetes-certified", kubernetesData);

            var azureData = File.ReadAllText("../../Data/azure-data.json");
            ApiHelper.AddMethod(certRestApi, "azure-certified", azureData);

            var msData = File.ReadAllText("../../Data/ms-data.json");
            ApiHelper.AddMethod(certRestApi, "ms-certified", msData);

            var scrumData = File.ReadAllText("../../Data/scrum-data.json");
            ApiHelper.AddMethod(certRestApi, "scrum-certified", scrumData);

            var itilData = File.ReadAllText("../../Data/itil-data.json");
            ApiHelper.AddMethod(certRestApi, "itil-certified", itilData);
        }
    }
}
