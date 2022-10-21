using System;

namespace CP.Core.AdobeSign.Models
{
    public class AdobeSignEventDto
    {
        public string AgreementId { get; set; }
        public int ConsumerFileWorkflowId { get; set; }
        public DateTime CreatedOn { get; set; }
        public AdobeSignEvent Event { get; set; }
    }
}