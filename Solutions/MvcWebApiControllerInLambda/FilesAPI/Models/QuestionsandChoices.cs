using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilesAPI
{
    public class QuestionsandChoices
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public Dictionary<int, string> Choices { get; set; }
    }
}