//------------------------------------------------------------------------------
namespace CP.DTO.FastFileData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Buyer : Consumer
    {
        public virtual List<Loan> NewLoanCollection { get; set; }
        public virtual List<Company> TaxExchangeCompanyCollection { get; set; }
        public virtual List<Company> MortgageBrokerCollection { get; set; }
    }
}

