using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SecretManagerRecipes.Tests
{
    [TestClass]
    public class SecretManagerClientTests
    {
        [TestMethod]
        public void CanGetSecrets()
        {
            var smServiceUrl = Environment.GetEnvironmentVariable("SMServiceUrl");
            var awsRole = Environment.GetEnvironmentVariable("AwsRole");
            var awsRegion = Environment.GetEnvironmentVariable("AwsRegion");
            var secretName = Environment.GetEnvironmentVariable("SecretName");
            var secretClient = new SecretManagerClient();
            System.Collections.Generic.Dictionary<string, string> secrets = secretClient.GetSecrets(awsRole, smServiceUrl, awsRegion, secretName);

            Assert.IsNotNull(secrets);
            Assert.IsNotNull(secrets["ClientID"]);
            Assert.IsNotNull(secrets["ClientSecret"]);
            Assert.IsNotNull(secrets["Scope"]);
        }
    }
}
