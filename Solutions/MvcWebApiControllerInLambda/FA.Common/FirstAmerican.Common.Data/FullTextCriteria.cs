using System.Collections.Generic;
using System.Text;

namespace FirstAmerican.Common.Data
{
    public class FullTextCriteria
    {
        public string Criteria { get; private set; }
        public List<string> SearchTerms { get; private set; }
        public string SqlCriteria { get; private set; }

        public FullTextCriteria(string criteria)
        {
            ParameterValidator.VerifyStringParameter("criteria", criteria, true, false, null, null);
            this.Criteria = criteria;
            this.SearchTerms = FullTextCriteriaParser.ParseCriteria(criteria);
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = true;
            foreach (string current in this.SearchTerms)
            {
                if (!flag)
                {
                    _ = stringBuilder.Append(" AND ");
                }
                else
                {
                    flag = false;
                }
                _ = stringBuilder.AppendFormat("\"{0}\"", current);
            }
            this.SqlCriteria = stringBuilder.ToString();
        }
    }
}
