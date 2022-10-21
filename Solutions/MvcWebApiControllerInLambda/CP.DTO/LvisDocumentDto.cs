using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class LvisDocumentDto
    {
        public string Name { get; set; }
        public string ULID { get; set; }
        public string UserComment { get; set; }
        public string DocMappingId { get; set; }
        public string FileExtension { get; set; }
        public string EmbeddedContent { get; set; }
        public string S3FileKey { get; set; }
    }
}

