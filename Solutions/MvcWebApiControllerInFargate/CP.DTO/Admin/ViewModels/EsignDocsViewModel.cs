using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Admin.ViewModels
{
    public class EsignDocsViewModel
    {
        public IEnumerable<EsignDoc> EsignDocs { get; set; }
    }

    public class EsignDoc
    {
        public int ConsumerFileId { get; set; }
        public string FastFileNumber { get; set; }
        public Guid? Identity { get; set; }
        public string EnvelopeId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string DocumentName { get; set; }
        public int DocumentId { get; set; }
        public string CreatedOn { get; set; }
        public string EsignedOn { get; set; }
        public string StatusChangeDate { get; set; }
    }
}
