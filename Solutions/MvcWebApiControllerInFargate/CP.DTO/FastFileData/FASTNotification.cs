using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CP.DTO.FastFileData
{
    [DataContract]
    public class ChangeNotificationRequest
    {
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public string TrackingID { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string Target { get; set; }
        [DataMember]
        public string ObjectCd { get; set; }
        [DataMember]
        public List<Detail> Details { get; set; }
        [DataMember]
        public List<DocumentDetail> DocumentDetails { get; set; }
        [DataMember]
        public List<Field> Fields { get; set; }
        [DataMember]
        public TypeChangeInfo TypeChangeInfo { get; set; }
        [DataMember]
        public Recipients Recipients { get; set; }
        [DataMember]
        public bool IsTemplate { get; set; }            
        [DataMember]
        public IgniteNotification IgniteNotificationDto { get; set; }
    }
    [DataContract]
    public class Recipients
    {
        [DataMember]
        public ToRecipients ToRecipients { get; set; }
        [DataMember]
        public CCRecipients CCRecipients { get; set; }
    }
    [DataContract]
    public class ToRecipients
    {
        [DataMember]
        public List<RecipientDetails> TO { get; set; }
    }
    [DataContract]
    public class CCRecipients
    {
        [DataMember]
        public List<RecipientDetails> CC { get; set; }
    }
    [DataContract]
    public class RecipientDetails
    {
        [DataMember]
        public string ConsumerName { get; set; }
        [DataMember]
        public string ConsumerFirstName { get; set; }
        [DataMember]
        public string ConsumerLastName { get; set; }
        [DataMember]
        public string ConsumerMessageBoxID { get; set; }
        [DataMember]
        public string ConsumerEmail { get; set; }
        [DataMember]
        public string ConsumerMobilePhone { get; set; }
        [DataMember]
        public int PrincipalId { get; set; }
        [DataMember]
        public int ConsumerFileBusinessPartyID { get; set; }
    }
    [DataContract]
    public class TypeChangeInfo
    {
        [DataMember]
        public int OldPrincipalID { get; set; }
        [DataMember]
        public int NewPrincipalID { get; set; }
        [DataMember]
        public int OldTypeID { get; set; }
        [DataMember]
        public int NewTypeID { get; set; }
        [DataMember]
        public bool IsSpouse1Copied { get; set; }
    }

    [DataContract]
    public class Detail
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }
    }

    [DataContract]
    public class DocumentDetail
    {
        [DataMember]
        public int DocumentID { get; set; }
        [DataMember]
        public string DocumentName { get; set; }
        [DataMember]
        public string DocumentFriendlyName { get; set; }
        [DataMember]
        public bool IsPublish { get; set; }
        [DataMember]
        public bool IsESign { get; set; }
        [DataMember]
        public int PrincipalId { get; set; }
    }

    [DataContract]
    public class Field
    {
        [DataMember]
        public string FieldObjectCd { get; set; }

    }

    [DataContract]
    public class ChangeNotificationResponse
    {
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int StatusID { get; set; }
        [DataMember]
        public string StatusMsg { get; set; }
    }

    [DataContract]
    public static class ChangeNotificationCode
    {
        [DataMember]
        public const string FileCreated = "4000";
        [DataMember]
        public const string BuyerAdded = "4005";
        [DataMember]
        public const string BuyerRemoved = "4026";
        [DataMember]
        public const string BuyerChanged = "4006";
        [DataMember]
        public const string TitleOwningOfficeChanged = "4011";
        [DataMember]
        public const string EscrowOwningOfficeChanged = "4012";
        [DataMember]
        public const string EscrowServiceAdded = "4034";
        [DataMember]
        public const string TitleServiceAdded = "4052";
        [DataMember]
        public const string EscrowOfficerChange = "4049";
        [DataMember]
        public const string EscrowServiceRemoved = "4035";
        [DataMember]
        public const string TermsDatesStatusAdded = "4028";
        [DataMember]
        public const string TermsDatesStatusChanged = "4029";
        [DataMember]
        public const string SellerAdded = "4019";
        [DataMember]
        public const string SellerRemoved = "4020";
        [DataMember]
        public const string MessageSent = "MC_1003";
        [DataMember]
        public const string SellerChanged = "4021";
        [DataMember]
        public const string TaskChanged = "4015";
        [DataMember]
        public const string OrderStatusChange = "4017";
        [DataMember]
        public const string BusinessProgramAdded = "4057";
        [DataMember]
        public const string BusinessProgramRemoved = "4058";
        [DataMember]
        public const string TransactionTypeChanged = "4024";
        [DataMember]
        public const string BusinessSegmentChanged = "4025";

        //Real Estate Agents
        [DataMember]
        public const string BuyerAgentAdded = "4096";
        [DataMember]
        public const string SellerAgentAdded = "4098";
        [DataMember]
        public const string BuyerAgentRemoved = "4097";
        [DataMember]
        public const string SellerAgentRemoved = "4099";
        [DataMember]
        public const string BuyerTCAdded = "4092";
        [DataMember]
        public const string SellerTCAdded = "4094";
        [DataMember]
        public const string BuyerTCRemoved = "4093";
        [DataMember]
        public const string SellerTCRemoved = "4095";
        [DataMember]
        public const string GABStatusChangedFromFileAndAdmin = "4080";
        [DataMember]
        public const string GABStatusChangedFromAdmin = "4446";
        [DataMember]
        public const string IgniteTaskStatusChanged = "6000";
    }

    [DataContract]
    public static class ChangeNotificationSubCode
    {

        [DataMember]
        public const string BuyerTypeChange = "4006.3";
        [DataMember]
        public const string SellerTypeChange = "4021.2";
        [DataMember]
        public const string TaskStatusChanged = "4015.1";
        [DataMember]
        public const string TaskCommentChanged = "4015.2";
        [DataMember]
        public const string BuyerTrustEstateContactAdded = "4006.13";
        [DataMember]
        public const string BuyerTrustEstateContactRemoved = "4006.14";
        [DataMember]
        public const string BuyerTrustEstateContactChanged = "4006.12";
        [DataMember]
        public const string SellerTrustEstateContactAdded = "4021.13";
        [DataMember]
        public const string SellerTrustEstateContactRemoved = "4021.14";
        [DataMember]
        public const string SellerTrustEstateContactChanged = "4021.12";
        [DataMember]
        public const string BuyerBusinessEntityContactAdded = "4006.16";
        [DataMember]
        public const string BuyerBusinessEntityContactRemoved = "4006.17";
        [DataMember]
        public const string BuyerBusinessEntityContactChanged = "4006.15";
        [DataMember]
        public const string SellerBusinessEntityContactAdded = "4021.16";
        [DataMember]
        public const string SellerBusinessEntityContactRemoved = "4021.17";
        [DataMember]
        public const string SellerBusinessEntityContactChanged = "4021.15";
    }


    [DataContract]
    public class IgniteNotification
    {
        [DataMember]
        public int FastFileId { get; set; }
        [DataMember]
        public int IgniteFileId { get; set; }
        [DataMember]
        public string ObjectCd { get; set; }
        [DataMember]
        public string FieldObjectCd { get; set; }
        [DataMember]
        public NotificationData NotificationData { get; set; }
        [DataMember]
        public string Source { get; set; }
    }

    [DataContract]
    public class NotificationData
    {
        [DataMember]
        public long FileTaskId { get; set; }
        [DataMember]
        public int? TaskId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public DateTime? CompletedDate { get; set; }
        [DataMember]
        public DateTime? InProcessDate { get; set; }
        [DataMember]
        public DateTime? DueDate { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public DateTime? WaivedDate { get; set; }
        [DataMember]
        public string TaskStatus { get; set; }
        [DataMember]
        public string TaskAction { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public string Notes { get; set; }
    }
}
