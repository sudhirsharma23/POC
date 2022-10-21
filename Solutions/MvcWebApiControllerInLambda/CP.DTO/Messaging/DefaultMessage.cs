using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
  public class DefaultMessage
    {
        public int TypeID { get; set; }
        public string Body { get; set; }

        public string Subject { get; set; }
    }
}
