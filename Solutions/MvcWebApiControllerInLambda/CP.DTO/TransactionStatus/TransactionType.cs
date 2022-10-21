using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.TransactionStatus
{
    [Flags]
    public enum TransactionType
    {
        [Display(Name = "Order Received From Lender", Order = 1)]
        OrderReceivedFromLender = 1,

        [Display(Name = "Title Search", Order = 4)]
        TitleReviewed = 2,

        [Display(Name = "Settlement Statement Available", Order = 5)]
        SettlementStatementComplete = 4,

        [Display(Name = "Documents Recorded", Order = 6)]
        DocumentsRecorded = 8,

        [Display(Name = "Purchase Contract Received", Order = 2)]
        PurchaseContractReceived = 16,

        [Display(Name = "Borrower Information Collected", Order = 3)]
        BorrowerInformationCollected = 32,

        [Display(Name = "Buyer Information Collected", Order = 3)]
        BuyerInformationCollected = 64,

        [Display(Name = "Earnest Money Deposit Received", Order = 4)]
        EarnestMoneyDepositReceived = 128,

        [Display(Name = "Seller Information Collected", Order = 5)]
        SellerInformationCollected = 256,

        [Display(Name = "File Closed", Order = 6)]
        FileClosed = 512,
    }


    [Flags]
    public enum AgentTransactionType
    {
        [Display(Name = "Buyer Email/Phone Collected", Order = 1)]
        BuyerEmailPhoneCollected = 1,

        [Display(Name = "Seller Email/Phone Collected", Order = 1)]
        SellerEmailPhoneCollected = 2,

        [Display(Name = "Buyer Registered", Order = 2)]
        BuyerRegistered = 4,

        [Display(Name = "Seller Registered", Order = 2)]
        SellerRegistered = 8,

        [Display(Name = "Buyer Q&A Completed", Order = 3)]
        BuyerQAndACompleted = 16,

        [Display(Name = "Seller Q&A Completed", Order = 3)]
        SellerQAndACompleted = 32,

        [Display(Name = "Earnest Money Deposit Received", Order = 4)]
        EarnestMoneyDepositReceived = 64,

        [Display(Name = "Buyer Closing Funds", Order = 5)]
        BuyerFundsReceived = 128,

        [Display(Name = "Payoff Demand Received", Order = 5)]
        PayoffReceived = 256,

        [Display(Name = "Lender Funds Received", Order = 6)]
        LenderFundsReceived = 512,

        [Display(Name = "Commission Instructions Received", Order = 6)]
        SellerCommissionReceived = 1024,

        [Display(Name = "Commission Instructions Received", Order = 7)]
        BuyerCommissionReceived = 2048,

        [Display(Name = "Title Search", Order = 7)]
        SellerTitleReviewed = 4096,

        [Display(Name = "Title Search", Order = 8)]
        BuyerTitleReviewed = 8192,

        [Display(Name = "Documents Recorded", Order = 8)]
        SellerDocumentsRecorded = 16384,

        [Display(Name = "Documents Recorded", Order = 9)]
        BuyerDocumentsRecorded = 32768

    }
}
