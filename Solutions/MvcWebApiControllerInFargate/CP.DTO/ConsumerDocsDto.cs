using System;
using System.Collections.Generic;

namespace CP.DTO
{
    public class ConsumerDocsDto
    {
        public int ConsumerDocumentId { get; set; }
        public int ConsumerFileId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<FastDocumentDto> Documents { get; set; }
        public byte[] Version { get; set; }
        public ConsumerDocsState State { get; set; }
    }

    public enum ConsumerDocsState
    {
        Current,
        Updating
    }
}
