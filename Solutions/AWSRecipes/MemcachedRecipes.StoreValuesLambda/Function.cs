
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MemcachedRecipes.StoreValuesLambda
{
    public class Function
    {

        public async Task FunctionHandler(SQSEvent sQSEvent, ILambdaContext context)
        {
            try
            {
                Console.WriteLine($"Beginning to process {sQSEvent.Records.Count} records...");

                foreach (SQSEvent.SQSMessage record in sQSEvent.Records)
                {
                    Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(record.Body);
                    Console.WriteLine($"Deserialized {record.Body}");
                    Console.WriteLine($"keys: {dic.Keys}");
                    Console.WriteLine($"values: {dic.Values}");

                    ICache cache = new AWSMemcachedClient();
                    foreach (KeyValuePair<string, string> kv in dic)
                    {
                        await cache.StoreValueAsync(kv.Key, kv.Value);
                        Console.WriteLine($"Stored key: {kv.Key}, value: {kv.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"MemcachedRecipes.StoreValuesLambda Error: {ex.StackTrace}");
            }
        }
    }

}
