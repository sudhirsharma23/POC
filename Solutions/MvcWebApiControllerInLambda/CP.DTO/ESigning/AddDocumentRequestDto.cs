using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class AddDocumentRequestDto
    {
        public IEnumerable<DocumentDto> Documents { get; set; }
        public string EnvelopeId { get; set; }
        public IEnumerable<SignerDto> Signers { get; set; }
    }
}
