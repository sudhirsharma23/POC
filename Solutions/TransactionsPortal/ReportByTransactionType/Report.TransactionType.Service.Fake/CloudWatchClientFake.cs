using Amazon.CloudWatch.Model;
using Report.TransactionType.Repo;
using System;
using System.Threading.Tasks;

namespace Report.TransactionType.Service.Fake
{
    public class CloudWatchClientFake : ICloudWatchClient
    {
        public async Task PutMetricDataAsync(PutMetricDataRequest request)
        {
            await Task.Run(() => { Console.WriteLine("This is a unit test"); });
        }
    }
}
