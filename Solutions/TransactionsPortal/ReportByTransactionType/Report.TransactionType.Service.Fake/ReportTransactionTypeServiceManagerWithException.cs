using Report.TransactionType.Common;
using System;
using System.Threading.Tasks;

namespace Report.TransactionType.Service.Fake
{
    public class ReportTransactionTypeServiceManagerWithException : IReportTransactionTypeService
    {
        public ReportItem GetCountByTransactionType(DateTime date)
        {
            throw new Exception("Service Error");
        }

        public Task SendMessageAsync(string reportItemsString)
        {
            throw new Exception("Service Error");
        }
    }
}
