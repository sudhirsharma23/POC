using System.Collections.Generic;
using System.Linq;

namespace MyAPI
{
    public interface IBusinessLogic
    {
        List<string> GetAlbums(string artistName);
        string GetNextAlbum(string artistName, string fanName);
    }

    public class BusinessLogic : IBusinessLogic
    {
        public List<string> GetAlbums(string artistName)
        {
            return new List<string>
            {
                "The Unforgettable Fire",
                "The Joshua Tree"
            };
        }

        public string GetNextAlbum(string artistName, string fanName)
        {
            var albums = GetAlbums(artistName);
            return albums.First();
        }
    }
}
