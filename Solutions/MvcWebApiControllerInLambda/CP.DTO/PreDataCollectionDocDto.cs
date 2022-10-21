using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class PreDataCollectionDto
    {
        public string ChecklistDocumentName { get; set; }

        public bool IsReAgent { get; set; }
        public List<PreDataCollectionDoc> DataCollectionDocs { get; set; }
    }

    public class PreDataCollectionDoc
    {
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class PreDataCollectionConsumerTypeAndState
    {
        public ConsumerType ConsumerType { get; set; }
        public string State { get; set; }

        public string OfficeDivisionName { get; set; }
    }

}
