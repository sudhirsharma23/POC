using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilesAPI
{
    public class OptOut
    {
        public int OptOutReasonId { get; set; }
        public string OtherReason { get; set; }
        public int ConsumerFileId { get; set; }
        public string OptOutDateTime { get; set; }
        public int OptoutType { get; set; }
    }
}