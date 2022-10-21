using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace CP.DTO
{
    public enum FASTAdminEventObjectCD
    {
        GABUpdated = 4082,
        GABContactUpdated = 4084
    }

    public enum SecureMessages
    {
        Subject = 0,
        Body = 1
    }

    public enum Documents
    {
        uploadComment = 0
    }

    public enum DocumentActionType
    {
        Publish = 1,
        Upload = 2,
        SystemUpload = 3,
        SystemUploadFastOnly = 4,
        Hosted = 5
    }

    public enum BusinessPartyRole
    {
        None = 0,
        Buyer = 113,
        Seller = 114,
        BuyerAgent = 685,
        SellerAgent = 686,
        SellerTC = 2371,
        BuyerTC = 2368
    }

    public enum SortType
    {
        Desc = 0,
        Asc = 1
    }

    public enum MessageTypes
    {
        Undefined = 0,
        Email = 1,
        InstantMessage = 2,
        Other = 3
    }

    public enum BuyerSellerType
    {
        None = 0,
        Individual = 48,

        [Display(Name = @"Husband/Wife")]
        HusbandAndWife = 49,

        Trust = 50,

        [Display(Name = "Business Entity")]
        BusinessEntity = 51,

        [Display(Name = "REAgent")]
        Agent = 52,

        [Display(Name = "REBroker")]
        Broker = 53,

        [Display(Name = "Transaction Coordinator")]
        TransactionCoordinator = 54
    }

    public enum ContactAddressType
    {
        HomePhone = 121,
        BusinessPhone = 122,
        Cellular = 125,
        Email = 127,
    }

    public enum ProtocolEnum : int
    {
        SMTP = 0,
        SMS = 1,
    }

    public enum FastFileStatus
    {
        None = 0,
        Open = 151,
        OpenInError = 152,
        Cancelled = 153,
        Closed = 154,
        Pending = 1507
    }

    public enum ConsumerType
    {
        None = 0,
        Buyer = 1,
        Borrower = 2,
        Seller = 3,
        BuyerAgent = 4,
        SellerAgent = 5,
        BuyerBroker = 6,
        SellerBroker = 7,
        BuyerTC = 8,
        SellerTC = 9
    }

    public enum REAssociatedMessage
    {
        BuyerRegistrationNotComplete = 21,
        SellerRegistrationNotComplete = 22,
        BuyerQANotCompleted = 23,
        SellerQANotCompleted = 24,
        AgentOrTCDataCollectionStarted = 25
    }

    public enum ConsumerFileStatus
    {
        DeactivatedAndOptOut = -2,
        Eula = -1,
        None = 0,
        New = 1,
        EmailSent = 2,
        IdentityCreated = 3,
        ProofingFailed = 4,
        ProofingReset = 5,
        ProofingCompleted = 6,
        DataCollectionStarted = 7,
        DataCollectionCompleted = 8,
        DocuSignSigningCompleted = 9,
        FileClosed = 10, /* user can still login up to 30 days, disabled after 30 days */
        OnHold = 11,
        Deactivated = 12,
        OptOut = 13,
        Removed = 14,
        DocumentsRequested = 15
    }

    public enum ReminderNotificationType
    {
        ManualPackage = 1,
        ESiginingInComplete = 2,
        DataCollectionNotStarted = 3,
        DataCollectionInComplete = 4,
        IdentityNotCreated = 5,
        SpouseESigningIncomplete = 6
    }

    public enum CountNotificationType
    {
        EventNotification = 1,
        LoginNotification = 2,
        ReadNotification = 3,
        PublishDocNotificattion = 4
    }

    public enum DefaultMessageType
    {
        NewRegistration = 1,
        NewRegistrationFastWorkFlowTaskCompletion = 2,
        NewRegistrationWelcomeBack = 3,
        TrustBusinessEntityNewRegistration = 4,
        TrustBusinessEntityNewRegistrationWelcomeBack = 5,
        NewRegistrationHusbandWife = 6,
        NewRegistrationWelcomeBackHusbandWife = 7,
        NewRegistrationWelcomeBackFastTaskCompletion = 8,
        ReAgentWelcomeBack = 15,
        ReAgentNewRegistration = 16
    }

    public enum RegistrationType
    {
        None = 0,
        RegisterNow = 1,
        WelComeBack = 2,
    }

    public enum ExternalSystemResponseType
    {
        PartyEligible = 1,
        PartyRemoved, //US# 1820039
        PartyRegistered,
        PartyNotRegistered,
        DataCollectionComplete,
        PartyRegistrationSent,
        PartyOptOut
    }

    /// <summary>
    /// indicates to which category the message belongs to.
    /// The possible values for this are:
    /// 1 = MessageFromBuyer
    /// 2 = MessageFromSeller
    /// 3 = Notifications
    /// 4 = Reminders
    /// 5 = ReplyToRemindersOrNotifications
    /// 6 = Welcome
    /// 7 = MessageFromEO
    /// 8 = MessageFromEA
    /// 9 = MessageFromFASTUser
    ///10 = MessageFromREAgent
    /// </summary>
    public enum MessageCategoryType
    {
        MessageFromSP = 100,
        MessageSentByFASTuser = 111,
        MessageReceivedfromBuyer = 102,
        MessageReceivedfromSeller = 103,
        MessageReceivedfromBuyerReAgent = 104,
        MessageReceivedfromSellerReAgent = 105,
        MessageReceivedfromBuyerTC = 106,
        MessageReceivedfromSellerTC = 107,

        WelcomeMessage = 200,
        ReplyonAWMbyFASTuser = 211,
        BuyersReplyOnWelcomeMessage = 202,
        SellersReplyOnWelcomeMessage = 203,
        BuyerReAgentReplyOnWelcomeMessage = 204,
        SellerReAgentReplyOnWelcomeMessage = 205,
        BuyerTCReplyOnWelcomeMessage = 206,
        SellerTCReplyOnWelcomeMessage = 207,

        Notification = 300,
        ReplyOnANotificationByFASTUser = 311,
        BuyersReplyOnNotification = 302,
        SellersReplyOnNotification = 303,
        BuyerReAgentReplyOnNotification = 304,
        SellerReAgentReplyOnNotification = 305,
        BuyerTCReplyOnNotification = 306,
        SellerTCReplyOnNotification = 307,

        Reminder = 400,
        ReplyOnReminderByFastUser = 411,
        BuyersReplyOnReminder = 402,
        SellersReplyOnReminder = 403,
        BuyerReAgentReplyOnReminder = 404,
        SellerReAgentReplyOnReminder = 405,
        BuyerTCReplyOnReminder = 406,
        SellerTCReplyOnReminder = 407,
    }

    public enum FASTRegions
    {
        Southwest = 101,
        QASANDPOINTREGION = 189,
        East = 643,
        Northwest = 644,
        California = 410,
        North_Central = 641,
    }

    public enum ConsumerRegions
    {
        Southwest = 101,
        QASANDPOINTREGION = 189,
        East = 643,
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

    public enum ResidentialTransactionTypes
    {
        EquityLoan = 4,
        Refinance = 3,
        REOSaleWMortgage = 1656,
        REOSaleCash = 1657,
        SaleWConstructionLoan = 2994,
        SaleWMortgage = 1,
        SaleCash = 2,
        SaleExchange = 10,
        ShortSaleWMortgage = 1842,
        ShortSaleCash = 1843,
        ConstructionFinance = 2997
    }

    public enum NewHomesTransactionTypes
    {
        REOSaleWMortgage = 1656,
        REOSaleCash = 1657,
        SaleWConstructionLoan = 2994,
        SaleWMortgage = 1,
        SaleCash = 2,
        SaleExchange = 10,
        ShortSaleWMortgage = 1842,
        ShortSaleCash = 1843,
        ConstructionFinance = 2997
    }

    public enum BorrowerTransactionTypes
    {
        EquityLoan = 4,
        Refinance = 3,
        ConstructionFinance = 2997
    }

    public enum CommercialTransactionTypes
    {
        EquityLoan = 4,
        Refinance = 3,
        REOSaleWMortgage = 1656,
        REOSaleCash = 1657,
        SaleWConstructionLoan = 2994,
        SaleWMortgage = 1,
        SaleCash = 2,
        SaleExchange = 10,
        ShortSaleWMortgage = 1842,
        ShortSaleCash = 1843,
        ConstructionFinance = 2997
    }

    public enum EventTypeIds
    {
        Opened = 14,
        Closed = 11
    }

    public enum TypeCdID
    {
        Email = 127,
        HomePhone = 121,
        Cellular = 125,
        BusinessPhone = 122
    }

    public enum BrandId
    {
        RegencyEscrow = 4,
        HeritageEscrow = 8,
        TitleVest = 9,
        TitleVestAgencyOfTexas = 10,
        DonaAna = 12,
        RepublicTitle = 17,
        ReunionTitle = 18
    }

    public enum RoleTypes
    {
        BuyerAgent = 685,
        SellerAgent = 686,
        BuyerBroker = 323,
        SellerBroker = 326,
        SellerTC = 2371,
        BuyerTC = 2368,
        All = 0
    }

    public enum BusinessSegment
    {
        RESIDENTAL = 839,
        NEWHOME = 1834,
        COMMERCIAL = 838
    }

    public enum ExistingIdaasUserStatus
    {
        NotExists = 0,
        Exists = 1,
        EulaAccepted = 2,
        ConsumerVerified = 3,
        Imported = 4
    }

    public enum ExceptionUIEventType
    {
        None = 0,
        NotifiedIdaas = 1,
        UpdatedSPData = 2
    }

    public enum ContactContextTypeCdId
    {
        None = 0,
        Spouse1 = 190,
        Spouse2 = 3369
    }

    public enum IntegratedOrderStatus
    {
        NotProcessed = 0,
        InProcess = 1,
        Processed = 2,
        Failed = 3
    }

    public enum EventHandlers
    {
        FASTChangeNotificationEventHandler = 14
    }

    public enum WorkflowTriggerDocuments
    {
        CommissionInstructionsSelling = 2005,
        CommissionInstructionsListing = 2004
    }
    public enum NotificationTemplates
    {
        CustomerNotificationTemplate = 10101,
        CustomerWelcomeTemplate = 10102,        
        FeedbackTemplate = 10108,
        PersonalInfoUpdateNotifyIDaaSTemplate = 10109,
        ProfileSettingsChangesTemplate = 10115
    }

    public static class BuyerSellerTypeExtensions
    {
        public static bool IsTrustOrBusinessEntity(this BuyerSellerType buyerSellerType)
        {
            switch (buyerSellerType)
            {
                case BuyerSellerType.Trust:
                case BuyerSellerType.BusinessEntity:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsIndividualOrHusbandAndWife(this BuyerSellerType buyerSellerType)
        {
            switch (buyerSellerType)
            {
                case BuyerSellerType.Individual:
                case BuyerSellerType.HusbandAndWife:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsSellerTypeREAgent(this ConsumerType consumerType)
        {
            switch (consumerType)
            {
                case ConsumerType.SellerAgent:
                case ConsumerType.SellerBroker:
                case ConsumerType.SellerTC:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsBuyerTypeREAgent(this ConsumerType consumerType)
        {
            switch (consumerType)
            {
                case ConsumerType.BuyerAgent:
                case ConsumerType.BuyerBroker:
                case ConsumerType.BuyerTC:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsReAgentByBuyerSellerType(this BuyerSellerType buyerSellerType)
        {
            switch (buyerSellerType)
            {
                case BuyerSellerType.Agent:
                case BuyerSellerType.Broker:
                case BuyerSellerType.TransactionCoordinator:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsReAgentByConsumerType(this ConsumerType consumerType)
        {
            switch (consumerType)
            {
                case ConsumerType.BuyerAgent:
                case ConsumerType.BuyerBroker:
                case ConsumerType.BuyerTC:
                case ConsumerType.SellerAgent:
                case ConsumerType.SellerBroker:
                case ConsumerType.SellerTC:
                    return true;

                default:
                    return false;
            }
        }

        public static ConsumerType ConvertConsumerType(this ConsumerType consumerType)
        {
            if (consumerType == ConsumerType.BuyerAgent || consumerType == ConsumerType.BuyerTC)
            {
                return ConsumerType.Buyer;
            }
            else if (consumerType == ConsumerType.SellerAgent || consumerType == ConsumerType.SellerTC)
            {
                return ConsumerType.Seller;
            }
            else
                return consumerType;
        }

        public static string GetRecipientTypeByConsumerType(this ConsumerType consumerType)
        {
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["EnableRecipientsType"] ?? "false"))
            {
                switch (consumerType)
                {
                    case ConsumerType.Buyer:
                    case ConsumerType.Borrower:
                    case ConsumerType.BuyerAgent:
                    case ConsumerType.BuyerBroker:
                    case ConsumerType.BuyerTC:
                        return "BUYER";

                    case ConsumerType.Seller:
                    case ConsumerType.SellerAgent:
                    case ConsumerType.SellerBroker:
                    case ConsumerType.SellerTC:
                        return "SELLER";

                    default:
                        return "NONE";
                }
            }
            else
            {
                switch (consumerType)
                {
                    case ConsumerType.Buyer:
                    case ConsumerType.Borrower:
                        return "BUYER";

                    case ConsumerType.BuyerAgent:
                    case ConsumerType.BuyerBroker:
                        return "BuyerAgent";

                    case ConsumerType.BuyerTC:
                        return "BuyerTc";

                    case ConsumerType.Seller:
                        return "SELLER";

                    case ConsumerType.SellerAgent:
                    case ConsumerType.SellerBroker:
                        return "SellerAgent";

                    case ConsumerType.SellerTC:
                        return "SellerTc";

                    default:
                        return "NONE";
                }
            }
        }
    }
}
