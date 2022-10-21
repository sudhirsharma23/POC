using System;
using System.Collections.Generic;

namespace CP.DTO.Admin
{
    
    public class ConsumerFileInfo
    {
        
        public string FASTRegion { get; set; }
        
        public int ConsumerFileId { get; set; }
        
        public int FASTFileId { get; set; }
        
        public string FASTFileNumber { get; set; }
        
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }

        public string UserNameSuffix { get; set; }

        public string Email { get; set; }
        
        public ConsumerType ConsumerType { get; set; }
        
        public string BusinessSegment { get; set; }
        
        public string BusinessPrograms { get; set; }
        
        public DateTime? FileOpenDate { get; set; }
        
        public DateTime? EstSettlementDate { get; set; }
        
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
        
        public Guid? IdentityId { get; set; }
        
        public ConsumerAccountStatus UserAccountStatus { get; set; }
        
        public string WorkPhone { get; set; }
        
        public string HomePhone { get; set; }
        
        public string BuisnessPhoneExtension { get; set; }
        
        public string MobilePhone { get; set; }
        
        public string FaxNumber { get; set; }

        
        public int FastBuyerSellerTypeId { get; set; }
        //
        //public int AuthSignatureID { get; set; }

        
        public int ConsumerFileStatusId { get; set; }

        
        public string EscrowOfficerName { get; set; }

        
        public string NotificationPreference { get; set; }

        
        public string Grp { get; set; }
        
        public bool HasSpouse { get; set; }

        
        public bool IsMultiFileUser { get; set; }

        
        public string Comments { get; set; }

        
        public string EscrowOfficerEmail { get; set; }

        
        public string EscrowAssistantEmail { get; set; }

        
        public bool IsREAgent { get; set; }

        
        public bool SpouseOnExceptionScreen { get; set; }

        
        public bool IsExactMatchUser { get; set; }
        
        public bool PendingRegistrationicon { get; set; }
        
        public int? ContactId { get; set; }
        public int FileBusinessPartyID { get; set; }
        public int? BusOrgId { get; set; }
        public int? IsAdHocContact { get; set; }
        public string LinkStatus { get; set; }

        public int ExistingIdaasUserStatusId { get; set; }
        public string State { get; set; }
        public string PropertyState { get; set; }
    }

    
    public enum ConsumerAccountStatus
    {
        
        None = 0,
        
        Unverified = 1,
        
        Active = 2,
        
        Inactive = 3,
        
        Notification = 5,
        
        NotificationDisabled = 6,
        
        Suspended = 7,
        
        OnHold = 8,
    }

    
    public class ConsumerOffices
    {
        
        public int OfficeId { get; set; }
        
        public int RegionId { get; set; }
        
        public string OfficeName { get; set; }
        
        public string OfficeCode { get; set; }

        
        public bool IsActive { get; set; }

        
        public string State { get; set; }

        
        public DateTime? OfficeEnabledDate { get; set; }

        
        public DateTime? NewHomesOfficeEnabledDate { get; set; }
    }

    public class ConsumerStates
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Buyer { get; set; }
        public int Seller { get; set; }
        public int Borrower { get; set; }
        public int Agent { get; set; }
        public int TC { get; set; }
        
       // public List<int> Consumers { get; set; }

    }

    public class MultifileRegisteredConsumerFileIds
    {
        public int ConsumerFileId { get; set; }
        public int RegisteredConsumerFileId { get; set; }
    }

    public class ExactMatchButNotRegisteredConsumerFileIds
    {
        public int ConsumerFileId { get; set; }
    }

    public class ExceptionMatchedConsumerFileIds
    {
        public int FastDataConsumerFileId { get; set; }
        public int SPDataConsumerFileId { get; set; }
    }

    public class Brand
    {
        public int Id { get; set; }
        public string LogoUri { get; set; }
        public string MessageTag { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string WidgetHeader { get; set; }
    }

    public class DisableEsignDetails
    {
        public int ConsumerFilestatusId { get; set; }
        public bool PrimaryEsignDisabled { get; set; }
        public bool SecondaryEsignAvailable { get; set; }
        public bool SecondaryEsignDisabled { get; set; }
        public bool SecondaryEsignRemoved { get; set; }

    }
    public class OptedOutUsersFile
    {
        public int ConsumerFileId { get; set; }
        public int FastBuyerSellerTypeId { get; set; }
        public int ConsumerFileStatusId { get; set; }
    }
    public class LinkFileDetails
    {
        public int ConsumerFileId { get; set; }
        public int FASTFileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ConsumerType ConsumerType { get; set; }
        public int PrincipalId { get; set; }
        public bool IsPrimary { get; set; }
        public BuyerSellerType BuyerSellerType { get; set; }
        public int AdditionalContactId { get; set; }
        public string Identity { get; set; }
        public string Username { get; set; }
    }

}
