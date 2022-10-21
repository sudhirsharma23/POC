using CP.DTO.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilesAPI
{
    public class MessageHistory
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
        public List<MessageRecipient> From { get; set; }

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

        public List<MessageRecipient> ToList { get; set; }

        public List<MessageRecipient> CcList { get; set; }

        public string ToNames { get; set; }
        public string CcNames { get; set; }
        public string FromNames { get; set; }
        public int Status { get; set; }
    }
}
