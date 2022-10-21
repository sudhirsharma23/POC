using System.Collections.Generic;

namespace MyAPI
{
    public class AlbumController
    {
        private readonly IBusinessLogic businessLogic;
        private readonly IMemoryCache cache;

        public AlbumController(IBusinessLogic businessLogic, IMemoryCache cache)
        {
            this.businessLogic = businessLogic;
            this.cache = cache; 
        }

        public IEnumerable<string> Get(string artistName)
        {
            return businessLogic.GetAlbums(artistName);
        }

        public string GetNextAlbum(string artistName, string fanName)
        {
            return businessLogic.GetNextAlbum(artistName, fanName);
        }

        public void AddToCache(string key, object value)
        {
            cache.Add(key, value);
        }

        public void RemoveFromCache(string key)
        {
            cache.Remove(key);
        }

        public List<string> CacheKeys()
        {
            return cache.Keys();
        }
    }
}