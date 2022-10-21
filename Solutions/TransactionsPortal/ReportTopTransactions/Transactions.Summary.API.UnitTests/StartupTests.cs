using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Transactions.API;
using Transactions.Service;

namespace Transactions.Summary.API.UnitTests
{
    [TestClass]
    public class StartupTests
    {

        [TestMethod]
        public void CanStartup()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var startup = new Startup(config);

            IServiceCollection serviceCollection = new ServiceCollection();

            startup.ConfigureServices(serviceCollection);

            var key = startup.Configuration["AllowedHosts"];

            Assert.AreEqual("*", key);

            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            ITransactionsService txService = provider.GetService<ITransactionsService>();

            Assert.IsNotNull(txService);
            Assert.IsTrue(txService.GetTransactions().Count > 0);

            _ = serviceCollection.AddSingleton<IWebHostEnvironment>();

            var appBuilder = new ApplicationBuilder(provider);
            _ = appBuilder.Build();
            try
            {
                startup.Configure(appBuilder, provider.GetService<IWebHostEnvironment>());
            }
            catch (Exception) { }
        }
    }
}
