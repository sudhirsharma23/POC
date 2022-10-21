using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemcachedRecipes.Tests
{
    public class AWSMemcachedClientFake : ICache
    {
        private static readonly Dictionary<string, string> data = new Dictionary<string, string>
        {
            { "key", "this is a test" },
            { "key1", "value1" },
            { "key2", "value2" },
        };

        public string GetValue(string key)
        {
            return data.GetValueOrDefault(key);
        }

        public async Task StoreValueAsync(string key, string value)
        {
            await Task.Run(() => data.Add(key, value));
        }
    }
}
