using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Event
{
    public class UploadDocumentEventHandlerRequest
    {
        public string Identity { get; set; }
        public string Comment { get; set; }
        public string DocumentUncPath { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; } 
        public int FASTDocumentTypeId { get; set; } 
        public int ConsumerDocumentMappingID { get; set; }
        public int FileID { get; set; }
        public string FileNumber { get; set; }
    }
}
