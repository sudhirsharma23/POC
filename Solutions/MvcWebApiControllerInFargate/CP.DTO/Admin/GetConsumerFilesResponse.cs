using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CP.DTO.Admin
{
    [DataContract]
    public class GetConsumerFilesResponse
    {
        [DataMember]
        public IEnumerable<ConsumerInfo> ConsumerInfo { get; set; }

        [DataMember]
        public GetConsumerFilesResponseStatus Status { get; set; }
        [DataMember]
        public IEnumerable<OptOutUserInfo> OptOutUserInfo { get; set; }


    }
    [DataContract]
    public class OptOutUserInfo
    {
        [DataMember]
        public int OptedOutusersId { get; set; }
        [DataMember]
        public string RegionName { get; set; }
        [DataMember]
        public string GAB { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }       
        [DataMember]
        public string CellPhone { get; set; }
        [DataMember]
        public string BusPhone { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime? CreatedOn { get; set; }


    }

    [DataContract]
    public class ConsumerInfo
    {
        [DataMember]
        public string AdminFileStatus { get; set; }

        [DataMember]
        public bool IsEsignDocsAvailable { get; set; }

        [DataMember]
        public bool IsAdminMatched { get; set; }
        [DataMember]
        public bool IsMultiFileUser { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string EmailLastSent { get; set; }

        [DataMember]
        public string FastFileNo { get; set; }

        [DataMember]
        public string ConsumerType { get; set; }

        [DataMember]
        public string Consumer { get; set; }

        [DataMember]
        public string FASTEmail { get; set; }

        [DataMember]
        public string PropertyType { get; set; }

        [DataMember]
        public string PropertyAddress { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public int ConsumerFileId { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string CreatedOn { get; set; }
        [DataMember]
        public string LastLogin { get; set; }
        [DataMember]
        public int ConsumerTypeID { get; set; }

        [DataMember]
        public int ConsumerFileStatusID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public string FASTRegion { get; set; }


        [DataMember]
        public string FASTOfficeName { get; set; }

        [DataMember]
        public string FASTConsumerType { get; set; }
        [DataMember]
        public string FASTEscrowOfficer { get; set; }

        [DataMember]
        public string IDaaSPrecedencePhone { get; set; }

        [DataMember]
        public string HomePhone { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string MobilePhone { get; set; }

        [DataMember]
        public BuyerSellerType BuyerSellerType { get; set; }
        [DataMember]
        public bool IsTokenAvailable { get; set; }
        [DataMember]
        public string LastFileStatusDate { get; set; }
        [DataMember]
        public string FASTEscrowOfficerEmail { get; set; }

        [DataMember]
        public string FASTEscrowAssistantEmail { get; set; }

        [DataMember]
        public bool ShowDisableEsign { get; set; }
        [DataMember]
        public string UserNameSuffix { get; set; }
        [DataMember]
        public int FileBusinessPartyId { get; set; }
        [DataMember]
        public int BusOrgId { get; set; }
        [DataMember]
        public bool HasLongName { get; set; }
        [DataMember]
        public int ContactId { get; set; }
        [DataMember]
        public string GabCode { get; set; }
        [DataMember]
        public int ExistingIdaasUserStatusId { get; set; }        
    }
}