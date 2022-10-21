using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SecretManagerRecipes
{
    public class SecretManagerClient : ISecretService
    {
        public Dictionary<string, string> GetSecrets(string awsRole, string smServiceUrl, string awsRegion, string secretName)
        {
#if DEBUG
            AWSCredentials awsCredentials = GetAWSRoleCredentials(awsRole);
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(awsCredentials, RegionEndpoint.GetBySystemName(awsRegion));
#else
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(new AmazonSecretsManagerConfig { 
                ServiceURL = smServiceUrl,
                AuthenticationRegion = awsRegion
            });
#endif
            try
            {
                var request = new GetSecretValueRequest
                {
                    SecretId = secretName,
                    VersionStage = "AWSCURRENT"
                };
                GetSecretValueResponse response = client.GetSecretValueAsync(request).Result;
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.SecretString);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                throw;
            }
        }

        private static AWSCredentials GetAWSRoleCredentials(string roleName)
        {
            var sharedFile = new SharedCredentialsFile();
            _ = sharedFile.TryGetProfile(roleName, out CredentialProfile basicProfile);
            return !AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, sharedFile, out AWSCredentials awsCredentials)
                ? throw new Exception($"{roleName} failed")
                : awsCredentials;
        }
    }
}
