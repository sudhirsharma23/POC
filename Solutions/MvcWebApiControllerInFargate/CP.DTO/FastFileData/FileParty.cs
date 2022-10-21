using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.FastFileData
{
   public class FileParty
    {
        public string RoleType { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public string Cellular { get; set; }

        public string HomePhone { get; set; }

        public string BusinessPhone { get; set; }
        public string LicenseNumber { get; set; }

        public string SalesRep1Name { get; set; }
        public string SalesRep2Name { get; set; }

        public string CompanyName { get; set; }

        //public string BuyerorSeller { get; set; }
    }
}
