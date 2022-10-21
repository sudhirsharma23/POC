using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class DocumentLinkDetail
    {
        public string documentName { get; set; }
        public long? documentId { get; set; }
        public string documentExtension { get; set; }
    }

    public class DocumentLink
    {
        public List<DocumentLinkDetail> documentDetails { get; set; }
        public string comment { get; set; }
    }


}
