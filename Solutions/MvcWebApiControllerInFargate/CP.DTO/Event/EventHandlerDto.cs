using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Event
{
    public class EventHandlerDto
    {
        public int EventHandlerId { get; set; }
        public int EventTypeId { get; set; }
        public string ClassName { get; set; }
        public string AssemblyName { get; set; }
    }
}
