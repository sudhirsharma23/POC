using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretManagerRecipes;
using System;
using System.Collections.Generic;
using System.Linq;
namespace IDaaSRecipes.Tests
{
    [TestClass]
    public class IDaaSClientTests
    {

        [TestMethod]
        public void CanGetAccessToken()
        {
            var tokenServiceUrl = Environment.GetEnvironmentVariable("TokenServiceUrl");
            var clientID = Environment.GetEnvironmentVariable("ClientID");
            var clientSecret = Environment.GetEnvironmentVariable("ClientSecret");
            var scope = Environment.GetEnvironmentVariable("Scope");
            var client = new IDaaSClient();
            var accessToken = client.GetAccessToken(tokenServiceUrl, clientID, clientSecret, scope);
            Assert.IsNotNull(accessToken);
            Dictionary<string, string> claims = GetClaims(accessToken);
            Assert.IsTrue(claims.Count > 0);
            Assert.AreEqual(clientID, claims["appid"]);
        }

        [TestMethod]
        public void CanGetAccessToken_SM()
        {
            var smClient = new SecretManagerClient();
            var tokenServiceUrl = Environment.GetEnvironmentVariable("TokenServiceUrl");

            var smServiceUrl = Environment.GetEnvironmentVariable("SMServiceUrl");
            var awsRole = Environment.GetEnvironmentVariable("AwsRole");
            var awsRegion = Environment.GetEnvironmentVariable("AwsRegion");
            var secretName = Environment.GetEnvironmentVariable("SecretName");
            Dictionary<string, string> secrets = smClient.GetSecrets(awsRole, smServiceUrl, awsRegion, secretName);

            var clientID = secrets["ClientID"];
            var clientSecret = secrets["ClientSecret"];
            var scope = secrets["Scope"];
            var client = new IDaaSClient();
            var accessToken = client.GetAccessToken(tokenServiceUrl, clientID, clientSecret, scope);
            Assert.IsNotNull(accessToken);
            Dictionary<string, string> claims = GetClaims(accessToken);
            Assert.IsTrue(claims.Count > 0);
            Assert.AreEqual(clientID, claims["appid"]);
        }

        private static Dictionary<string, string> GetClaims(string token)
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims.ToDictionary(c => c.Type, c => c.Value);
            return claims;
        }
    }
}
