using Report.TransactionType.Common;
using System;
using System.Threading.Tasks;

namespace Report.TransactionType.Service
{
    public interface IReportTransactionTypeService
    {
        ReportItem GetCountByTransactionType(DateTime date);

        Task SendMessageAsync(string reportItemsString);
    }
}
