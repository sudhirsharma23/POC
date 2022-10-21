using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
    public class MessageHistoryResponseDto
    {
        public List<MessageHistoryDto> History { get; set; }

        public string ParentMessageId { get; set; }
         
        public string MasterMessageId { get; set; }

        public int MessageCategory { get; set; }
        
        public int ConsumerFileId { get; set; }
    }
}
