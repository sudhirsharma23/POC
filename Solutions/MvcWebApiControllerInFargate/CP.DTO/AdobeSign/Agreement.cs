using CP.DTO.WorkflowFinished;
using System.Collections.Generic;

namespace CP.DTO.AdobeSign
{
    public class Agreement
    {
        public string AgreementId { get; set; }
        public string AgreementName { get; set; }
        public List<Document> SignedDocuments { get; set; }
    }
}