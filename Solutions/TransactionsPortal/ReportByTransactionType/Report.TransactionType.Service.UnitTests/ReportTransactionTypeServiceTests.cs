using Microsoft.VisualStudio.TestTools.UnitTesting;
using Report.TransactionType.Common;
using Report.TransactionType.Repo;
using Report.TransactionType.Service.Fake;
using Report.TransactionType.Service.Lambda.Tests;
using System;

namespace Report.TransactionType.Service.UnitTests
{
    [TestClass]
    public class ReportTransactionTypeServiceTests
    {
        private static IServiceFactory serviceFactory;
        private static string type;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Environment.SetEnvironmentVariable("Programmatic_Role", TestData.PROGRAMMATIC_ROLE);
            Environment.SetEnvironmentVariable("Report_Queue_Url", "https://sqs.us-west-2.amazonaws.com/638844603513/report-hit-item-queue");
            Environment.SetEnvironmentVariable("Report_Service_Url", "https://sqs.us-west-2.amazonaws.com");


            type = (string)context.Properties["TestType"];

            serviceFactory = type == null || type.Equals("Unit") ? new FakeServiceFactory() : new ServiceFactory();
        }

        [TestMethod]
        public void CanGetCountByTransactionType()
        {

            IReportTransactionTypeService service = serviceFactory.GetReportTransactionTypeService();
            ReportItem reportItem = service.GetCountByTransactionType(DateTime.Parse("August 21, 2020"));
            Assert.IsNotNull(reportItem);
            Assert.AreEqual("Count By Transaction Type", reportItem.Title);

            Assert.IsTrue(reportItem.DataItems.Count > 0);

        }

        [TestMethod]
        public void CanGetDateKey()
        {
            var dateKey = "2020-10-23";

            var key = Helper.GetDateKey(DateTime.Parse("October 23, 2020"));

            Assert.AreEqual(dateKey, key);

            dateKey = "2020-8-21";

            key = Helper.GetDateKey(DateTime.Parse("August 21, 2020"));

            Assert.AreEqual(dateKey, key);
        }

        [TestMethod]
        public void CanGetCountByTransactionTypeInMemory()
        {
            IReportTransactionTypeService inMemoryService = new ReportTransactionTypeServiceManagerInMemory();
            ReportItem item = inMemoryService.GetCountByTransactionType(DateTime.Parse("August 21, 2021"));
            Assert.IsTrue(item != null);
            Assert.IsTrue(item.Title.Equals("Count By Transaction Type"));
            Assert.IsTrue(item.DataItems.Count == 21);
        }

        [TestMethod]
        public void CanGetCountByTransactionTypeInDynamoDB()
        {
            if (type == null || type.Equals("Unit"))
            {
                return;
            }
            IReportTransactionTypeService dbService = new Impl.ReportTranactionTypeServiceManager();
            ReportItem item = dbService.GetCountByTransactionType(DateTime.Parse("August 21, 2021"));
            Assert.IsTrue(item != null);
            Assert.IsTrue(item.Title.Equals("Count By Transaction Type"));
            Assert.IsTrue(item.DataItems.Count == 21);
        }

        [TestMethod]
        public void CanUseDocumentReportItem()
        {
            var item = new DocumentReportItem
            {
                ID = Helper.GetDateKey(DateTime.Now),
                Item = new ReportItem
                {
                    DateString = Helper.GetDateKey(DateTime.Now),
                    Title = "Count By Transaction Type",
                    DataItems = new System.Collections.Generic.List<NumberDataItem> { }
                }
            };

            Assert.IsTrue(item.ID != null);

            item.ID = Helper.GetDateKey(DateTime.Now);
            item.Item = new ReportItem
            {
                DateString = Helper.GetDateKey(DateTime.Now),
                Title = "Count By Transaction Type",
                DataItems = new System.Collections.Generic.List<NumberDataItem> { }
            };

            Assert.IsTrue(item.ID != null);
            Assert.IsTrue(item.Item.Title.Equals("Count By Transaction Type"));
        }

        [TestMethod]
        public void CanSendMessage()
        {

            IReportTransactionTypeService inMemoryService = new ReportTransactionTypeServiceManagerInMemory();
            ReportItem item = inMemoryService.GetCountByTransactionType(DateTime.Parse("August 21, 2021"));
            Assert.IsTrue(item != null);

            IReportTransactionTypeService service = serviceFactory.GetReportTransactionTypeService();
            try
            {
                service.SendMessageAsync(Newtonsoft.Json.JsonConvert.SerializeObject(item)).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [TestMethod]
        public void CanPutMetricDataAsync()
        {
            try
            {
                ICloudWatchClient client = new CloudWatchClientFake();
                _ = client.PutMetricDataAsync(new Amazon.CloudWatch.Model.PutMetricDataRequest());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    }
}
