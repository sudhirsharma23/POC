using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class ConsumerInfoDto
    {
        public string FastRegion { get; set; }
        public DateTime? FileClosedOn { get; set; }
        public int ConsumerFileId { get; set; }
        public int FastFileId { get; set; }
        public string FastFileNumber { get; set; }
        public string Email { get; set; }
        public string ConsumerTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserNameSuffix { get; set; }
        public DateTime? FileCreatedDate { get; set; }
        public DateTime? EstSettlementDate { get; set; }
        public ConsumerType ConsumerType { get; set; }
        public bool IsFileExpired { get; set; }
        public string PropertyAddressDescription { get; set; }
        public string PropertyCounty { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public int FASTBuyerSellerTypeId { get; set; }
        public int PrincipalId { get; set; }
        public int SeqNum { get; set; }
        public bool IsPrimary { get; set; }
        public ConsumerFileStatus ConsumerFileStatus { get; set; }
        public string WelcomeMessage { get; set; }
        public string State { get; set; }
        public int FastBusinessSegmentId { get; set; }
        public bool ShowSecondaryESign { get; set; }
        public string EnvelopeToBeESigned { get; set; }
        public string IdentityId { get; set; }
        public int BUID { get; set; }
        public ExistingIdaasUserStatus ExistingIdaasUserStatusId { get; set; }
        public bool QACompleted { get; set; }
        public string ViewStatus
        {
            get
            {
                return this.ConsumerFileStatus == ConsumerFileStatus.FileClosed ? "Closed" : "Open";
            }
        }

        public int? FileBusinessPartyId { get; set; }
        public int? BusOrgId { get; set; }
        public int? ContactId { get; set; }

        public int? IsAdHocContact { get; set; }
        public string AdditionalContactId { get; set; }

        public DateTime? AccountCreatedDate { get; set; }
        public string CssClass { get; set; }

        public string AdminFileStatus { get; set; }
        public int LandedToDashboard { get; set; }
        public bool ShowFeedback { get; set; }
        public string ShortName { get; set; }
        public string IdToken { get; set; }
        public string PhoneAuthChallenge { get; set; }
        public string ZenDeskEnv { get; set; }
        public string AchDisplayMsg { get; set; }
    }
}
