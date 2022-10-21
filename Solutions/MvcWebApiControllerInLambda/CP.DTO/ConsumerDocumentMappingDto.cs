using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumerDocumentMappingDto
    {
        public int ConsumerDocumentMappingId { get; set; }
        public string FriendlyName { get; set; }
        public string FASTDocumentName { get; set; }
        public string FASTDocumentType { get; set; }
        public int? FASTDocumentTypeId { get; set; }
        public int DocumentActionTypeId { get; set; }
        public bool IsCoBrand { get; set; }
        public int FASTDocumentTypeAndNameId { get; set; }
        public int DocumentFriendlyNameId { get; set; }
    }

    public class ReferenceDocumentDto
    {
        public int ReferenceDocId { get; set; }
        public string DisplayName { get; set; }
    }
}
