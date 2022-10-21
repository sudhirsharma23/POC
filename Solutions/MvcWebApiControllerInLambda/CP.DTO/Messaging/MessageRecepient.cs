using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
    public class MessageRecipient
    {
        public int ConsumerFileId { get; set; }
        public string ConsumerName { get; set; }
        public string ToNames { get; set; }
        public string CcNames { get; set; }
        public string FromNames { get; set; }
    }
}
