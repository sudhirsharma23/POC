using NUnit.Framework;
using System;

namespace CodeLabs.Lab3.GreetingRepository.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCreateGreetingDetails()
        {
            var repo = new DynamoDBClient();
            repo.CreateGreetingDetails("FengGreetings", new GreetingDetails
            {
                ID = Guid.NewGuid().ToString(),
                Username = "Feng",
                Greeting = "Hello world, good evening",
                Timestamp = DateTime.Now
            });
            Assert.Pass();
        }

        [Test]
        public void CanGenerateULID()
        {
            var id = Ulid.NewUlid();
            Assert.NotNull(id);

            var uuid = Guid.NewGuid();
            var len = uuid.ToByteArray().Length;

            var s = id.ToByteArray().Length;

            Assert.NotNull(uuid);
        }
    }
}