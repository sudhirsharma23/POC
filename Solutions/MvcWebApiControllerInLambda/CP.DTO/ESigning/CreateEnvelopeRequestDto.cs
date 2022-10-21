using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class CreateEnvelopeRequestDto
    {
        public IEnumerable<DocumentDto> Documents { get; set; }
        public string EmailSubject { get; set; }
        public IEnumerable<SignerDto> Signers { get; set; }
        public EnvelopeStatus Status { get; set; }
    }
}
