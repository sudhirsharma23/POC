using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Event
{
    public class EventMessageDto
    {
        public int EventMessageQueueId { get; set; }
        public int EventTypeId { get; set; }
        public string EventData { get; set; }
        public int EventStatusTypeId { get; set; }
        public string EventServer { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ProcessStartDate { get; set; }
        public DateTime? ProcessEndDate { get; set; }
        public string Comments { get; set; }
    }
}
