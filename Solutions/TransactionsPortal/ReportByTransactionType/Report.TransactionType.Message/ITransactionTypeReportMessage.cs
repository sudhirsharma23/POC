using System.Threading.Tasks;

namespace Report.TransactionType.Message
{
    public interface ITransactionTypeReportMessage
    {
        Task SendMessageAsync(string message);
    }
}
