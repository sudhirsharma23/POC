using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CP.DTO.Admin
{
    [DataContract]
    public class GetConsumerEscrowOfficesResponse
    {
        [DataMember]
        public IEnumerable<EscrowRegions> regions { get; set; }

        [DataMember]
        public GetConsumerEscrowOfficesResponseStatus status { get; set; }
    }

    public class EscrowRegions
    {
        [DataMember]
        public string regionName { get; set; }

        [DataMember]
        public int regionID { get; set; }
    }

    //[DataContract]
    //public class EscrowRegions
    //{
    //    [DataMember]
    //    public string regionName { get; set; }

    //    [DataMember]
    //    public int regionID { get; set; }
    //}
}