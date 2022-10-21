using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.IO;
using System.Net;

namespace S3Recipes
{
    public class S3Client : IStorageService
    {

        public void SaveFile(byte[] bytes, string filePath, string bucketName, string roleName)
        {
#if DEBUG
            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(roleName, out CredentialProfile basicProfile);
            if (!AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials))
            {
                throw new Exception($"{roleName} failed");
            }
            var s3Client = new AmazonS3Client(awsCredentials, RegionEndpoint.USWest2);
#else
            var s3Client = new AmazonS3Client();
#endif
            var putReq = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = filePath
            };
            using var ms = new MemoryStream(bytes);
            putReq.InputStream = ms;
            PutObjectResponse putRes = s3Client.PutObjectAsync(putReq).GetAwaiter().GetResult();

            if (putRes.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"{filePath} failed: {putRes.HttpStatusCode}, {putRes.ResponseMetadata.RequestId}");
            }

        }

        public byte[] GetFile(string filePath, string bucketName, string roleName)
        {
#if DEBUG

            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(roleName, out CredentialProfile basicProfile);
            if (!AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials))
            {
                throw new Exception($"{roleName} failed");
            }
            var s3Client = new AmazonS3Client(awsCredentials, RegionEndpoint.USWest2);
#else
            var s3Client = new AmazonS3Client();
#endif
            var getReq = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = filePath
            };
            GetObjectResponse getRes = s3Client.GetObjectAsync(getReq).GetAwaiter().GetResult();
            using var ms = new MemoryStream();
            getRes.ResponseStream.CopyTo(ms);
            return ms.ToArray();
        }

    }
}
