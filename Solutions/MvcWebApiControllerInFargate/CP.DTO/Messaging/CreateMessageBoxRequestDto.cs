using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
    public class CreateMessageBoxRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityToken { get; set; }
        public string EmailAddress { get; set; }
    }
}
