using System.Collections.Generic;

namespace Report.TransactionType.Common
{
    public class ReportItem
    {
        public string DateString { get; set; }
        public string Title { get; set; }
        public List<NumberDataItem> DataItems { get; set; }
    }
}
