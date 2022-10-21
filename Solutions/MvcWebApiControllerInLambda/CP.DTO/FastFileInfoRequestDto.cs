using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class FastFileInfoRequestDto
    {
        public int FileID { get; set; } 
        public int PrincipalID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? FileBusinessPartyID { get; set; }

        public int? ContactId { get; set; }
        public int? IsAdHocContact { get; set; }
        public ConsumerType ConsumerType { get; set; }

        public BuyerSellerType BuyerSellerType { get; set; }
    }
}
