using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class DocumentRequestDto
    {
        public string Identity { get; set; }
        public int FastFileId { get; set; }
        public string ConsumerFileId { get; set; }
    }

    public class MilestoneStatusDocumentDto
    {
        public string Identity { get; set; }

        public ConsumerFileDto Consumerfile { get; set; }
    }

    public class FastDocumentRequestDto
    {
        public string Identity { get; set; }
        public int FastFileId { get; set; }
        public int FastFileNumber { get; set; }
        public BusinessPartyRole BusinessPartyRole { get; set; }
        public int PrincipalId { get; set; }
        public int FileBusinessPartyId { get; set; }
        public int ConsumerFileId { get; set; }
    }
}
