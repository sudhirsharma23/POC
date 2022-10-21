using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
   public class LinkFileDto
    {
        public List<int> ConsumerFiles { get; set; }
        public string Identity { get; set; }
        public bool IsNewUser { get; set; }
        public string ConsumerMessageBoxId { get; set; }
        public bool FetchMessageBoxId { get; set; }
        //getting the value as true in MFA admin when opted out by admin
        public bool UserOptedOut { get; set; }//used --if user is opted out then message has to sent all Agent and Tcs associated for that file
       
        //Below props are for updating message box id as empty to FAST when an REA/TC gets removed.
        public int? FileBusinessPartyID { get; set; }
        public int? ContactID { get; set; }
        public int? IsAdhocContactRegister { get; set; }
        public bool isFileUnlinked { get; set; }
    }
}
