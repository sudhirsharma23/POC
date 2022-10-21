using System.Runtime.Serialization;

namespace CP.DTO.Admin
{    
        [DataContract]
        public enum GetConsumerEscrowOfficesResponseStatus
        {
            [EnumMember]
            Error = -1,

            [EnumMember]
            Successful = 1,

        }
    [DataContract]
    public enum GetConsumerFilesResponseStatus
    {
        [EnumMember]
        Error = -1,

        [EnumMember]
        Successful = 1,

        [EnumMember]
        ExceededMaxCount = 2,
    }
}