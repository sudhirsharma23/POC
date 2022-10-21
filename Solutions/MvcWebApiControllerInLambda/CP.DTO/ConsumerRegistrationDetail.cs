using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumerRegistrationDetail
    {
        public int ConsumerFileId { get; set; }

        public RegistrationType RegistrationTypeId { get; set; }

        public int LandedToDashBoard { get; set; }
    }
}
