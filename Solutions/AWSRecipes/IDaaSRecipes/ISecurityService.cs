

namespace IDaaSRecipes
{
    public interface ISecurityService
    {
        string GetAccessToken(string tokenServiceUrl, string clientID, string clientSecret, string scope);
    }
}
