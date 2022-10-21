using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Transactions.Service.UnitTests
{
    [TestClass]
    public class TransactionsManagerTests
    {
        [TestMethod]
        public void CanGetTransactions()
        {
            var transactionService = new TransactionsServiceManagerInMemory();

            Assert.IsTrue(transactionService.GetTransactions().Count > 1);
        }

        [TestMethod]
        public void CanGetTransactionsService()
        {
            ServiceFactory serviceFactory = new ServiceFactory();
            ITransactionsService txService = serviceFactory.GetTransactionsService();
            Assert.IsNotNull(txService);
        }
    }
}
