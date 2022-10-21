using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilesAPI
{
    public class MessagesResponse
    {
        public int UnReadMessageCount { get; set; }

        public int TotalMessages { get; set; }      

        public IEnumerable<Message> Messages { get; set; }

    }
}