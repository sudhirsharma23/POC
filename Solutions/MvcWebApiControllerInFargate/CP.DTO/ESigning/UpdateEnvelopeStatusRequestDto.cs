using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class UpdateEnvelopeStatusRequestDto
    {
        public string EnvelopeId { get; set; }
        public EnvelopeStatus Status { get; set; }
    }
}
