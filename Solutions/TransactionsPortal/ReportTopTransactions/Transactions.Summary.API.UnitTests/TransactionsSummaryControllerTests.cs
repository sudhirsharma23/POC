using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Transactions.Service;
using Transactions.Summary.API.Controllers;

namespace Transactions.Summary.API.UnitTests
{
    [TestClass]
    public class TransactionSummaryControllerTests
    {
        private static TransactionsSummaryController transactionsSummaryController;

        [ClassInitialize]
#pragma warning disable IDE0060 // Remove unused parameter
        public static void Init(TestContext context)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var services = new ServiceCollection();
            _ = services.AddScoped<ITransactionsService, TransactionsServiceManagerInMemory>();
            ServiceProvider serviceBuilder = services.BuildServiceProvider();
            ITransactionsService transactionService = serviceBuilder.GetService<ITransactionsService>();
            transactionsSummaryController = new TransactionsSummaryController(transactionService);
        }

        [TestMethod]
        public void CanGet()
        {
            System.Collections.Generic.IEnumerable<Models.TransactionSummaryItemDTO> txList = transactionsSummaryController.Get();

            Assert.IsTrue(txList.Count() > 1);
        }
    }
}
