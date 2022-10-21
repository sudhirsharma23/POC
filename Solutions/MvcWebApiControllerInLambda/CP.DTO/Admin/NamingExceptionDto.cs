using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Admin
{
    public class NamingExceptionDto
    {
        public int? FileBusinessPartyID { get; set; }
        public string ConsumerfileData { get; set; }
        public bool IsActive { get; set; }
        public string Comments { get; set; }
        public string UnCorrectedName { get; set; }
        public string EooState { get; set; }
    }

    public class NamingExceptionConsumerFileResponse
    {

        public int? FileBusinessPartyID { get; set; }
        public NamingExceptionConsumerFileDto ConsumerfileDto { get; set; }
        public bool IsActive { get; set; }
        public string Comments { get; set; }
        public string UnCorrectedName { get; set; }
        public bool IsNamingException { get; set; }
        public string EooState { get; set; }
    }
}
