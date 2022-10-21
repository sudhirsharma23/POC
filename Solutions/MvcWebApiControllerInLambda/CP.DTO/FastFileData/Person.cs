namespace CP.DTO.FastFileData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string TrustName { get; set; }
        public virtual string TrustShortName { get; set; }
        public virtual string TrustDated { get; set; }
        public virtual string TrustNumber { get; set; }
        public virtual string StateOfIncorporation { get; set; }
        public virtual string EntityType { get; set; }
    }
}

