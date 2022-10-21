using CP.DTO.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class FileStatusNotificationDto
    {
        public System.Guid IdentityId { get; set; }

        public int FastFileId { get; set; }

        public int ConsumerFileId { get; set; }

        public int ConsumerFileStatusId { get; set; }

        public int FASTBuyerSellerTypeId { get; set; }

        public int PrincipalId { get; set; }

        public BuyerSellerType BuyerSellerType => (BuyerSellerType)FASTBuyerSellerTypeId;

        public ConsumerFileStatus Status => (ConsumerFileStatus)ConsumerFileStatusId;

        public string EscrowOfficerName { get; set; }

        public int ConsumerTypeId { get; set; }

        public ConsumerType ConsumerType => (ConsumerType)ConsumerTypeId;
        public int ExistingIdaasUserStatusId { get; set; }
    }
}
