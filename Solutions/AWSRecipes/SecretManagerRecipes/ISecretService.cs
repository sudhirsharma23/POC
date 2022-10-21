using System;
using System.Collections.Generic;
using System.Text;

namespace SecretManagerRecipes
{
    public interface ISecretService
    {
        Dictionary<string, string> GetSecrets(string awsRole, string smServiceUrl, string awsRegion, string secretName);
    }
}
