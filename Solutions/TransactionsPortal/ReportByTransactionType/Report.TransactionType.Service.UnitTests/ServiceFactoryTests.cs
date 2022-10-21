using Microsoft.VisualStudio.TestTools.UnitTesting;
using Report.TransactionType.Common;
using Report.TransactionType.Repo;
using Report.TransactionType.Service.Fake;
using Report.TransactionType.Service.Lambda.Tests;
using System;

namespace Report.TransactionType.Service.UnitTests
{
    [TestClass]
    public class ServiceFactoryTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Environment.SetEnvironmentVariable("Programmatic_Role", TestData.PROGRAMMATIC_ROLE);
        }

        [TestMethod]
        public void CanGetReportTransactionTypeService()
        {
            IServiceFactory serviceFactory = new ServiceFactory();
            IReportTransactionTypeService service = serviceFactory.GetReportTransactionTypeService();
            Assert.IsNotNull(service);
        }


        [TestMethod]
        public void CanGetCloudWatchClientInFakeService()
        {
            IServiceFactory serviceFactory = new FakeServiceFactory();
            ICloudWatchClient client = serviceFactory.GetCloudWatchClient();
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void CanCreateReportItem()
        {
            var item = new ReportItem
            {
                DataItems = new System.Collections.Generic.List<NumberDataItem>
                {
                    new NumberDataItem("TestName", 123)
                },
                DateString = "Test String",
                Title = "Test Title"
            };
            Assert.IsTrue(item.DataItems.Count > 0);
            Assert.AreEqual(item.DataItems[0].Name, "TestName");
            Assert.AreEqual(item.DataItems[0].Number, 123);
            Assert.AreEqual(item.DateString, "Test String");
            Assert.AreEqual(item.Title, "Test Title");
        }

        [TestMethod]
        public void CanThrowExceptionInFakeService()
        {
            try
            {
                IReportTransactionTypeService exceptionService = new ReportTransactionTypeServiceManagerWithException();
                ReportItem item = exceptionService.GetCountByTransactionType(DateTime.Now);
                Assert.Fail("No Exception from GetCountByTransactionType");
                exceptionService.SendMessageAsync("This is a test").GetAwaiter().GetResult();
                Assert.Fail("No Exception from SendMessageAsync");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Service Error", e.Message);
            }
        }

        [TestMethod]
        public void CanThrowExceptionInFakeService_SendMessageAsync()
        {
            try
            {
                IReportTransactionTypeService exceptionService = new ReportTransactionTypeServiceManagerWithException();
                exceptionService.SendMessageAsync("This is a test").GetAwaiter().GetResult();
                Assert.Fail("No Exception from SendMessageAsync");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Service Error", e.Message);
            }
        }
    }
}
