using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.AWSDocuments
{
    public class AWSDocumentRequest
    {
        public string Duration { get; set; }
        public string FileName { get; set; }
        public string ULID { get; set; }
        public string UserComment { get; set; }
        public string DocMappingId { get; set; }
        public string ContentType { get; set; }
        public double HttpVerb { get; set; }
    }
}
