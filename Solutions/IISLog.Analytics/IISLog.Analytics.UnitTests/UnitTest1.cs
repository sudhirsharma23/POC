using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IISLog.Analytics.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var line = "2020-05-15 02:39:19 W3SVC1 10.36.191.103 GET / - 80 - 10.36.190.4 - 200 0 0 1398 7 2 Snavpintfast009";
            var len = line.Split(" ").Length;
            Assert.IsTrue(len != 18);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var date = DateTime.Now.ToString("MM-dd-yyyy");
            Assert.IsTrue(date != null);
        }

    }
}
