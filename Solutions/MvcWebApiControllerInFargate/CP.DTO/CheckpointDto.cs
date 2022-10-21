using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class CheckpointDto
    {

        public CheckpointConsumerDto UserConsumerDto { get; set;  }
        public CheckpointConsumerDto SpouseConsumerDto { get; set; }
        
        public bool IsLocked { get; set; }

    }

    public class CheckpointConsumerDto
    {
        public int ConsumerFileId { get; set; }

        public ConsumerFileStatus ConsumerFileStatus { get; set; }

        public BuyerSellerType BuyerSellerType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PrincipalId { get; set; }

        public int FastFileId { get; set; }

        public string State { get; set; }

        public ConsumerType ConsumerType { get; set; }

        public int FASTBusinessSegmentID { get; set; }

        public bool ShowSecondaryESign { get; set; }
        public Guid? IdentityId { get; set; }

        public string AdminFileStatus { get; set; }
        public int? ContactId { get; set; }
        public int? IsAdHocContact { get; set; }
        public int? FileBusinessPartyID { get; set; }
        public string WorkFlowSubmissionID { get; set; }
        public string WorkFlowProgressID { get; set; }
        public string PropertyState { get; set; }       

    }
}
