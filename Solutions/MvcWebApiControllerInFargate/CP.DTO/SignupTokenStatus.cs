using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public enum SignupTokenStatus
    {
        Success = 0,
        Expired,
        Assigned,
        Invalid,
        Eula,
        DeactivatedAndOptOut,
        SpouseConflict,
        FileClosed,
    }
}
