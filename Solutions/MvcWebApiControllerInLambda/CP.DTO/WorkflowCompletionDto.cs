using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class WorkflowCompletionDto
    {

        public string SubmissionId { get; set; }
        public string SummaryDocument { get; set; }
        public virtual IEnumerable<QuestionAnswer> QuestionAnswers { get; set; }
        public bool eSignRequired { get; set; } = true;
    }

    public class QuestionAnswer
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
