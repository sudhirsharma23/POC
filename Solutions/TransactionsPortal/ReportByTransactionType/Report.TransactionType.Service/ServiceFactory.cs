using AwsServiceDiscovery;
using Microsoft.Extensions.DependencyInjection;
using Report.TransactionType.Repo;
using Report.TransactionType.Service.Impl;

namespace Report.TransactionType.Service
{
    public class ServiceFactory : IServiceFactory
    {
        public ServiceProvider serviceProvider;

        public ServiceFactory()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddTransient<IReportTransactionTypeService, ReportTranactionTypeServiceManager>();
            _ = services.AddTransient<ICloudWatchClient, CloudWatchClient>();
            _ = services.AddTransient<IServiceDiscovery, CloudMapAdapter>();
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public ICloudWatchClient GetCloudWatchClient()
        {
            return serviceProvider.GetService<ICloudWatchClient>();
        }

        public IReportTransactionTypeService GetReportTransactionTypeService()
        {
            return serviceProvider.GetService<IReportTransactionTypeService>();
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public IServiceDiscovery GetServiceDiscovery()
        {
            return serviceProvider.GetService<IServiceDiscovery>();
        }
    }
}
