using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Event
{
    public class FailureEventMessageDto: EventMessageDto
    {
        public long FailureEventMessageQueueId { get; set; }
        public int EventHandlerId { get; set; }
    }
}
