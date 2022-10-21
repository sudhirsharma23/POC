using System.Collections.Generic;

namespace CP.DTO.Messaging
{
    public class SendMessageRequest
    {
        public MessageDto Message { get; set; }

        public FileInfoDto FileDto { get; set; }

        public MessageReceiverType Receiver { get; set; }

        public MessageTransmitterType Transmitter { get; set; }

        public Recipients ReceipientList { get; set; }//used to send detail to fast MessageCenter(MC_1002) only

        public ConsumerType ConsumerType { get; set; }
        public bool SendNotification { get; set; }
    }

    public class TO //used to send detail to fast MessageCenter(MC_1002) only
    {
        public int ConsumerFileId { get; set; }
        public string ConsumerMessageBoxID { get; set; }
        public int ConsumerRoleTypeCdID { get; set; }
        public string IdentityId { get; set; }
    }

    public class CC //used to send detail to fast MessageCenter(MC_1002) only
    {
        public int ConsumerFileId { get; set; }
        public string ConsumerMessageBoxID { get; set; }
        public int ConsumerRoleTypeCdID { get; set; }
        public string IdentityId { get; set; }
    }

    public class Recipients
    {
        public List<TO> ToRecipients { get; set; }
        public List<CC> CCRecipients { get; set; }
    }
}