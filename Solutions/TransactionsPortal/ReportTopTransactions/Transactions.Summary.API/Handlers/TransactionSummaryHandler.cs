using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Service;
using Transactions.Summary.API.Models;

namespace Transactions.Summary.API.Handlers
{
    public class TransactionSummaryHandler
    {

        public List<TransactionSummaryItemDTO> GetTransactionSummaryItemDTOs(List<Transaction> txList)
        {
            var list = new List<TransactionSummaryItemDTO>();

            txList.ForEach(p =>
            {
                list.Add(GetTransactionSummaryItemDTO(p));
            });

            return list;
        }

        public TransactionSummaryItemDTO GetTransactionSummaryItemDTO(Transaction tx)
        {
            var dto = new TransactionSummaryItemDTO();
            dto.PropertyAddress = GetPropertyAddress(tx.Property.Address);
            dto.State = tx.Property.Address.State;
            dto.OpenDate = GetTransactionDateDisplayString(tx.OpenDate);
            dto.EstimateCloseDate = GetTransactionDateDisplayString(tx.EstimateCloseDate);
            dto.Buyer = GetBuyerNames(tx.Buyers);
            dto.Seller = GetSellerNames(tx.Sellers);

            return dto;
        }

        /// <summary>
        /// expected address: 123 main street unit A, Santa Ana
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public string GetPropertyAddress(Address address)
        {
            var line2 = string.IsNullOrEmpty(address.Line2) ? null : $"{HandlerConstants.ONE_SPACE}{address.Line2}";
            var addressString = $"{address.Line1??""}{line2??""}{HandlerConstants.ADDRESS_SEPARATOR}{HandlerConstants.ONE_SPACE}{address.City??""}";
            addressString = addressString.Trim().TrimEnd(HandlerConstants.ADDRESS_SEPARATOR.ToCharArray()[0]);
            return addressString;
        }

        public string GetTransactionDateDisplayString(DateTime dateTime)
        {
            return dateTime.ToString(HandlerConstants.DATE_STRING_FORMAT);
        }

        public string GetBuyerNames(List<Buyer> buyers)
        {
            var stringBuilder = new StringBuilder();
            foreach(var b in buyers??=new List<Buyer>())
            {
                stringBuilder.Append(GetBuyerName(b)).Append(HandlerConstants.NAME_DELIMITER);
            }
            var buyerNames = stringBuilder.ToString();
            
            buyerNames = buyerNames.TrimEnd(HandlerConstants.NAME_DELIMITER);

            return buyerNames;
        }

        public string GetBuyerName(Buyer buyer)
        {
            return GetConsumerName(buyer.FirstName, buyer.MiddleName, buyer.LastName);
        }

        public string GetSellerNames(List<Seller> sellers)
        {
            var stringBuilder = new StringBuilder();
            foreach(var s in sellers??=new List<Seller>())
            {
                stringBuilder.Append(GetSellerName(s)).Append(HandlerConstants.NAME_DELIMITER);
            }
            return stringBuilder.ToString().TrimEnd(HandlerConstants.NAME_DELIMITER);
        }

        public string GetSellerName(Seller seller)
        {
            return GetConsumerName(seller.FirstName, seller.LastName);
        }

        public string GetConsumerName(string firstName, string lastName)
        {
            return GetConsumerName(firstName, null, lastName);
        }

        public string GetConsumerName(string firstName, string middleName, string lastName)
        {
            if (string.IsNullOrEmpty(middleName))
            {
                return $"{firstName}{HandlerConstants.ONE_SPACE}{lastName}";
            }
            return $"{firstName}{HandlerConstants.ONE_SPACE}{middleName}{HandlerConstants.ONE_SPACE}{lastName}";
        }
    }
}
