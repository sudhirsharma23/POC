using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class OptOutDto
    {
        public int OptOutReasonId { get; set; }
        public string OptOutReason { get; set; }
     
    }

    public class OptOutDtoReason
    {
      
        public string OptOutReason { get; set; }
        public string OtherReason { get; set; }

    }
    public class Feedback
    {
        public string LikeComment { get; set; }
        public string EnhancementComment { get; set; }
        public int Rating { get; set; }
        public string ConsumerFileId { get; set; }
    }
}
