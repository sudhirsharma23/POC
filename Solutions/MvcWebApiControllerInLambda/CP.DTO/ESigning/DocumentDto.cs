using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class DocumentDto
    {
        public string ContentBase64 { get; set; }
        public string DocumentId { get; set; }
        public string Name { get; set; }
    }
}
