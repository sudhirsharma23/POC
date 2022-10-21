using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class WorkflowInfoDto
    {

        public string WorkflowProgressId { get; set; }
        public string WorkflowSubmissionId { get; set; }
        public string WorkFlowIdentifier { get; set; }
        public ConsumerFileStatus ConsumerFileStatusId { get; set; }
        public DateTime DateModified { get; set; }
        public string eSignInfo { get; set; }
        public string eSignInfoSecondary { get; set; }
        public string eSignEnvelopeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ConsumerFileWorkflowId { get; set; }

    }
}
