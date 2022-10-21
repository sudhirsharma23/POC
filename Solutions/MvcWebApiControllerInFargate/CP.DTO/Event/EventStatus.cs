using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Event
{
    public enum EventStatus
    {
        New = 0,
        Process = 1,
        Success = 2,
        Failed = 3,
        RetryLimitExhausted = 4,
    }
}
