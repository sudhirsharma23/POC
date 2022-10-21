using System;
using System.Collections.Generic;


namespace CP.DTO.Admin.ViewModels
{

    

    public class ConsumersViewModel
    {
  
        public IEnumerable<ConsumerRegions> EscrowRegions { get; set; }
        public IEnumerable<ConsumerDetails> ConsumerDetails { get; set; }
        public IEnumerable<OptedOutConsumers> OptedOutConsumers { get; set; }
        public string Status { get; set; }
    }
    public class OptedOutConsumers
    {
        public int OptedOutUsersId { get; set; }
        public string RegionName { get; set; }
        public string Name { get; set; }      
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string BusinessPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GAB { get; set; }
        public string Username { get; set; }      
        public DateTime? CreatedOn { get; set; }
    }
    public class ConsumerRegions
    {
        public int RegionId { get; set; }

        public string RegionName { get; set; }
    }

    public class AutoRegistrationState
    {
        public bool SelectAllBuyer { get; set; }
        public bool SelectAllSeller { get; set; }
        public bool SelectAllBorrower { get; set; }
        public bool SelectAllAgent { get; set; }
        public bool SelectAllTC { get; set; }       
        
        public List<ConsumerStates> states { get; set; }
           
    }

    public class BannerMessageDetails
    {
        public bool SelectAllScreens { get; set; }
        public List<BannerDisplayScreens> ScreenDetails { get; set; }
        public string BannerMessage { get; set; }

    }


    public class ApplicationSettings
    {
        public AutoRegistrationState AutoRegistrationState { get; set; }
        public BannerMessageDetails BannerMessageDetails { get; set; }
        public string AchIsEnabled { get; set; } 
    }



    public class ConsumerDetails
    {
        public bool IsEsignDocsAvailable { get; set; }
        public string AdminFileStatus { get; set; }
        public bool IsAdminMatched { get; set; }
        public bool IsMultiFileUser { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Status { get; set; }
        public string EmailLastSent { get; set; }

        public string FastFileNo { get; set; }

        public string ConsumerType { get; set; }

        public string FASTOfficeName { get; set; }
        public string FASTRegion { get; set; }
        public string Consumer { get; set; }

        public string UserNameSuffix { get; set; }
        public string FASTEmail { get; set; }

        public string PropertyAddress { get; set; }

        public bool IsPrimary { get; set; }

        public int ConsumerFileId { get; set; }
        public string CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int ConsumerTypeId { get; set; }

        public int ConsumerFileStatusId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool DisplayNotifications { get; set; }

        public string Identifier { get; set; }

        public string EscrowOfficer { get; set; }

        public string IDaaSPrecedencePhone { get; set; }

        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }

        public BuyerSellerType BuyerSellerType { set; get; }

        public int BuyerSellerTypeId { set; get; }
        public bool IsTokenAvailable { get; set; }
        public string LastFileStatusDate { get; set; }
        public string EscrowOfficerEmail { get; set; }
        public string EscrowAssistantEmail { get; set; }
        public string LastLogin { get; set; }
        public bool ShowDisableEsign { get; set; }
        public int FileBusinessPartyId { get; set; }
        public int BusOrgId { get; set; }
        public bool HasLongName { set; get; }
        public int ContactId { get; set; }
        public string GabCode { get; set; }
        public int ExistingIdaasUserStatusId { get; set; }

    }

    public class EmailLinkHistory
    {
       
        public int ConsumerFileHistoryId { get; set; }

      
        public int ConsumerFileId { get; set; }

       
        public string TokenInfo { get; set; }

      
        public DateTime EmailSentDate { get; set; }
    }
    public class ACHEnabledModel
    {
        public int ACHEnabled { get; set; }
    }
}
