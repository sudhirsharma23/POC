using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumerFileDto
    {
        public string FASTRegion { get; set; }

        public int RegionID { get; set; }

        public int ConsumerFileId { get; set; }

        public int FastFileId { get; set; }

        public string FASTFileNumber { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string UserNameSuffix { get; set; }

        public string Email { get; set; }

        public ConsumerType ConsumerType { get; set; }
        public int ConsumerTypeId { get; set; }
        public string BusinessSegment { get; set; }

        public string BusinessPrograms { get; set; }

        public int FASTBusinessSegmentID { get; set; }

        public DateTime? FileOpenDate { get; set; }

        public string TransactionType { get; set; }

        public BuyerSellerType BuyerSellerType { get; set; }

        public string EscrowOfficeName { get; set; }

        public bool IsPrimary { get; set; }

        public ConsumerFileStatus ConsumerFileStatus { get; set; }

        public string AdminFileStatus { get; set; }

        public int HistoryId { get; set; }

        public int PrincipalId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? FileClosedOn { get; set; }

        public FastFileStatus FastFileStatus { get; set; }

        public string WorkPhone { get; set; }

        public string HomePhone { get; set; }

        public string BuisnessPhoneExtension { get; set; }

        public string MobilePhone { get; set; }
        public int ExistingIdaasUserStatusId { get; set; }

        public string FaxNumber { get; set; }

        public int AuthSignatureID { get; set; }
        public string NotificationPreference { get; set; }

        public int FASTBuyerSellerTypeId { get; set; }
        public DateTime? EulaDate { get; set; }

        public DateTime? FileCreatedDate { get; set; }
        public DateTime? EstSettlementDate { get; set; }
        public bool IsFileExpired { get; set; }
        public string PropertyAddressDescription { get; set; }
        public string PropertyCounty { get; set; }
        public string PropertyAddressLine1 { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public int SeqNum { get; set; }
        public Guid? IdentityId { get; set; }
        public int BUID { get; set; }
        public string State { get; set; }
        public DateTime? LastProfileUpdateDate { get; set; }
        public DateTime AccountCreatedDate { get; set; }
        public bool ShowSecondaryESign { get; set; }
        public bool ShowFeedback { get; set; }
        public string DocumentName { get; set; }
        public string EnvelopeToBeESigned { get; set; }

        //public ExistingIdaasUserStatus ExistingIdaasUserStatusId { get; set; }
        //Multifile extra fields
        public string Role { get { return this.ConsumerType.ToString(); } }

        public int UnreadDocCount { get; set; }
        public int UnreadMsgCount { get; set; }
        public int SecEsignCount { get; set; }
        public string CssClass { get; set; }

        public string ViewStatus
        {
            get
            {
                return this.ConsumerFileStatus == ConsumerFileStatus.FileClosed ? "Closed" : "Open";
            }
        }

        public string FileType { get; set; }

        public bool IsAutoRegistrationEligible { get; set; }

        public RegistrationType RegistrationType { get; set; }

        //RE Agent related
        public bool IsReAgent { get; set; }

        public int LoggedInUserConsumerFileId { get; set; }
        public int? FileBusinessPartyID { get; set; }
        public DateTime? DateOfRegistration { get; set; }

        public int? BusOrgId { get; set; }
        public int? ContactId { get; set; }
        public int? IsAdHocContact { get; set; }
        public DateTime? LastFileAccessDate { get; set; }

        public string ShortName { get; set; }

        public string AdditionalContactId { get; set; }
        public bool QACompleted { get; set; }
        public bool QADisabled { get; set; }
        public string Name { get; set; }
        public int LandedToDashBoard { get; set; }
        public string LoggedInUserFirstName { get; set; }
        public string GabCode { get; set; }
        public bool DataCollectionStarted { get; set; }
        public string CreatedBy { get; set; }
        public int DupeConsumerFile { get; set; }
        public bool AchOptOut { get; set; }
    }

    public class NotificationCount
    {
        public List<NotificationCountDetails> lstCount { get; set; }
    }

    public class BuyerSellerForMilestone
    {
        public int ConsumerFileId { get; set; }
        public int ConsumerFileStatusId { get; set; }
        public DateTime? FileClosedOn { get; set; }
        public DateTime? FileCreatedDate { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public DateTime? DataCollectionCompletedDate { get; set; }
    }

    public class NotificationCountDetails
    {
        public int consumerFileId { get; set; }
        public int UnreadDocCount { get; set; }
        public int UnreadMsgCount { get; set; }
        public int SecEsignCount { get; set; }
    }

    public class ExceptionUIEvent
    {
        public int ExceptionUIEventId { get; set; }
        public int FastDataConsumerFileId { get; set; }
        public int SPDataConsumerFileId { get; set; }
        public int UIEvent { get; set; }
    }

    public class EclipseClientDetails
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string EnvironmentId { get; set; }
    }

    public class UnreadDocAndMsgCount
    {
        public bool Success { get; set; }
        public int? UnreadMsgCount { get; set; }
        public int? UnreadDocCount { get; set; }
    }

    public static class AdminFileStatus
    {
        public const string FileUnlinked = "File Unlinked";
        public const string QADisabled = "Q&A Disabled";
        public const string DocuSignDisabled = "DocuSign Disabled";
    }
}
