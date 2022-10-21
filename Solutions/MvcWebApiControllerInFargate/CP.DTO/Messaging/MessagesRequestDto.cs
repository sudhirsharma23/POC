using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
   public class MessagesRequestDto
    {
        public MessageBoxUserInfoDto UserInfo { get; set; }

        public FileInfoDto FileDto { get; set; }  
        
        public int PageNumber { get; set; }

        public bool GetAllMessages { get; set; }
        
        /// <summary>
        /// This is set when we require history of the messages
        /// </summary>
        public string MessageID { get; set; }

        public bool OnlySummaryData { get; set; }

        public bool GetCCMessages { get; set; }

    }
}
