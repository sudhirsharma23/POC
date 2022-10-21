using Report.TransactionType.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.TransactionType.Service.Lambda.Tests
{
    public class ReportTransactionTypeServiceManagerInMemory : IReportTransactionTypeService
    {
        public ReportItem GetCountByTransactionType(DateTime date)
        {
            var docItem = new DocumentReportItem
            {
                ID = "2020-8-21",
                Item = new ReportItem
                {
                    DateString = "2020-8-21",
                    Title = "Count By Transaction Type",
                    DataItems = new List<NumberDataItem>
                    {
                        new NumberDataItem("Refinance", 3557),
                        new NumberDataItem("Sale w/Mortgage", 2832),
                        new NumberDataItem("Sale/Cash", 1045),
                        new NumberDataItem("Search Package", 497),
                        new NumberDataItem("Accommodation", 233),
                        new NumberDataItem("Equity Loan", 217),
                        new NumberDataItem("Mtg Mod w/Endorsement", 110),
                        new NumberDataItem("Bulk Sale", 86),
                        new NumberDataItem("Limited Escrow", 56),
                        new NumberDataItem("Construction Finance", 53),
                        new NumberDataItem("Second Mortgage", 44),
                        new NumberDataItem("Delayed", 37),
                        new NumberDataItem("Construction Disbursement", 21),
                        new NumberDataItem("Sale w/Construction Loan", 18),
                        new NumberDataItem("Foreclosure", 17),
                        new NumberDataItem("REO Sale w/Mortgage", 8),
                        new NumberDataItem("Mtg Mod w/Increased Liability", 7),
                        new NumberDataItem("REO Sale/Cash", 5),
                        new NumberDataItem("Sale/Exchange", 5),
                        new NumberDataItem("Settlement Statement Only", 4),
                        new NumberDataItem("Short Sale w/Mortgage", 1)
                    }
                }
            };
            return docItem.Item;
        }

        public async Task SendMessageAsync(string reportItemsString)
        {
            await Task.Run(() => Console.WriteLine("Test"));
        }
    }
}
