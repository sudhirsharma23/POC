using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumerOffice
    {
        public int OfficeId { get; set; }
        public int RegionId { get; set; }
        public string OfficeName { get; set; }
        public string OfficeCode { get; set; }
        public bool IsActive { get; set; }
        public string State { get; set; }
        public DateTime? OfficeEnabledDate { get; set; }
        public DateTime? NewHomesOfficeEnabledDate { get; set; }
        public bool IsHSD { get; set; }
        public int OfficeDivisionId { get; set; }
        public DateTime? CommercialOfficeEnabledDate { get; set; }
        public DateTime? AgentTCOfficeEnabledDate { get; set; }
        public bool ImportWithNoDelay { get; set; }
    }
}
