using System;

namespace CP.DTO
{
    public class WorkflowDto
    {
        public int ConsumerFileId { get; set; }
        public ConsumerFileStatus ConsumerFileStatus { get; set; }
        public int ConsumerFileWorkflowId { get; set; }
        public DateTime DateModified { get; set; }
        public string eSignEnvelopeId { get; set; }
        public string eSignInfo { get; set; }
        public string eSignInfoSecondary { get; set; }
        public string IntelledoxVersion { get; set; }
        public string WorkFlowIdentifier { get; set; }
        public string WorkflowProgressId { get; set; }
        public string WorkflowSubmissionId { get; set; }
        public string WorkflowUrl { get; set; }
    }
}
