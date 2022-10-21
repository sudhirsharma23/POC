using System.Collections.Generic;

namespace CP.DTO
{
    public class ConsumerFileDocuments
    {
        public string Version { get; set; }
        public List<FastDocumentDto> Documents { get; set; } = new List<FastDocumentDto>();
    }
}
