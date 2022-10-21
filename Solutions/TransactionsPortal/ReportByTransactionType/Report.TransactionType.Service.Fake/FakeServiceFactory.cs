using AwsServiceDiscovery;
using Microsoft.Extensions.DependencyInjection;
using Report.TransactionType.Repo;
using Report.TransactionType.Service.Fake;

namespace Report.TransactionType.Service.Lambda.Tests
{
    public class FakeServiceFactory : IServiceFactory
    {
        public ServiceProvider serviceProvider;
        public IServiceCollection services;

        public FakeServiceFactory()
        {
            services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddTransient<IReportTransactionTypeService, ReportTransactionTypeServiceManagerInMemory>();
            _ = services.AddTransient<ICloudWatchClient, CloudWatchClientFake>();
            _ = services.AddTransient<IServiceDiscovery, FakeCloudMapAdapter>();
        }

        public IReportTransactionTypeService GetReportTransactionTypeService()
        {
            return serviceProvider.GetService<IReportTransactionTypeService>();
        }

        public ICloudWatchClient GetCloudWatchClient()
        {
            return serviceProvider.GetService<ICloudWatchClient>();
        }

        public IServiceDiscovery GetServiceDiscovery()
        {
            return serviceProvider.GetService<IServiceDiscovery>(); 
        }
    }
}
