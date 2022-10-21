using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
    public class MessageBoxUserInfoDto
    {

        public string UniqueId { get; set; }


        public int Id { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string Identity { get; set; }

        public int ConsumerFileId { get; set; }

        public int loggedInUserConsumerFileId { get; set; }

        public ConsumerType ConsumerType { get; set; }
    }
}
