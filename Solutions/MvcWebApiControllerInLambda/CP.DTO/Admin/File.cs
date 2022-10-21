using System.Runtime.Serialization;

namespace CP.DTO.Admin
{
    [DataContract]
    public class File
    {
        [DataMember]
        public virtual string FastFileNumber
        {
            get;
            set;
        }

        [DataMember]
        public int ConsumerFileId { get; set; }
        [DataMember]
        public virtual string FirstName
        {
            get;
            set;
        }

        [DataMember]
        public virtual string LastName
        {
            get;
            set;
        }
        [DataMember]
        public virtual string Email
        {
            get;
            set;
        }
        [DataMember]
        public virtual string MobilePhone
        {
            get;
            set;
        }
        [DataMember]
        public virtual string HomePhone
        {
            get;
            set;
        }
        [DataMember]
        public virtual string WorkPhone
        {
            get;
            set;
        }
        [DataMember]
        public virtual ConsumerType Type
        {
            get;
            set;
        }
        [DataMember]
        public virtual BuyerSellerType BuyerSellerType { get; set; }

        [DataMember]
        public virtual string PhoneAuthChallenge { get; set; }
        [DataMember]
        public virtual string UserNameSuffix { get; set; }
    }
}

