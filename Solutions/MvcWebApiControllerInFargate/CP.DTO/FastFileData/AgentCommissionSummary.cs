using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.FastFileData
{
    public class AgentCommissionSummary
    {
        
        public decimal? BuyerCommissionAmount { get; set; }
        public decimal? BuyerCommissionPercentage { get; set; }
        public decimal? SellerCommissionAmount { get; set; }
        public decimal? SellerCommissionPercentage { get; set; }

    }
}
