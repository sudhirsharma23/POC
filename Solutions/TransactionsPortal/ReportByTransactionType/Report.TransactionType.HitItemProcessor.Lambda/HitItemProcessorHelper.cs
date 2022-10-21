using Report.TransactionType.Common;
using System;

namespace Report.TransactionType.HitItemProcessor.Lambda
{
    public class HitItemProcessorHelper
    {
        //2020-8-21/CountByTransactionType-557e2776-7e9a-46d6-936c-e6756a449d68.json
        public static string GetItemFileName(ReportItem item)
        {
            return item.DateString + "/" + item.Title.Replace(" ", string.Empty) + "-" + Guid.NewGuid().ToString() + ".json";
        }
    }
}
