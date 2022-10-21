using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Transactions.Service;
using Transactions.Summary.API.Handlers;

namespace Transactions.Summary.API.UnitTests
{
    [TestClass]
    public class TransactionsSummaryHandlerTests
    {
        private readonly string firstName = "Feng";
        private readonly string lastName = "Men";
        private readonly string middleName = "Fred";
        private readonly string expectedName = $"Feng{HandlerConstants.ONE_SPACE}Men";
        private readonly string expectedNameWithMiddleName = $"Feng{HandlerConstants.ONE_SPACE}Fred{HandlerConstants.ONE_SPACE}Men";
        private readonly string line1 = "123 Main ST.";
        private readonly string line2 = "Unit A";
        private readonly string city = "Santa Ana";
        private readonly string state = "CA";
        private readonly string expectedAddressWithoutLine1 = $"Unit A{HandlerConstants.ADDRESS_SEPARATOR}{HandlerConstants.ONE_SPACE}Santa Ana";
        private readonly string expectedAddressWithoutLine2 = $"123 Main ST.{HandlerConstants.ADDRESS_SEPARATOR}{HandlerConstants.ONE_SPACE}Santa Ana";
        private readonly string expectedAddress = $"123 Main ST.{HandlerConstants.ONE_SPACE}Unit A{HandlerConstants.ADDRESS_SEPARATOR}{HandlerConstants.ONE_SPACE}Santa Ana";
        private readonly string expectedAddressWithOnlyCity = $"{HandlerConstants.ADDRESS_SEPARATOR}{HandlerConstants.ONE_SPACE}Santa Ana";

        [TestMethod]
        public void CanGetConsumerName()
        {
            var consumerName = TransactionSummaryHandler.GetConsumerName(firstName, lastName);

            Assert.AreEqual(expectedName, consumerName);

        }

        [TestMethod]
        public void CanGetSellerName()
        {
            var seller = new Seller
            {
                FirstName = firstName,
                LastName = lastName
            };

            var sellerName = TransactionSummaryHandler.GetSellerName(seller);

            Assert.AreEqual(expectedName, sellerName);
        }

        [TestMethod]
        public void CanGetSellerName_WithMiddleName()
        {
            var seller = new Seller
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName
            };

            var sellerName = TransactionSummaryHandler.GetSellerName(seller);

            Assert.AreEqual(expectedNameWithMiddleName, sellerName);
        }

        [TestMethod]
        public void CanGetBuyerName()
        {
            var buyer = new Buyer
            {
                FirstName = firstName,
                LastName = lastName
            };

            var buyerName = TransactionSummaryHandler.GetBuyerName(buyer);

            Assert.AreEqual(expectedName, buyerName);
        }

        [TestMethod]
        public void GetBuyerName_WithMiddleName()
        {
            var buyer = new Buyer
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName
            };

            var buyerName = TransactionSummaryHandler.GetBuyerName(buyer);

