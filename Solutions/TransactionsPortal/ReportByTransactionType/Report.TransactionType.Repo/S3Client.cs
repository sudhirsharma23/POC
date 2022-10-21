using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using AwsServiceDiscovery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Report.TransactionType.Repo
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class S3Client
    {
        public static async Task SaveFileAsync(byte[] bytes, string filePath)
        {
            //Console.WriteLine("SaveFileAsync");
            //IServiceDiscovery sd = new CloudMapAdapter();
            //ServiceDiscoveryResponse bucketResp = await sd.DiscoverAsync("teamconnect::backend::hit-item-bucket");
            //var bucketName = bucketResp.Rid;
            //ServiceDiscoveryResponse s3VpceResp = await sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect::vpc-endpoints",
            //    new Dictionary<string, string> { { "vpce", "s3" } }));
            //var s3vpceUrl = s3VpceResp.Rid;
            //Console.WriteLine($"bucketName: {bucketName}, s3Vpce: {s3vpceUrl}");
            var bucketName = Environment.GetEnvironmentVariable("HitItem_Bucket_Name");
            var s3vpceUrl = Environment.GetEnvironmentVariable("S3_VPCE_URL");
#if DEBUG
            var roleName = Environment.GetEnvironmentVariable("Programmatic_Role");
            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(roleName, out CredentialProfile basicProfile);
            if (!AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials))
            {
                throw new Exception($"{roleName} failed");
            }
            var s3Client = new AmazonS3Client(awsCredentials, new AmazonS3Config
            {
                ServiceURL = s3vpceUrl,
                AuthenticationRegion = "us-west-2"
            });
#else
            var s3Client = new AmazonS3Client(new AmazonS3Config
            {
                ServiceURL = s3vpceUrl
            });
#endif
            var putReq = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = filePath
            };
            using var ms = new MemoryStream(bytes);
            putReq.InputStream = ms;
            PutObjectResponse putRes = await s3Client.PutObjectAsync(putReq);
            Console.WriteLine("S3 Put Complete");
            if (putRes.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"{filePath} failed: {putRes.HttpStatusCode}, {putRes.ResponseMetadata.RequestId}");
            }
        }
    }
}
