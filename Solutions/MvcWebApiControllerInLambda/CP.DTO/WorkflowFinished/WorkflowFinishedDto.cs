using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CP.DTO.WorkflowFinished
{
    public class WorkflowFinishedDto
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("values")]
        public SignerInfo Values { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }

        [JsonProperty("agreementId")]
        public string AgreementId { get; set; }
    }

    public class Document
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("binary")]
        public string Binary { get; set; }

        [JsonProperty("sha256Hash")]
        public byte[] Sha256Hash { get; set; }
    }

    public class Project
    {
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }

        [JsonProperty("projectGroupGuid")]
        public string ProjectGroupGuid { get; set; }

        [JsonProperty("runId")]
        public string RunId { get; set; }
    }

    public class Sender
    {
        [JsonProperty("userGuid")]
        public string UserGuid { get; set; }
    }

    public class SignerInfo
    {
        [JsonProperty("signer1Name")]
        public string Signer1Name { get; set; }

        [JsonProperty("signer1Email")]
        public string Signer1Email { get; set; }

        [JsonProperty("signer1ClientUserId")]
        public string Signer1ClientUserId { get; set; }

        [JsonProperty("signer2Name")]
        public string Signer2Name { get; set; }

        [JsonProperty("signer2Email")]
        public string Signer2Email { get; set; }

        [JsonProperty("signer2ClientUserId")]
        public string Signer2ClientUserId { get; set; }

        [JsonProperty("envelopeId")]
        public string EnvelopeId { get; set; }

        [JsonProperty("eSignRequired")]
        public bool ESignRequired { get; set; }
    }
}