using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class ImageMetaDataDto
    {
        public string EnvelopeId { get; set; }
        public ImageStatusType Status { get; set; }
        public ImageType Type { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFriendlyName { get; set; }
        public long  DocumentId { get; set; }
        public long ImageDocumentId { get; set; }
        public bool IsEONotified { get; set; }
    }
}
