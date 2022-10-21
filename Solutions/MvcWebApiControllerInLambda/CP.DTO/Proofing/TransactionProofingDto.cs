using CP.DTO.Proofing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class TransactionProofingDto
    {
        public List<TransactionValue> Values { get; set; }
       
    }
    public class ContactPhone
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
       
    }
}
