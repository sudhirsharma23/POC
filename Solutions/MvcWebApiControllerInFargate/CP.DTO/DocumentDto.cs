using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ViewedOn { get; set; }
    }

    public class FastDocumentDto
    {
        public int FastFileId { get; set; }
        public string DocumentName { get; set; }
        public string DocFileExtension { get; set; }
        public string ImageDocumentDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? ImageDocumentID { get; set; }
        public int ImageDocumentVersionID { get; set; }
        public bool IsRead { get; set; }
        public bool IsUploadedDocument { get; set; }
        public int? ConsumerDocumentUploadId { get; set; }
        public int? Status { get; set; }
        public string StatusDescription { get; set; }
        public bool IsSecuredPortalDoc { get; set; }
        public int ConsumerDocumentMappingId { get; set; }
        public bool IsSystemUploadDocument { get; set; }
        public int ConsumerFileId { get; set; }
        public ConsumerType ConsumerType { get; set; }
        public string FastFileNumber { get; set; }
        public string Details { get; set; }
    }

    public class UploadedDocumentsDto
    {
        public int? ConsumerDocumentUploadId { get; set; }
        public long? FASTImageDocumentID { get; set; }
        public string FriendlyName { get; set; }
        public string TempFileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int ConsumerDocumentMappingId { get; set; }
        public string ConsumerDocumentName { get; set; }
        public int ActionTypeId { get; set; }     
    }
}
