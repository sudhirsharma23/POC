//------------------------------------------------------------------------------
namespace CP.DTO.FastFileData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Address
    {
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string AddressLine3 { get; set; }
        public virtual string AddressLine4 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual string Country { get; set; }
        public virtual string County { get; set; }


    }
}

