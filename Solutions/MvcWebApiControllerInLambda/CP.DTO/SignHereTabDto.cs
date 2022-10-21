using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class SignHereTabDto
    {
        public bool AnchorIgnoreIfNotPresent { get; set; }
        public string AnchorString { get; set; }
        public string RecipientId { get; set; }
    }
}
