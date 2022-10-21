using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemcachedRecipes.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanStoreValue()
        {
            ICache cache = new AWSMemcachedClient();

            var key = "key";
            var value = "this is a test";

            cache.StoreValueAsync(key, value).GetAwaiter().GetResult();

            var cachedValue = cache.GetValue(key);

            Assert.AreEqual(cachedValue, value);
        }

        [TestMethod]
        public void CanSerializeDictionary()
        {
            var dic = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };
            var json = JsonConvert.SerializeObject(dic);

            //"{\"key1\":\"value1\",\"key2\":\"value2\"}"
            Assert.IsNotNull(json);
        }

        [TestMethod]
        public void CanSerializeComplexDictionary()
        {
            var chargeTemplates = new[]
            {
                new {
                    Name = "Proration Charge",
                    ID = 103174
                },
                new
                {
                    Name = "Association Due",
                    ID = 103176
                }
            };

            var dic = new Dictionary<string, string>
            {
                {"HOAChargeTemplates", JsonConvert.SerializeObject(chargeTemplates) }
            };

            var json = JsonConvert.SerializeObject(dic);
            Assert.IsNotNull(json);
        }
    }
}
