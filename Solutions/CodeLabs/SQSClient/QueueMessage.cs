using System;

namespace QueueService
{
    public class QueueMessage
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Greeting { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
