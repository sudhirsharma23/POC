using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumersFileInfo
    {        
        public string FASTRegion { get; set; }     
        public int ConsumerFileId { get; set; }        
        public int FASTFileId { get; set; }        
        public string FASTFileNumber { get; set; }        
        public string FirstName { get; set; }        
        public string MiddleName { get; set; }
        public string LastName { get; set; }        
        public string Email { get; set; }        
        public ConsumerType ConsumerType { get; set; }        
        public string BusinessSegment { get; set; }        
        public string BusinessPrograms { get; set; }        
        public DateTime? FileOpenDate { get; set; }        
        public string TransactionType { get; set; }        
        public BuyerSellerType BuyerSellerType { get; set; }        
        public string EscrowOfficeName { get; set; }        
        public bool IsPrimary { get; set; }
        public ConsumerFileStatus Status { get; set; }        
        public int HistoryId { get; set; }        
        public int PrincipalId { get; set; }        
        public string CreatedOn { get; set; }        
        public DateTime? FileClosedOn { get; set; }        
        public FastFileStatus FastFileStatus { get; set; }        
        public string Identifier { get; set; }        
        public ConsumerAccountStatus UserAccountStatus { get; set; }        
        public string WorkPhone { get; set; }        
        public string HomePhone { get; set; }
        public string BuisnessPhoneExtension { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public int FastBuyerSellerTypeId { get; set; }
        public int ConsumerFileStatusId { get; set; }
        public string EscrowOfficerName { get; set; }
        public string NotificationPreference { get; set; }
    }
}
