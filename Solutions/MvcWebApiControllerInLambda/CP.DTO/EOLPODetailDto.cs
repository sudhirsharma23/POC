using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class EOLPODetailDto
    {
        public int EOLPOID { get; set; }
        public string FASTRegion { get; set; }
        public int HomeOfficeBUID { get; set; }
        public string HomeOffice { get; set; }
        public int FastEmpID { get; set; }
        public string EmployeeID { get; set; }
        public string LicenseState { get; set; }
        public int LicenseNumber { get; set; }

        public bool LicenseStatus { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string LPODisplayName { get; set; }

        public string LPONumber { get; set; }
    }
}
