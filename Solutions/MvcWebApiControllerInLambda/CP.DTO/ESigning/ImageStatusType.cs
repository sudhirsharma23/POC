using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public enum ImageStatusType
    {
        Created = 0,
        Sent = 1,
        UnRead = 2,
        Read = 3,
        Completed = 4,
        PublishedToFast = 5,
        Disabled = 6, //added for USER STORY 1959624 - [Prod Bug] EO is not notified on completing secondary eSign, if eSign was disabled for earlier sent document.
        Failed = 7,
        Removed = 8
    }
}
