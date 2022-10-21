using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.TransactionStatus
{
    public class RegionMilestoneTask
    {
        public string TaskNameList { get; set; }
        public int RegionId { get; set; }
        public string State { get; set; }
    }

    public class RegionCommissionMilestoneTask
    {
        public string TaskName { get; set; }
        public string ProcessName { get; set; }
    }
}