using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class IntegratedOrderDto
    {
        public int IntegratedOrderId { get; set; }
        public string Ordersource { get; set; }
        public string EventData { get; set; }
        public int FastEventsDataLogId { get; set; }
        public int EventMessageQueueId { get; set; }
    }
}
