using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
    public class MessageHistoryDto
    {
        /// <summary>
        /// Gets/Sets MessageID GUID
        /// </summary>
        public string MessageID { get; set; }

        /// <summary>
        /// Gets/Sets the subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets/Sets the From
        /// </summary>
        public List<ConsumerInfoDto> From { get; set; }

        /// <summary>
        /// Gets/Sets the Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets/Sets the ReceivedDate
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        public string SenderName { get; set; }

        public int MessageCategory { get; set; }

        public List<ConsumerInfoDto> ToList { get; set; }

        public List<ConsumerInfoDto> CcList { get; set; }
        public int Status { get; set; }
    }
}
