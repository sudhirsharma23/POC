using Newtonsoft.Json;
using System;

namespace CP.DTO.AdobeSign
{
    public class TrackedAgreementDto
    {
        [JsonIgnore]
        public int AdobeSignAgreementTrackerId { get; set; }

        [JsonProperty(PropertyName = "AgreementId")]
        public string AgreementId { get; set; }

        [JsonProperty(PropertyName = "ConsumerFileWorkflowId")]
        public int CFConsumerTypeStateWorkflowXrefId { get; set; }

        [JsonIgnore]
        public DateTime CreatedOn { get; set; }

        [JsonIgnore]
        public DateTime CompletedOn { get; set; }

        [JsonIgnore]
        public DateTime CancelledOn { get; set; }
    }
}