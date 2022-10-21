using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class NamingExceptionConsumerFileDto
    {
        public int? fileID { get; set; }
        public string fileNumber { get; set; }
        public string email { get; set; }
        public bool isPrimary { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public int buyerSellerType { get; set; }
        public int regionId { get; set; }
        public string officeObjectCd { get; set; }
        public int? consumerFileStatus { get; set; }
        public string createdBy { get; set; }
        public int? consumerFileId { get; set; }
        public int principalID { get; set; }
        public int? authSignID { get; set; }
        public int? transactionTypeCdID { get; set; }
        public int? businessSegmentCdID { get; set; }
        public string businessPrograms { get; set; }
        public int consumerTypeId { get; set; }
        public string homePhone { get; set; }
        public string workPhone { get; set; }
        public string mobilePhone { get; set; }
        public string escrowOfficerName { get; set; }
        public string officerObjectCD { get; set; }
        public string propertyAddress { get; set; }
        public string propertyCounty { get; set; }
        public int? seqNum { get; set; }
        public DateTime? estSettlementDate { get; set; }
        public DateTime? fileCreatedDate { get; set; }
        public string escrowOfficerEmail { get; set; }
        public bool isBuyerSellerAgentOrBroker { get; set; }
        public string escrowAssistantName { get; set; }
        public string assistantObjectCD { get; set; }
        public string EscrowAssistantEmailId { get; set; }
        public int? FileBusinessPartyID { get; set; }
        public int? contactId { get; set; }
        public int? busOrgId { get; set; }
        public int? isAdHocContact { get; set; }
        public string shortName { get; set; }
        public string additionalContactId { get; set; }
        public string gabCode { get; set; }
        public string propertyAddressLine1 { get; set; }
        public string propertyCity { get; set; }
        public string propertyState { get; set; }

    }
}
