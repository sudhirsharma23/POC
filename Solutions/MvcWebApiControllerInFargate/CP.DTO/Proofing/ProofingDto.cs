using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Proofing
{
    public class ProofingDto
    {
        
        public List<QuestionAndChoices> QuestionsAndChoices { get; set; }
        public int Attempts { get; set; }
        public int ConsumerFileId { get; set; }
        public string ConsumerFirstName { get; set; } //used to Display in header as looged in user
    }
}
