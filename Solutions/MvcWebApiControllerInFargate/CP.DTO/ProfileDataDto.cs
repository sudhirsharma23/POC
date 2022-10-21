using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumerFileInfo
    {
        public List<ProfileDataDto> ProfileInfo { get; set; }
        public string Name { get; set; }
        public ConsumerFileStatus FileStatus { get; set; }
        public SignupTokenStatus tokenStatus { get; set; }
        public string Logo { get; set; }
        public string Header { get; set; }
        public bool IsBrand { get; set; }
    }

    public class ProfileDataDto
    {
        public string PhotoURL { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string BusinessPhone { get; set; }
        public int EmployeeId { get; set; }
        public int DisplayOrder { get; set; }
        public string Email { get; set; }
        public string OfficeAddress { get; set; }
        public Branding.Brand Brand { get; set; }
    }

    public class ProfileDataDto1
    {
        public string PhotoURL { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string BusinessPhone { get; set; }
        public int EmployeeId { get; set; }
        public int DisplayOrder { get; set; }
        public string Email { get; set; }
        public string OfficeAddress { get; set; }
        public string Brand { get; set; }
    }

    public class ProfileDataRequestDto
    {
        public int ConsumerFileId { get; set; }
        public string FileNumber { get; set; }
        public string Identity { get; set; }
        //public int FastFileId { get; set; }
        public int FileBusinessPartyId { get; set; }
    }

    public class AuthenticationConfig
    {
        public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";
        public string Tenant { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Authority
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture, Instance, Tenant);
            }
        }
        public string ProfileScope { get; set; }
        public string EulaScope { get; set; }
    }
}
