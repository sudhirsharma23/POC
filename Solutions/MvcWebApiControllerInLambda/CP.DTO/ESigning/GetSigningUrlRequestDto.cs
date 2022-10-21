using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.ESigning
{
    public class GetSigningUrlRequestDto
    {
        public string AuthenticationMethod { get; set; }
        public string EnvelopeId { get; set; }
        public string ReturnUrl { get; set; }
        public SignerDto Signer { get; set; }
    }
}
