
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CP.DTO.FastFileData
{
    public class Borrower : Consumer
	{

	    public Borrower()
	    {
	    }

        public virtual string TitleVesting
        {
            get;
            set;
        }

        public virtual List<Loan> PayoffLoanCollection
        {
            get;
            set;
        }

        public virtual List<HomeOwnerAssociation> HOACollection
        {
            get;
            set;
        }
        public virtual List<Loan> NewLoanCollection 
        { 
            get; 
            set; 
        }
        public virtual List<Company> MortgageBrokerCollection
        {
            get;
            set;
        }

    }
}

