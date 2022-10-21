using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Event
{
    [CollectionDataContract(Name = "Details", ItemName = "DataItem")]
    public class EventDataItemsDto : List<EventDataItemDto>
    {
    }
}
