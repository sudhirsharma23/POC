using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Proofing
{
    public class TransactionValue
    {
        public QuestionType Type { get; set; }
        public SubCategoryType SubCategory { get; set; }

        public object Value { get; set; }

       
    } 
}
