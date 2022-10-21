using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace S3Recipes.Tests
{
    [TestClass]
    public class S3ClientTests
    {
        [TestMethod]
        public void CanSaveFileAndGetFile()
        {
            var s3client = new S3Client();
            s3client.SaveFile(System.IO.File.ReadAllBytes("COE.png"), "s3client_test/COE.png", "s3recipes", "TMCT_programmatic");

            var fileBytes = s3client.GetFile("s3client_test/COE.png", "s3recipes", "TMCT_programmatic");

            Assert.IsTrue(fileBytes != null);

            Assert.IsTrue(fileBytes.Length > 0);
        }
    }
}
