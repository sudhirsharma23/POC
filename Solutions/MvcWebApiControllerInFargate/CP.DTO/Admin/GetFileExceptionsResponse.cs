

namespace CP.DTO.Admin
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using System.Runtime.Serialization;
    [DataContract]
    public class GetFileExceptionsResponse
	{
        [DataMember]
		public virtual List<FileException> FileExceptions
		{
			get;
			set;
		}
       
	}
}

