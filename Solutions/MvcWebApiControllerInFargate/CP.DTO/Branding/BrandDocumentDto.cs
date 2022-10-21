using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Branding
{
    public class BrandDocumentDto
    {
        public int ConsumerTypeId { get; set; }
        public int ConsumerDocumentMappingId { get; set; }

        public int FASTDocumentTypeAndNameId { get; set; }

        public string DocumentFriendlyNameId { get; set; }
    }
}
