

namespace CP.DTO.Admin
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using System.Runtime.Serialization;

    [DataContract]
    public enum MismatchBy
	{
        [EnumMember]
        None,
        [EnumMember]
        FirstName,
        [EnumMember]
        LastName,
        [EnumMember]
        Email,
        [EnumMember]
        MobilePhone,
        [EnumMember]
        HomePhone,
        [EnumMember]
        WorkPhone,
	}
}
