using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transactions.Summary.API.Models
{
    public class TransactionSummaryItemDTO
    {
        public string PropertyAddress { get; set; }
        public string State { get; set; }
        public string OpenDate { get; set; }
        public string EstimateCloseDate { get; set; }
        public string Buyer { get; set; }
        public string Seller { get; set; }
    }
}
