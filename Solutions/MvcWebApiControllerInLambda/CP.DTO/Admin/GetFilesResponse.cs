using System.Runtime.Serialization;

namespace CP.DTO.Admin
{
    [DataContract]
    public class GetFilesResponse
    {
        [DataMember]
        public File FastFileData { get; set; }
        [DataMember]
        public File SPFileData { get; set; }
    }
}