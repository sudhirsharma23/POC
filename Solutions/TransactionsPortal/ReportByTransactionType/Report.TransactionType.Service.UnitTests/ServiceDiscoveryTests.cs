using Amazon.ServiceDiscovery.Model;
using AwsServiceDiscovery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Report.TransactionType.Service.Lambda.Tests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Report.TransactionType.Service.UnitTests
{
    [TestClass]
    public class ServiceDiscoveryTests
    {
        private static IServiceFactory serviceFactory;
        private static string type;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Environment.SetEnvironmentVariable("Programmatic_Role", TestData.PROGRAMMATIC_ROLE);

            type = (string)context.Properties["TestType"];

            serviceFactory = type == null || type.Equals("Unit") ? new FakeServiceFactory() : new ServiceFactory();
        }

        [TestMethod]
        public void CanParseServiceInstance()
        {
            var name = "teamconnect::backend::hit-item-bucket";
            var nameArray = name.Split("::");
            var ns = nameArray[0];
            var service = nameArray[1];
            var instance = nameArray[2];

            Assert.AreEqual("teamconnect", ns);
            Assert.AreEqual("backend", service);
            Assert.AreEqual("hit-item-bucket", instance);
        }

        [TestMethod]
        public void CanDiscoverAwsServiceResource()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect::backend::hit-item-bucket")).GetAwaiter().GetResult();
            var rid = response.Rid;
            Assert.AreEqual("report-hit-item-bucket", rid);
            var arn = response.Attributes.FirstOrDefault(a => a.Key.Equals("arn")).Value;
            Assert.AreEqual("arn:aws:s3:::report-hit-item-bucket", arn);

        }


        [TestMethod]
        public void CanDiscoverAwsServiceResource_Items_Table()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect::backend::items-table")).GetAwaiter().GetResult();
            var rid = response.Rid;
            Assert.AreEqual("big-table", rid);
        }

        [TestMethod]
        public void CanDiscoverAwsServiceResource_With_SRN_String()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            ServiceDiscoveryResponse response = sd.DiscoverAsync("teamconnect::backend::hit-item-bucket").GetAwaiter().GetResult();
            var rid = response.Rid;
            Assert.AreEqual("report-hit-item-bucket", rid);
            var arn = response.Attributes.FirstOrDefault(a => a.Key.Equals("arn")).Value;
            Assert.AreEqual("arn:aws:s3:::report-hit-item-bucket", arn);

        }

        [TestMethod]
        public void CanDiscoverAwsServiceResource_Without_Instance()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect::backend")).GetAwaiter().GetResult();
            var rid = response.Rid;
            Assert.IsNotNull(rid);
        }

        [TestMethod]
        public void CanDiscoverAwsServiceResource_Without_Service()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            try
            {
                ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect")).GetAwaiter().GetResult();
                Assert.Fail("No Exception Thrown");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Service Name is Required", ae.Message);
            }
        }

        [TestMethod]
        public void CanDiscoverAwsServiceResource_Without_Namespace()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            try
            {
                ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("")).GetAwaiter().GetResult();
                Assert.Fail("No Exception Thrown");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Namesapce is Required", ae.Message);
            }
        }

        [TestMethod]
        public void CanDiscoverS3VpcEndpoint()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect::vpc-endpoints", new Dictionary<string, string> { { "vpce", "s3" } })).GetAwaiter().GetResult();
            var rid = response.Rid;
            Assert.AreEqual("https://bucket.vpce-02827e4454c491980-wky4t9ss.s3.us-west-2.vpce.amazonaws.com", rid);
        }

        [TestMethod]
        public void CanDiscoverTxTypeAPI_Dev_Stage()
        {
            IServiceDiscovery sd = serviceFactory.GetServiceDiscovery();
            ServiceDiscoveryResponse response = sd.DiscoverAsync(new ServiceDiscoveryRequest("teamconnect::backend", new Dictionary<string, string> { { "stage", "dev" }, { "api-name", "transaction-type-api" } })).GetAwaiter().GetResult();
            var rid = response.Rid;
            Assert.IsNotNull(rid);
        }

        [TestMethod]
        public void CanFindRid()
        {
            var serviceName = "backend";
            var jsonData = System.IO.File.ReadAllText($"./DiscoverInstanceResponse_{serviceName}.json");
            DiscoverInstancesResponse serviceResp = JsonConvert.DeserializeObject<DiscoverInstancesResponse>(jsonData);
            ServiceDiscoveryResponse discoveryResp = ServiceDiscoveryResponseHelper.FindRid(serviceResp, new ServiceDiscoveryRequest("teamconnect::backend::hit-item-bucket"));
            Assert.AreEqual("report-hit-item-bucket", discoveryResp.Rid);

        }

        [TestMethod]
        public void CanFindRid_With_Null_Response()
        {
            try
            {
                ServiceDiscoveryResponse resp = ServiceDiscoveryResponseHelper.FindRid(null, new ServiceDiscoveryRequest("teamconnect::backend::hit-item-bucket"));
                Assert.Fail("No Exception Thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.ToUpper().Contains("NO SERVICE FOUND"));
            }
        }

        [TestMethod]
        public void CanFindRid_With_Empty_Response()
        {
            try
            {
                ServiceDiscoveryResponse resp = ServiceDiscoveryResponseHelper.FindRid(new DiscoverInstancesResponse { }, new ServiceDiscoveryRequest("teamconnect::backend::hit-item-bucket"));
                Assert.Fail("No Exception Thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.ToUpper().Contains("NO SERVICE FOUND"));
            }
        }

        [TestMethod]
        public void CanFindRid_With_Null_Request()
        {
            try
            {
                ServiceDiscoveryResponse resp = ServiceDiscoveryResponseHelper.FindRid(new DiscoverInstancesResponse { }, null);
                Assert.Fail("No Exception Thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Missing request parameter in FindRid"));
            }
        }


        [TestMethod]
        public void CanFindRid_With_Null_Response_Instance()
        {
            try
            {
                ServiceDiscoveryResponse resp = ServiceDiscoveryResponseHelper.FindRid(new DiscoverInstancesResponse { Instances = null }, new ServiceDiscoveryRequest("teamconnect::backend::hit-item-bucket"));
                Assert.Fail("No Exception Thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.ToUpper().Contains("NO SERVICE FOUND"));
            }
        }

        [TestMethod]
        public void CanFindRid_With_Empty_Response_Instance()
        {
            try
            {
                ServiceDiscoveryResponse resp = ServiceDiscoveryResponseHelper.FindRid(new DiscoverInstancesResponse { Instances = new List<HttpInstanceSummary>() }, new ServiceDiscoveryRequest("teamconnect::backend::hit-item-bucket"));
                Assert.Fail("No Exception Thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.ToUpper().Contains("NO SERVICE FOUND"));
            }
        }

        [TestMethod]
        public void CanFindRid_With_None_Exist_Instance()
        {
            try
            {
                var serviceName = "backend";
                var jsonData = System.IO.File.ReadAllText($"./DiscoverInstanceResponse_{serviceName}.json");
                DiscoverInstancesResponse serviceResp = JsonConvert.DeserializeObject<DiscoverInstancesResponse>(jsonData);
                ServiceDiscoveryResponse discoveryResp = ServiceDiscoveryResponseHelper.FindRid(serviceResp, new ServiceDiscoveryRequest("teamconnect::backend::wrong-bucket"));
                Assert.Fail("No Exception Thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.ToUpper().Contains("NO INSTANCE FOUND"));
            }

        }
    }
}