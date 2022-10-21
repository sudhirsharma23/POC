using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class FastFileEventsTriggeredDto
    {
        public int PrincipalId { get; set; }
        public int ConsumerTypeId { get; set; }
        public bool IsPrimary { get; set; }
        public int? ProcessTriggerEventId { get; set; }
        public int? TaskEventId { get; set; }
        public ExternalSystemResponseType ExternalSystemResponseType { get; set; }
        public int? ConsumerId { get; set; }
        public int fastBuyerSellerTypeId { get; set; }
        public string AdditionalContactId { get; set; }
    }
}
