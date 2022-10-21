using System.Collections.Generic;
using System.Runtime.Serialization;
using CP.DTO.Admin.ViewModels;

namespace CP.DTO.Admin
{
    [DataContract]
    public class FileException
	{
        [DataMember]
        public virtual FastFile FastFile
		{
			get;
			set;
		}
        [DataMember]
        public virtual IEnumerable<ConsumerFile> ConsumerFiles
		{
			get;
			set;
		}

	}
}

