using System.Threading.Tasks;

namespace MemcachedRecipes
{
    public interface ICache
    {
        string GetValue(string key);

        Task StoreValueAsync(string key, string value);
    }
}
