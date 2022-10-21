using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transactions.Service
{
    public class ServiceFactory
    {
        public ServiceProvider serviceProvider;

        public ServiceFactory()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }



        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITransactionsService, TransactionsServiceManagerInMemory>();
        }

        public ITransactionsService GetTransactionsService()
        {
            return serviceProvider.GetService<ITransactionsService>();
        }
    }
}
