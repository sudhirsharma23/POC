using System;
using System.Runtime.Serialization;

namespace CP.DTO.Admin
{
    [DataContract]
    public class GetConsumerFilesRequest
    {
        [DataMember]
        public string fileNo { get; set; }      
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string email { get; set; }          
        [DataMember]
        public int regionID { get; set; }
        [DataMember]
        public int consumerTypeId { get; set; }
        [DataMember]
        public int fileStatusId { get; set; }
        [DataMember]
        public DateTime? fromDate { get; set; }
        [DataMember]
        public DateTime? toDate { get; set; }

        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string cellPhone { get; set; }
        [DataMember]
        public string businessPhone { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string GAB { get; set; }

    }
}