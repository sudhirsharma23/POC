using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class PersonalInfoDto
    {
        public int ConsumerFileId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string HomeAddressLine1 { get; set; }
        public string HomeAddressLine2 { get; set; }
        public string HomeAddressLine3 { get; set; }
        public string HomeAddressLine4 { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomeProvince { get; set; }
        public string HomeZip { get; set; }
        public string HomeCountry { get; set; }
        public string HomeCounty { get; set; }
        public string CompanyName { get; set; }
        public string ConsumerPortalNotificationPreferences { get; set; }
        public string PhoneAuthChallenge { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string BusinessPhone { get; set; }
        public string Email { get; set; } // readonly during signup
        public string RegionName { get; set; }
        public string GAB { get; set; }
        public string EscrowOffice { get; set; }
        public string EscrowOfficer { get; set; }
        public string EscrowAssistant { get; set; }
        public string LicenseState { get; set; }
        public string License { get; set; }
        public string IdentityId { get; set; }
        public bool IsEmployeeSignIn { get; set; }
    }
}