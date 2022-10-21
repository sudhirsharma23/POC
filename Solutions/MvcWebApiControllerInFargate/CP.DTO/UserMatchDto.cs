using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.UserMatchDto
{
    public class UserMatchRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Phones Phone { get; set; }
    }

    public class Phones
    {
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
    }

    public class UserMatchResponse
    {
        public UserMatchStatus Result { get; set; }
        public string ISMF_MessageBoxId { get; set; }
        public enum UserMatchStatus
        {
            SystemError = -1,
            NoMatch = 0,
            MatchFound = 1,
            PartialMatch = 2,
        }
    }
}