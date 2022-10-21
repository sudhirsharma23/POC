using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Proofing
{
    public class QuestionAndChoices
    {
        public QuestionType Type { get; set; }
        public SubCategoryType SubCategory { get; set; }
        public int QuestionId { get; set; }

        public string Question { get; set; }
        public List<Choice> Choices { get; set; }
        public AnswerKeys AnswerKey { get; set; }
    }
}
