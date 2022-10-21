using System;
using System.Collections.Generic;
using System.Text;

namespace Transactions.Service
{
    public class TransactionsServiceManagerInMemory : ITransactionsService
    {
        public List<Transaction> GetTransactions()
        {
            return new List<Transaction> {
                new Transaction
                {
                    Property = new Property
                    {
                        Address = new Address
                        {
                            Line1 = "10350 Judy Ave.",
                            City = "Cupertino",
                            State = "CA"
                        }
                    },
                    Buyers = new List<Buyer>
                    {
                        new Buyer
                        {
                            FirstName = "Ping",
                            MiddleName = "HG.",
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
                    OpenDate = DateTime.Parse("07-04-2020"),
                    EstimateCloseDate = DateTime.Parse("08-04-2020")
                },
                new Transaction
                {
                    Property = new Property
                    {
                        Address = new Address
                        {
                            Line1 = "91-1011 Aeioa Street",
                            Line2 = "Unit A",
                            City = "Ewa Beach",
                            State = "HI"
                        }
                    },
                    Buyers = new List<Buyer>
                    {
                        new Buyer
                        {
                            FirstName = "John",
                            LastName = "Jones"

                        }
                    },
                    Sellers = new List<Seller>
                    {
                        new Seller
                        {
                            FirstName = "Lawrence",
                            LastName = "Law"
                        },
                        new Seller
                        {
                            FirstName = "Jen",
                            LastName = "Law"
                        }
                    },
                    OpenDate = DateTime.Parse("07-02-2020"),
                    EstimateCloseDate = DateTime.Parse("08-02-2020")
                },
                new Transaction
                {
                    Property = new Property
                    {
                        Address = new Address
                        {
                            Line1 = "1925 Valley Road",
                            City = "Oceanside",
                            State = "CA"
                        }
                    },
                    Buyers = new List<Buyer>
                    {
                        new Buyer
                        {
                            FirstName = "Don",
                            LastName = "Bunnell"

                        }
                    },
                    Sellers = new List<Seller>
                    {
                        new Seller
                        {
                            FirstName = "Mike",
                            LastName = "Kidman"
                        },
                        new Seller
                        {
                            FirstName = "Nancy",
                            MiddleName = "GK.",
                            LastName = "Kidman"
                        }
                    },
                    OpenDate = DateTime.Parse("07-01-2020"),
                    EstimateCloseDate = DateTime.Parse("08-01-2020")
                },
                new Transaction
                {
                    Property = new Property
                    {
                        Address = new Address
                        {
                            Line1 = "14601 Cambria Way",
                            City = "Sylmar",
                            State = "CA"
                        }
                    },
                    Buyers = new List<Buyer>
                    {
                        new Buyer
                        {
                            FirstName = "Gardson",
                            LastName = "Githu"

                        }
                    },
                    OpenDate = DateTime.Parse("06-29-2020"),
                    EstimateCloseDate = DateTime.Parse("07-25-2020")
                },
                new Transaction
                {
                    Property = new Property
                    {
                        Address = new Address
                        {
                            Line1 = "18726 Paseo Picasso",
                            City = "Irvine",
                            State = "CA"
                        }
                    },
                    Buyers = new List<Buyer>
                    {
                        new Buyer
                        {
                            FirstName = "Feng",
                            LastName = "Men"

                        }
                    },
                    OpenDate = DateTime.Now,
                    EstimateCloseDate = DateTime.Now
                },
                new Transaction
                {
                    Property = new Property
                    {
                        Address = new Address
                        {
                            Line1 = "2 First American Way",
                            City = "Santa Ana",
                            State = "CA"
                        }
                    },
                    Buyers = new List<Buyer>
                    {
                        new Buyer
                        {
                            FirstName = "Parker",
                            LastName = "Kennedy"

                        }
                    },
                    OpenDate = DateTime.Now,
                    EstimateCloseDate = DateTime.Now
                }
            };
        }
    }
}
