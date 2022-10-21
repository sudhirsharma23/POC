using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
   public  class PreGetMessagesRequest
    {

        public string consumerMessageBoxId;
        public string owingOfficeId;
        public bool isRefresh;
    }
}
