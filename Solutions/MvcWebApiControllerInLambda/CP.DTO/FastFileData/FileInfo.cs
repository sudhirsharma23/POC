namespace CP.DTO.FastFileData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FileInfo
    {
        public virtual int FileID { get; set; }
        public virtual string FileNumber { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual string EscrowOfficerName { get; set; }
        public virtual string EscrowOfficerPhoneNumber { get; set; }
        public virtual string EscrowOfficerFaxNumber { get; set; }
        public virtual string EscrowOfficerEmail { get; set; }
        public virtual decimal SalesPrice { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual string LenderName { get; set; }
        public virtual Company EscrowOffice { get; set; }
        public virtual Property Property { get; set; }
        public virtual IEnumerable<Borrower> BorrowerCollection { get; set; }
        public virtual IEnumerable<Buyer> BuyerCollection { get; set; }
        public virtual IEnumerable<Seller> SellerCollection { get; set; }
        public virtual string OfficerSTLicenceID { get; set; }
        public virtual string EstimatedSettlementDate { get; set; }
        public virtual FireInsuranceInformation FireInsuranceInfo { get; set; }
        public virtual string OfficialCompanyName { get; set; }
        public virtual string OfficialCompanyName2 { get; set; }
        public virtual int EOFASTEmployeeID { get; set; }
        public virtual int? RegionId { get; set; }
        public virtual string LPOName { get; set; }
        public virtual int? BusinessSegmentCdID { get; set; }
        public virtual string BusinessSegmentObjectCD { get; set; }
        public virtual IEnumerable<string> BusinessPrograms { get; set; }

        public virtual DateTime? EscrowServiceTypeOpenDate { get; set; }

        public virtual IEnumerable<string> PropertyAPNs { get; set; }

        //public IEnumerable<FileParty> ReAgents { get; set; }

        //public IEnumerable<FileParty> ReAgentContacts { get; set; }

        //public IEnumerable<FileParty> ReBrokers { get; set; }

        //public IEnumerable<FileParty> ReBrokerContacts { get; set; }

        //public IEnumerable<FileParty> TransactionCoOrdinators { get; set; }

        //public IEnumerable<FileParty> TCContacts { get; set; }

        public FileParty ReAgent { get; set; }
        public FileParty ReBroker { get; set; }

        public FileParty TransactionCoOrdinator { get; set; }
        public AgentCommissionSummary CommissionSummary { get; set; }
    }
}

