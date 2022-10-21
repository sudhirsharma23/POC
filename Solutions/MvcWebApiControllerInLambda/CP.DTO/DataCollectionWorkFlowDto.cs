using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class DataCollectionWorkFlowDto
    {
        public int DataCollectionWorkFlowID { get; set; }
        public string Name { get; set; }
        public string WorkFlowIdentifier { get; set; }

        public string IntelledoxVersion { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
