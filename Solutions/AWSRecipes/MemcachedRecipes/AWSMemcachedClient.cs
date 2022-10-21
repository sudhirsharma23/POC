
using Enyim.Caching;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Enyim.Caching.Memcached;

namespace MemcachedRecipes
{
    public class AWSMemcachedClient : ICache
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AWSMemcachedClient));

        private static IServiceProvider serviceProvider;

        public string GetValue(string key)
        {
            MemcachedClient client = GetClient();

            var value = client.Get<string>(key);

            return value;
        }

        public async Task StoreValueAsync(string key, string value)
        {
            try
            {
                MemcachedClient client = GetClient();
                _ = await client.StoreAsync(StoreMode.Set, key, value, DateTime.Now.AddSeconds(3600));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"AWSMemcachedClient.StoreValue() Error: {ex.Message}");
                throw;
            }

        }

        private static MemcachedClient GetClient()
        {
            if (serviceProvider == null)
            {
                try
                {
                    IServiceCollection services = new ServiceCollection();
                    _ = services.AddEnyimMemcached(options =>
                    {
                        var memCachedAddress = Environment.GetEnvironmentVariable("Memcached_Address");
                        var memCachedPort = Environment.GetEnvironmentVariable("Memcached_Port");
                        options.AddServer(memCachedAddress, Convert.ToInt32(memCachedPort));
                        options.Protocol = MemcachedProtocol.Binary;
                    });

                    _ = services.AddLogging(options =>
                    {
                        _ = options.SetMinimumLevel(LogLevel.Information);
                        _ = options.AddConsole();

                    });

                    serviceProvider = services.BuildServiceProvider();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"AWSMemcachedClient.GetClient() Error: {ex.Message}");
                    throw;
                }
            }
            return serviceProvider.GetService<IMemcachedClient>() as MemcachedClient;
        }

        
    }
}
