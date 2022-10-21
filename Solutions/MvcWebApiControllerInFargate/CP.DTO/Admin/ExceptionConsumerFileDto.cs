using System;

namespace CP.DTO.Admin
{
    public class ExceptionConsumerFileDto
    {
        public int ConsumerFileId { get; set; }

        public int SPConsumerFileId { get; set; }
        public int FASTFileId { get; set; }
        public string FASTFileNumber { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string UserNameSuffix { get; set; }

        public string Email { get; set; }

        public string FASTRegion { get; set; }

        public int RegionID { get; set; }

        public bool IsPrimary { get; set; }

        public int PrincipalId { get; set; }

        public ConsumerType ConsumerType { get; set; }

        public string BusinessSegment { get; set; }

        public string BusinessPrograms { get; set; }

        public int FASTBusinessSegmentID { get; set; }

        public DateTime FileOpenDate { get; set; }

        public string TransactionType { get; set; }

        public string EscrowOfficeName { get; set; }

        public int HistoryId { get; set; }

        public string CreatedOn { get; set; }

        public DateTime? FileClosedOn { get; set; }

        public string WorkPhone { get; set; }

        public string HomePhone { get; set; }

        public string BuisnessPhoneExtension { get; set; }

        public string MobilePhone { get; set; }

        public string FaxNumber { get; set; }

        public int AuthSignatureID { get; set; }
        public string NotificationPreference { get; set; }

        public int ConsumerFileStatusId { get; set; }
        public int FASTBuyerSellerTypeId { get; set; }

        public bool IsFileExpired { get; set; }
        public string PropertyAddressDescription { get; set; }
        public Guid? IdentityId { get; set; }
        public string EooState { get; set; }
        public string FileStatus { get; set; }

        public string EscrowOfficerName { get; set; }

        public string FileType { get; set; }

        public BuyerSellerType BuyerSellerType { get; set; }

        public string UserName;
        public int RowNumber { get; set; }

        public ExceptionUIEventType Event { get; set; }
        public string Comments { get; set; }

        public string EscrowOfficerEmail { get; set; }
        public string EscrowAssistantEmail { get; set; }

    }
}
