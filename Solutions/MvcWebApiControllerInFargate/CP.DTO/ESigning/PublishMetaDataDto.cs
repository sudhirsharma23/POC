using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class PublishMetaDataDto
    {
        public int ConsumerFileId { get; set; }
        public string FastFileNumber { get; set; }
        public int PrincipalId { get; set; }
        public string Identity { get; set; }
        public ImageMetaDataDto Image { get; set; }
    }

    public class PendingEsignDocs
    {
        public int ConsumerFileId { get; set; }
        public string FastFileNumber { get; set; }
        public Guid? Identity { get; set; }
        public string EnvelopeId { get; set; }
        public ImageStatusType Status { get; set; }
        public ImageType Type { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFriendlyName { get; set; }
        public long DocumentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? EsignedOn { get; set; }
        public long ImageDocumentId { get; set; }
        public bool IsEONotified { get; set; }
        public int PrincipalId { get; set; }
    }

    public class SigningStatus : PublishMetaDataDto
    {
        public string EnvelopeId { get; set; }
        public ImageStatusType Status { get; set; }
    }

    public class DocumentDetails: PendingEsignDocs
    {

    }
}
