using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumerDocumentUploadDto
    {
        public int ConsumerDocumentUploadId { get; set; }
        public int ConsumerFileId { get; set; }
        public int? FASTImageDocumentID { get; set; }
        public string ConsumerDocumentName { get; set; }
        public int ConsumerDocumentMappingId { get; set; }
        public string Comment { get; set; }
        public string TempFileName { get; set; }
        public DateTime CreatedOn  { get; set; }
        public DateTime DeletedDate {get; set;}
    }
}
