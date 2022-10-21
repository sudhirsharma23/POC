using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class UploadDocumentDto
    {
        public int ConsumerFileId { get; set; }
        public string Identity { get; set; }
        public string Comment { get; set; }
        public byte[] Document { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; } // extension e.g. .PDF
        public int? FASTDocumentTypeId { get; set; } // --fast document type 50 - miscellaneous
        public int? ConsumerDocumentMappingID { get; set; }
        public int? FileID { get; set; }
        public string FileNumber { get; set; }
        public int? RequestedDocumentId { get; set; }
        public int? ConsumerDocumentUploadId { get; set; }
        public string EnvelopeId { get; set; }
        public bool SecondaryEsign { get; set; }
        public int? WorkQueueTriggerID { get; set; }
        public long DocumentId { get; set; }
        public string InitializationVector { get; set; }
    }
}
