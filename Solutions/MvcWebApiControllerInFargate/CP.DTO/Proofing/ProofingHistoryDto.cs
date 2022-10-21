using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Proofing
{
    public class ProofingHistoryDto
    {
        public int ConsumerFileHistoryId { get; set; }
        public int ConsumerFileId { get; set; }
        public int ConsumerFileStatusId { get; set; }
        public int FastBuyerSellerTypeId { get; set; }
    }
}
