using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Proofing
{
    public class ProofingQuestion
    {
        public int Id { get; set; }
        public QuestionType Type { get; set; }

        public CategoryType Category { get; set; }

        public SubCategoryType SubCategory { get; set; }

        public string Question { get; set; }

        public bool IsActive { get; set; }
    }
}
