using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
    public class MessageDto
    {
        public long Id { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public MessageBoxUserInfoDto From { get; set; }

        public bool IsRead { get; set; }

        public bool IsHidden { get; set; }

        public DateTime? SendDate { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public string Link { get; set; }

        public string UniqueId { get; set; }
        public string ParentMessageId { get; set; }

        public string MasterMessageId { get; set; }

        public int MessageCategory { get; set; }
        public List<string> ToList { get; set; }
        public List<string> CcList { get; set; }
        public string InitializationVector { get; set; }
        public int Status { get; set; }
    }
}
