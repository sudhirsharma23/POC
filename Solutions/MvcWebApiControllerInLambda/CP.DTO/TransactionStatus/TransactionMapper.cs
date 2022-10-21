using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.TransactionStatus
{
    public class TransactionMapper
    {
        private Dictionary<ConsumerType, TransactionType> Mapper
        {
            get
            {
                return new Dictionary<ConsumerType, TransactionType>
                {
                    {ConsumerType.Buyer,  TransactionType.PurchaseContractReceived | TransactionType.BuyerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.DocumentsRecorded },
                    {ConsumerType.Seller, TransactionType.PurchaseContractReceived | TransactionType.SellerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.DocumentsRecorded },
                    {ConsumerType.Borrower, TransactionType.OrderReceivedFromLender | TransactionType.BorrowerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.DocumentsRecorded }
                };
            }
        }
        private Dictionary<ConsumerType, TransactionType> MapperForBusinessProgram
        {
            get
            {
                return new Dictionary<ConsumerType, TransactionType>
                {
                    {ConsumerType.Buyer,  TransactionType.PurchaseContractReceived | TransactionType.BuyerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.DocumentsRecorded },
                    {ConsumerType.Seller, TransactionType.PurchaseContractReceived | TransactionType.SellerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.FileClosed },
                    {ConsumerType.Borrower, TransactionType.OrderReceivedFromLender | TransactionType.BorrowerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.DocumentsRecorded }
                };
            }
        }

        private Dictionary<ConsumerType, TransactionType> MapperForStates
        {
            get
            {
                return new Dictionary<ConsumerType, TransactionType>
                {
                    {ConsumerType.Buyer,  TransactionType.PurchaseContractReceived | TransactionType.BuyerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.FileClosed },
                    {ConsumerType.Seller, TransactionType.PurchaseContractReceived | TransactionType.SellerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.DocumentsRecorded },
                    {ConsumerType.Borrower, TransactionType.OrderReceivedFromLender | TransactionType.BorrowerInformationCollected | TransactionType.TitleReviewed | TransactionType.SettlementStatementComplete | TransactionType.DocumentsRecorded }
                };
            }
        }

        public IEnumerable<TransactionType> GetTransactions(ConsumerType consumerType, bool isFileClosedStatusRequired, bool showFileClosedStatusForStates)
        {           
                TransactionType transactions;
                if(showFileClosedStatusForStates)
                {
                    transactions = MapperForStates[consumerType];
                }
                else if (isFileClosedStatusRequired)
                {
                    transactions = MapperForBusinessProgram[consumerType];
                }
                else
                {
                    transactions = Mapper[consumerType];
                }
                var values = Enum.GetValues(transactions.GetType()) as TransactionType[];
                return values?.Where(value => transactions.HasFlag(value)).ToList();
           
        }

    }

    public class AgentTransactionMapper
    {
        private Dictionary<ConsumerType, AgentTransactionType> Mapper
        {
            get
            {
                return new Dictionary<ConsumerType, AgentTransactionType>
                {
                    {ConsumerType.Buyer,  AgentTransactionType.BuyerEmailPhoneCollected | AgentTransactionType.BuyerRegistered | AgentTransactionType.BuyerQAndACompleted| AgentTransactionType.EarnestMoneyDepositReceived  | AgentTransactionType.BuyerFundsReceived | AgentTransactionType.LenderFundsReceived | AgentTransactionType.BuyerCommissionReceived | AgentTransactionType.BuyerTitleReviewed | AgentTransactionType.BuyerDocumentsRecorded },
                    {ConsumerType.Seller, AgentTransactionType.SellerEmailPhoneCollected | AgentTransactionType.SellerRegistered | AgentTransactionType.SellerQAndACompleted | AgentTransactionType.PayoffReceived | AgentTransactionType.SellerCommissionReceived | AgentTransactionType.SellerTitleReviewed | AgentTransactionType.SellerDocumentsRecorded },
                };
            }
        }
        public IEnumerable<AgentTransactionType> GetAgentTransactions(ConsumerType consumerType)
        {
            AgentTransactionType transactions;
            transactions = Mapper[consumerType];
            var values = Enum.GetValues(transactions.GetType()) as AgentTransactionType[];
            return values.Where(value => transactions.HasFlag(value)).ToList();
        }
    }

  }
