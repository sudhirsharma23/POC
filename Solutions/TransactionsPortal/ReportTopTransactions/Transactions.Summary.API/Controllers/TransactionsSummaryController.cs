using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Transactions.Service;
using Transactions.Summary.API.Handlers;
using Transactions.Summary.API.Models;

namespace Transactions.Summary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsSummaryController : ControllerBase
    {
        private readonly ITransactionsService transactionsService;

        public TransactionsSummaryController(ITransactionsService service)
        {
            transactionsService = service;
        }

        [HttpGet]
        public IEnumerable<TransactionSummaryItemDTO> Get()
        {
            List<Transaction> txList = transactionsService.GetTransactions();

            return TransactionSummaryHandler.GetTransactionSummaryItemDTOs(txList);
        }
    }
}
