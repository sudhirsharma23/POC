using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Transactions.API;
using Transactions.Service;

namespace Transactions.Summary.API.UnitTests
{
    [TestClass]
    public class ProgramTests
    {

        [TestMethod]
        public void CanCreateHostBuilder()
        {
            IHostBuilder hostBuilder = Program.CreateHostBuilder(null);
            IHost host = hostBuilder.Build();

            Assert.IsTrue(host.Services.GetService<ITransactionsService>().GetTransactions().Count > 0);
        }

        [TestMethod]
        public void CanInvokeMain()
        {
            var worker = new Thread(RunMain);
            worker.Start();
            if (!worker.Join(new TimeSpan(0, 0, 2)))
            {
                try
                {
                    worker.Abort();
                }
                catch (Exception) { }
            }

        }

        [Ignore]
        public static void RunMain()
        {
            Program.Main(null);

        }
    }
}
