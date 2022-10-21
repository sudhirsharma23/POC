using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
   public class MessagesResponseDto
    {
        public List<MessageDto> Messages { get; set; }
        public int TotalMessageCount { get; set; }
        public int TotalUnreadMessages { get; set; }
    }
}
