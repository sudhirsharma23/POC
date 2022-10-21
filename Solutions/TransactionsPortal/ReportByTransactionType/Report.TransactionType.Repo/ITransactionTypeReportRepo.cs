using Report.TransactionType.Common;
using System;
using System.Threading.Tasks;

namespace Report.TransactionType.Repo
{
    public interface ITransactionTypeReportRepo
    {
        Task<ReportItem> GetReportItemByDateAsync(DateTime date);
    }
}
