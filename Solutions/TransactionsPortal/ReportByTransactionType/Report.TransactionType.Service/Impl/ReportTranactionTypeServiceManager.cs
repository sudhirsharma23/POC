using Report.TransactionType.Common;
using Report.TransactionType.Message;
using Report.TransactionType.Message.Impl;
using Report.TransactionType.Repo;
using Report.TransactionType.Repo.Impl;
using System;
using System.Threading.Tasks;

namespace Report.TransactionType.Service.Impl
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class ReportTranactionTypeServiceManager : IReportTransactionTypeService
    {
        public ReportItem GetCountByTransactionType(DateTime date)
        {
            ITransactionTypeReportRepo repo = new TransactionTypeReportDynamoDBRepo();
            var task = Task.Run(() => { return repo.GetReportItemByDateAsync(date); });
            return task.Result;
        }

        public async Task SendMessageAsync(string reportItemsString)
        {
            ITransactionTypeReportMessage message = new TransactionTypeReportSQSMessage();
            await message.SendMessageAsync(reportItemsString);
        }
    }
}
