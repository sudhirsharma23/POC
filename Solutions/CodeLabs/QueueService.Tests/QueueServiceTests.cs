using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace QueueService.Tests
{
    [TestClass]
    public class QueueServiceTests
    {
        [TestMethod]
        public void CanSendMessageToSQS()
        {
            var queueUrl = "https://sqs.us-west-2.amazonaws.com/638844603513/TCGreetingsArchiveQueue";
            var sqsClient = new SQSClient("https://sqs.us-west-2.amazonaws.com");

            Assert.IsTrue(sqsClient != null);

            var greetingMessage = new QueueMessage
            {
                ID = Ulid.NewUlid().ToString(),
                Username = "fmen",
                Greeting = "Hello world, Good Morning",
                Timestamp = DateTime.Now

            };

            var json = JsonConvert.SerializeObject(greetingMessage);

            var response = sqsClient.SendMessage(queueUrl, json);

            Assert.IsTrue(response != null);
            Assert.IsTrue(response.HttpStatusCode == System.Net.HttpStatusCode.OK);

          
        }
    }
}
