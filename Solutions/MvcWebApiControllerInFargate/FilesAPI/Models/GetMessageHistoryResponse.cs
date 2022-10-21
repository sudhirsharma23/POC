using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilesAPI
{
    public class GetMessageHistoryResponse
    {
        public List<MessageHistory> History { get; set; }

        public string ParentMessageId { get; set; }

        public string LatestMasterMessageId { get; set; }

        public int MessageCategory { get; set; }

        public int ConsumerFileId { get; set; }
    }
}