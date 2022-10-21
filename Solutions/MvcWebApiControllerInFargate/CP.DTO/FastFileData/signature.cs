using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.FastFileData
{
    public class Signature
    {
        public List<Person> SignerCollection { get; set; }
        public List<Person> DisplayNameCollection { get; set; }
    }
}
