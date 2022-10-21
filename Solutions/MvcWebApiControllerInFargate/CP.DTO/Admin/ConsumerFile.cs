using System.Runtime.Serialization;

namespace CP.DTO.Admin
{
    [DataContract]
    public class ConsumerFile : File
    {
        [DataMember]
        public virtual string UserName
        {
            get;
            set;
        }
        [DataMember]
        public ExceptionUIEventType Event { get; set; }
    }
}

