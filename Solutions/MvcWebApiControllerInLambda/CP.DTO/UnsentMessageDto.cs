using System;

namespace CP.DTO
{
    public class UnsentMessageDto
    {
        public int EventMessageQueueId { get; set; }
        public int? ConsumerFileId { get; set; }
        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Cc { get; set; }
        public string  MasterMessageId { get; set; }
        public string ParentMessageId { get; set; }
        public string Iv { get; set; }
        public int EventStatusTypeId { get; set; }
        public DateTime SentDate { get; set; }
    }
}
