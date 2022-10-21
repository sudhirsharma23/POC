using System;
using System.Collections.Generic;
using System.Text;
using Transactions.Service;
using Transactions.Summary.API.Models;

namespace Transactions.Summary.API.Handlers
{
    public class TransactionSummaryHandler
    {

        public static List<TransactionSummaryItemDTO> GetTransactionSummaryItemDTOs(List<Transaction> txList)
        {
            var list = new List<TransactionSummaryItemDTO>();

            txList.ForEach(p =>
            {
                list.Add(GetTransactionSummaryItemDTO(p));
            });

            return list;
        }

        public static TransactionSummaryItemDTO GetTransactionSummaryItemDTO(Transaction tx)
        {
            var dto = new TransactionSummaryItemDTO
            {
                PropertyAddress = GetPropertyAddress(tx.Property.Address),
                State = tx.Property.Address.State,
                OpenDate = GetTransactionDateDisplayString(tx.OpenDate),
                EstimateCloseDate = GetTransactionDateDisplayString(tx.EstimateCloseDate),
                Buyer = GetBuyerNames(tx.Buyers),
                Seller = GetSellerNames(tx.Sellers)
            };

            return dto;
        }

        /// <summary>
        /// expected address: 123 main street unit A, Santa Ana
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetPropertyAddress(Address address)
        {
            var line2 = string.IsNullOrEmpty(address.Line2) ? null : $"{HandlerConstants.ONE_SPACE}{address.Line2}";
            var addressString = $"{address.Line1 ?? ""}{line2 ?? ""}{HandlerConstants.ADDRESS_SEPARATOR}{HandlerConstants.ONE_SPACE}{address.City ?? ""}";
            addressString = addressString.Trim().TrimEnd(HandlerConstants.ADDRESS_SEPARATOR.ToCharArray()[0]);
            return addressString;
        }

        public static string GetTransactionDateDisplayString(DateTime dateTime)
        {
            return dateTime.ToString(HandlerConstants.DATE_STRING_FORMAT);
        }

        public static string GetBuyerNames(List<Buyer> buyers)
        {
            var stringBuilder = new StringBuilder();
            foreach (Buyer b in buyers ?? new List<Buyer>())
            {
                _ = stringBuilder.Append(GetBuyerName(b)).Append(HandlerConstants.NAME_DELIMITER);
            }
            var buyerNames = stringBuilder.ToString();

            buyerNames = buyerNames.TrimEnd(HandlerConstants.NAME_DELIMITER);

            return buyerNames;
        }

        public static string GetBuyerName(Buyer buyer)
        {
            return GetConsumerName(buyer.FirstName, buyer.MiddleName, buyer.LastName);
        }

        public static string GetSellerNames(List<Seller> sellers)
        {
            var stringBuilder = new StringBuilder();
            foreach (Seller s in sellers ?? new List<Seller>())
            {
                _ = stringBuilder.Append(GetSellerName(s)).Append(HandlerConstants.NAME_DELIMITER);
            }
            return stringBuilder.ToString().TrimEnd(HandlerConstants.NAME_DELIMITER);
        }

        public static string GetSellerName(Seller seller)
        {
            return GetConsumerName(seller.FirstName, seller.MiddleName, seller.LastName);
        }

        public static string GetConsumerName(string firstName, string lastName)
        {
            return GetConsumerName(firstName, null, lastName);
        }

        public static string GetConsumerName(string firstName, string middleName, string lastName)
        {
            return string.IsNullOrEmpty(middleName)
                ? $"{firstName}{HandlerConstants.ONE_SPACE}{lastName}"
                : $"{firstName}{HandlerConstants.ONE_SPACE}{middleName}{HandlerConstants.ONE_SPACE}{lastName}";
        }
    }
}
