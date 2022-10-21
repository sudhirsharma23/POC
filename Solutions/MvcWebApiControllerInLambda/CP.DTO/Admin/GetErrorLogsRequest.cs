using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Admin
{
    [DataContract]
    public class GetErrorLogsRequest
    {
        [DataMember]
        public int rowCountId { get; set; }
        [DataMember]
        public string uniqueId { get; set; }
        [DataMember]
        public string errorMessage { get; set; }
        [DataMember]
        public string exception { get; set; }
        [DataMember]
        public int dateFilterId { get; set; }
        [DataMember]
        public string methodName { get; set; }
        [DataMember]
        public string processName { get; set; }
        [DataMember]
        public string serverName { get; set; }
    }
}
