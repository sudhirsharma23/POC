using System;
using System.Collections.Generic;

namespace Transactions.Service
{
    public interface ITransactionsService
    {
        List<Transaction> GetTransactions();
    }
}
