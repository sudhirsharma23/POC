using System;
using System.Collections.Generic;
using System.Text;

namespace Transactions.Service
{
    public class Transaction
    {
        public Property Property { get; set; }
        public List<Buyer> Buyers { get; set; }
        public List<Seller> Sellers { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime EstimateCloseDate { get; set; }
    }
}
