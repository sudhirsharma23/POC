using AwsServiceDiscovery;
using Report.TransactionType.Repo;

namespace Report.TransactionType.Service
{
    public interface IServiceFactory
    {
        IReportTransactionTypeService GetReportTransactionTypeService();
        ICloudWatchClient GetCloudWatchClient();

        IServiceDiscovery GetServiceDiscovery();

    }
}
