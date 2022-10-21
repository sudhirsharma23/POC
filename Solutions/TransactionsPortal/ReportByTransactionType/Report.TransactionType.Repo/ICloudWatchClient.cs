using Amazon.CloudWatch.Model;
using System.Threading.Tasks;

namespace Report.TransactionType.Repo
{
    public interface ICloudWatchClient
    {
        Task PutMetricDataAsync(PutMetricDataRequest request);
    }
}
