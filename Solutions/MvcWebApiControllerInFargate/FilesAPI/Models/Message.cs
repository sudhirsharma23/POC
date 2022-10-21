using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilesAPI
{
    public class Message
    {
      
        public string Subject { get; set; }

        public string Body { get; set; }

        public long ID { get; set; }

        public string Link { get; set; }

        public bool IsRead { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public string UniqueId { get; set; }
        public string ParentMessageId { get; set; }

        public string LatestMasterMessageId { get; set; }

        public int MessageCategory { get; set; }

        public int ConsumerFileId { get; set; }

        public int LoggedInUserConsumerFileId { get; set; }

        public List<string> ToList { get; set; }

        public List<string> CcList { get; set; }
        public int Status { get; set; }
    }
}