            Assert.AreEqual(expectedNameWithMiddleName, buyerName);
        }

        [TestMethod]
        public void CanGetBuyerNames_FromZeroBuyer()
        {
            var expecetdBuyerNames = string.Empty;

            var buyerNames = TransactionSummaryHandler.GetBuyerNames(null);

            Assert.AreEqual(expecetdBuyerNames, buyerNames);

            buyerNames = TransactionSummaryHandler.GetBuyerNames(new List<Buyer>());

            Assert.AreEqual(expecetdBuyerNames, buyerNames);
        }

        [TestMethod]
        public void CanGetBuyerNames_FromOneBuyer()
        {
            var buyerList = new List<Buyer> { new Buyer {
                FirstName = firstName,
                LastName = lastName
            } };
            var expecetdBuyerNames = expectedName;

            var buyerNames = TransactionSummaryHandler.GetBuyerNames(buyerList);

            Assert.AreEqual(expecetdBuyerNames, buyerNames);
        }

        [TestMethod]
        public void CanGetBuyerNames_FromTwoBuyer()
        {
            var buyerList = new List<Buyer> {
                new Buyer {
                    FirstName = firstName,
                    LastName = lastName
                },
                new Buyer
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            };
            var expecetdBuyerNames = expectedName + HandlerConstants.NAME_DELIMITER + expectedName;

            var buyerNames = TransactionSummaryHandler.GetBuyerNames(buyerList);

            Assert.AreEqual(expecetdBuyerNames, buyerNames);
        }

        [TestMethod]
        public void CanGetSellerNames_FromZeroSeller()
        {

            var expectedSellerNames = string.Empty;

            var sellerNames = TransactionSummaryHandler.GetSellerNames(null);

            Assert.AreEqual(expectedSellerNames, sellerNames);

            sellerNames = TransactionSummaryHandler.GetSellerNames(new List<Seller>());

            Assert.AreEqual(expectedSellerNames, sellerNames);
        }

        [TestMethod]
        public void CanGetSellerNames_FromOneSeller()
        {
            var sellerList = new List<Seller> {
                new Seller
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            };

            var expectedSellerNames = expectedName;

            var sellerNames = TransactionSummaryHandler.GetSellerNames(sellerList);

            Assert.AreEqual(expectedSellerNames, sellerNames);
        }

        [TestMethod]
        public void CanGetSellerNames_FromTwoSellers()
        {
            var sellerList = new List<Seller> {
                new Seller
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                new Seller
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            };

            var expectedSellerNames = expectedName + HandlerConstants.NAME_DELIMITER + expectedName;

            var sellerNames = TransactionSummaryHandler.GetSellerNames(sellerList);

            Assert.AreEqual(expectedSellerNames, sellerNames);
        }

        [TestMethod]
        public void CanGetPropertyAddress()
        {
            var address = new Address
            {
                Line1 = line1,
                Line2 = line2,
                City = city,
                State = state
            };

            var propertyAddress = TransactionSummaryHandler.GetPropertyAddress(address);

            Assert.AreEqual(expectedAddress, propertyAddress);

        }

        [TestMethod]
        public void CanGetPropertyAddress_WithoutLine1()
        {
            var address = new Address
            {
                Line2 = line2,
                City = city,
                State = state
            };

            var propertyAddress = TransactionSummaryHandler.GetPropertyAddress(address);

            Assert.AreEqual(expectedAddressWithoutLine1, propertyAddress);

        }

        [TestMethod]
        public void CanGetPropertyAddress_WithoutLine2()
        {
            var address = new Address
            {
                Line1 = line1,
                City = city,
                State = state
            };

            var propertyAddress = TransactionSummaryHandler.GetPropertyAddress(address);

            Assert.AreEqual(expectedAddressWithoutLine2, propertyAddress);

        }


        [TestMethod]
        public void CanGetPropertyAddress_WithOnlyCity()
        {
            var address = new Address
            {
                City = city,
                State = state
            };

            var propertyAddress = TransactionSummaryHandler.GetPropertyAddress(address);

            Assert.AreEqual(expectedAddressWithOnlyCity, propertyAddress);

        }

        [TestMethod]
        public void CanGetPropertyAddress_WithoutLine1andLine2andCity()
        {
            var address = new Address
            {
                State = state
            };

            var expectedAddress = string.Empty;

            var propertyAddress = TransactionSummaryHandler.GetPropertyAddress(address);

            Assert.AreEqual(expectedAddress, propertyAddress);
        }

        [TestMethod]
        public void CanGetOpenDateDisplayString()
        {

            var openDate = DateTime.Parse("07-20-2019");

            var expectedOpenDateDisplayString = "7/20/2019";

            var openDateDisplayString = TransactionSummaryHandler.GetTransactionDateDisplayString(openDate);

            Assert.AreEqual(expectedOpenDateDisplayString, openDateDisplayString);
        }

        [TestMethod]
        public void CanGetCloseDateDisplayString()
        {

            var closeDate = DateTime.Parse("08-21-2019");

            var expectedCloseDateDisplayString = "8/21/2019";

            var closeDateDisplayString = TransactionSummaryHandler.GetTransactionDateDisplayString(closeDate);

            Assert.AreEqual(expectedCloseDateDisplayString, closeDateDisplayString);
        }

        [TestMethod]
        public void CanGetTransactionSummaryItemDTO()
        {
            var tx = new Transaction
            {
                Property = new Property
                {
                    Address = new Address
                    {
                        Line1 = "10349 Judy Ave.",
                        City = "Cupertino",
                        State = "CA"
                    }
                },
                Buyers = new List<Buyer>
                                {
                                    new Buyer
                                    {
                                        FirstName = "Ping",
                                        LastName = "Wang"

                                    },
                                    new Buyer
                                    {
                                        FirstName = "Hong",
                                        LastName = "Wang"

                                    }
                                },
                Sellers = new List<Seller>
                                {
                                    new Seller
                                    {
                                        FirstName = "Steve",
                                        LastName = "Smith"
                                    }
                                },
                OpenDate = DateTime.Parse("07-20-2019"),
                EstimateCloseDate = DateTime.Parse("08-20-2019")
            };

            Models.TransactionSummaryItemDTO txDTO = TransactionSummaryHandler.GetTransactionSummaryItemDTO(tx);

            Assert.AreEqual("10349 Judy Ave., Cupertino", txDTO.PropertyAddress);
            Assert.AreEqual("CA", txDTO.State);
            Assert.AreEqual("Ping Wang/Hong Wang", txDTO.Buyer);
            Assert.AreEqual("Steve Smith", txDTO.Seller);
            Assert.AreEqual("7/20/2019", txDTO.OpenDate);
            Assert.AreEqual("8/20/2019", txDTO.EstimateCloseDate);
        }

        [TestMethod]
        public void CanGetTransactionSummaryItemDTOs()
        {
            var txList = new List<Transaction> {
                new Transaction
                        {
                            Property = new Property
                            {
                                Address = new Address
                                {
                                    Line1 = "10349 Judy Ave.",
                                    City = "Cupertino",
                                    State = "CA"
                                }
                            },
                            Buyers = new List<Buyer>
                                {
                                    new Buyer
                                    {
                                        FirstName = "Ping",
                                        LastName = "Wang"

                                    },
                                    new Buyer
                                    {
                                        FirstName = "Hong",
                                        LastName = "Wang"

                                    }
                                },
                            Sellers = new List<Seller>
                                {
                                    new Seller
                                    {
                                        FirstName = "Steve",
                                        LastName = "Smith"
                                    }
                                },
                            OpenDate = DateTime.Parse("07-20-2019"),
                            EstimateCloseDate = DateTime.Parse("08-20-2019")
                    }
                };
            List<Models.TransactionSummaryItemDTO> txSummaryItemDTOList = TransactionSummaryHandler.GetTransactionSummaryItemDTOs(txList);
            Models.TransactionSummaryItemDTO summaryItemDTO = txSummaryItemDTOList[0];
            Assert.AreEqual("10349 Judy Ave., Cupertino", summaryItemDTO.PropertyAddress);
            Assert.AreEqual("CA", summaryItemDTO.State);
            Assert.AreEqual("Ping Wang/Hong Wang", summaryItemDTO.Buyer);
            Assert.AreEqual("Steve Smith", summaryItemDTO.Seller);
            Assert.AreEqual("7/20/2019", summaryItemDTO.OpenDate);
            Assert.AreEqual("8/20/2019", summaryItemDTO.EstimateCloseDate);

            txList = new List<Transaction>();
            txSummaryItemDTOList = TransactionSummaryHandler.GetTransactionSummaryItemDTOs(txList);

            Assert.AreEqual(0, txSummaryItemDTOList.Count);
        }
    }
}
