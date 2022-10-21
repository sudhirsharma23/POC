using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IDaaSRecipes
{
    public class IDaaSClient : ISecurityService
    {
        public string GetAccessToken(string tokenServiceUrl, string clientID, string clientSecret, string scope)
        {
            var body = $"grant_type=client_credentials&client_id={clientID}&client_secret={clientSecret}&scope={scope}";
            var httpContent = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

            using var httpHandler = new HttpClientHandler();
            using var client = new HttpClient(httpHandler);
            var res = client.PostAsync(tokenServiceUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
            Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(res);
            return tokenDictionary["access_token"];
        }
    }
}