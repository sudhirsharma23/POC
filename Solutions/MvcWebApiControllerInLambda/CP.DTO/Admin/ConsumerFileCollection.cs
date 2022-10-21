using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CP.DTO.Admin
{
    public class ConsumerFileCollection
    {
        public List<MFAFASTConsumerDetails> mfaFASTConsumer { get; set; }
    }

    public class MFAFASTConsumerDetails
    {
        public int ConsumerTypeId { get; set; }
        public int PrincipalID { get; set; }

        public string UserName { get; set; }

        public string MFAEmail { get; set; }

        public string Status { get; set; }
        public string LastEmailSent { get; set; }

        public string FastFileNo { get; set; }

        //public string ConsumerType { get; set; }
        public string BuyerSellerType { get; set; }

        public string Consumer { get; set; }

        public string FASTEmail { get; set; }

        public string PropertyType { get; set; }

        public string PropertyAddress { get; set; }

        public bool IsPrimary { get; set; }

        public int ConsumerFileID { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        //public int ConsumerTypeID { get; set; }

        public BuyerSellerType BuyerSellerTypeId { get; set; }

        public int ConsumerFileStatusID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string UserNameSuffix { get; set; }

        public string Identifier { get; set; }

        public string FASTRegion { get; set; }
        public string FASTOfficeName { get; set; }
        public string FASTConsumerType { get; set; }
        public string FASTEscrowOfficer { get; set; }
        public string IDaaSPrecedencePhone { get; set; }
        public string AdminFileStatus { get; set; }
        public bool IsTokenAvailable { get; set; }
        public string LastFileStatusDate { get; set; }
        public string FASTEscrowOfficerEmail { get; set; }
        public string FASTEscrowAssistantEmail { get; set; }
        public string LastSignInDate { get; set; }

        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }

        public bool ShowDisableEsign { get; set; }
        public int FileBusinessPartyId { get; set; }
        public int BusOrgId { get; set; }
        public bool HasLongName { get; set; }
        public int ContactId { get; set; }
        public string GabCode { get; set; }
        public int ExistingIdaasUserStatusId { get; set; }
    }

    public class ConsumerInfoOnFile
    {
        public string Email { get; set; }
        public string FileStatus { get; set; }

        public DateTime? CreatedOn { get; set; }

        //public string Value { get; set; }
        public bool IsPrimary { get; set; }
        public int FastFileId { get; set; }
        public string FastFileNumber { get; set; }
        public int PrincipalId { get; set; }
        public string Name { get; set; }
        public int BuyerSellerTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserNameSuffix { get; set; }
        public int ConsumerFileId { get; set; }
        public string CreatedBy { get; set; }

        public int ConsumerFileStatusId { get; set; }

        //--UA.Username,
        public int AuthSignatureID { get; set; }
        public int ConsumerTypeId { get; set; }

        public string OfficeName { get; set; }
        public string RegionName { get; set; }

        public string EscrowOfficerName { get; set; }
        public int SentEmailCount { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Username { get; set; }
        public Guid IdentityId { get; set; }
        public string AdminFileStatus { get; set; }
        public bool IsTokenAvailable { get; set; }
        public int DataCollectionStartedCount { get; set; }
        public string LastFileStatusDate { get; set; }
        public string EscrowOfficerEmail { get; set; }
        public string EscrowAssistantEmail { get; set; }
        public DateTime? LastSignInDate { get; set; }

        public bool ShowDisableEsign { get; set; }
        public int FileBusinessPartyId { get; set; }
        public int BusOrgId { get; set; }
        public bool HasLongName { get; set; }
        public int ContactId { get; set; }
        public string GabCode { get; set; }
        public int ExistingIdaasUserStatusId { get; set; }
    }

    public class ConsumerFileRequest
    {
        public string fileNo { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int regionID { get; set; }
        public int consumerTypeId { get; set; }
        public int fileStatusId { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string UserName { get; set; }
    }
    [DataContract]
    public class PendingEsignDocs
    {
        [DataMember]
        public int ConsumerFileId { get; set; }
        [DataMember]
        public string FastFileNumber { get; set; }
        [DataMember]
        public Guid? Identity { get; set; }
        [DataMember]
        public string EnvelopeId { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string DocumentName { get; set; }
        [DataMember]
        public int DocumentId { get; set; }
        [DataMember]
        public DateTime? CreatedOn { get; set; }
        [DataMember]
        public DateTime? EsignedOn { get; set; }

        [DataMember]
        public DateTime? StatusChangeDate { get; set; }
    }
}
