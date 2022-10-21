using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
   public  class PreGetMessagesResponse
    {
        public bool IsToCallNeeded;
        public bool IsCcCallNeeded;
        public bool IsFromCallNeeded;
    }
}
