using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class SignerDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string SignerId { get; set; }
        public bool IsSpouse2 { get; set; }
        public string AdditionalContactId { get; set; }
        public int FastFileId { get; set; }
        public BuyerSellerType BuyerSellerType { get; set; }
        public int PrincipalId { get; set; }
        public int SigningSequece { get; set; }
    }
}
