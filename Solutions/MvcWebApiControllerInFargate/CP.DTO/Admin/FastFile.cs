using System.Runtime.Serialization;
using CP.DTO.Admin.ViewModels;
using File = CP.DTO.Admin.File;

namespace CP.DTO.Admin
{
    [DataContract]
    public class FastFile : File
    {
       
        [DataMember]
        public virtual string EscrowOfficerState
        {
            get;
            set;
        }
        [DataMember]
        public virtual string EscrowOfficerName
        {
            get;
            set;
        }
        [DataMember]
        public virtual string EligibilityDate
        {
            get;
            set;
        }
        [DataMember]
        public virtual MismatchBy MismatchBy
        {
            get;
            set;
        }
        [DataMember]
        public ExceptionUIEventType Event { get; set; }
        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public string EscrowOfficerEmail
        {
            get;
            set;
        }

        [DataMember]
        public string EscrowAssistantEmail
        {
            get;
            set;
        }

        [DataMember]
        public int PrincipalId { get; set; }

        [DataMember]
        public int? FileBusinessPartyID { get; set; }

        public int RegionId { get; set; }

        [DataMember]
        public bool IsNamingException { get; set; }

    }
}

