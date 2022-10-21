using System;

namespace Report.TransactionType.Common
{
    public class Helper
    {

        public static string GetDateKey(DateTime date)
        {
            return date.ToString("yyyy-M-dd");
        }
    }
}
