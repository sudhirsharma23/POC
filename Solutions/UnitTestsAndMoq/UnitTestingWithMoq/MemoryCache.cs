using System.Collections.Generic;

namespace MyAPI
{
    public interface IMemoryCache
    {
        void Add(string key, object value);
        void Remove(string key);
        List<string> Keys();
    }

    public class MemoryCache : IMemoryCache
    {
        private readonly System.Collections.Specialized.OrderedDictionary _cache = new();

        public void Add(string key, object value)
        {
            _cache.Add(key, value);
        }

        public List<string> Keys()
        {
            var keys = new List<string>();

            foreach (string key in _cache.Keys)
            {
                keys.Add(key);
            }

            return keys;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
