namespace CP.DTO.FastFileData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FirstAmerican.Common;
    using System.Configuration;

    public class Consumer : Person
    {
        public virtual Company OutsideTitleCompany { get; set; }
        public virtual List<Company> AttorneyCollection { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual string ConsumerType { get; set; }
        public virtual bool IsSSNOnFile { get; set; }
        public virtual bool IsSpouse { get; set; }
        public virtual bool IsCompletingWorkflow { get; set; }
        public virtual int PrincipalID { get; set; }
        public virtual Address CurrentAddress { get; set; }
        public virtual Address ForwardingAddress { get; set; }
        public virtual string SSN_TIN_Format
        {
            get
            {
                return string.IsNullOrWhiteSpace(_ssn) ? string.IsNullOrWhiteSpace(_tin) ? "N/A" : "TIN" : "SSN";
            }
        }
        public virtual List<CP.DTO.FastFileData.ContactDetail> ContactDetails { get; set; }

        private string _ssn;
        public virtual string SSN
        {
            get { return _ssn; }
            set { _ssn = value; }
            //{
            //    if (Convert.ToBoolean(ConfigurationManager.AppSettings["ShowSSN"]))
            //    {
            //        if (!string.IsNullOrEmpty(value))
            //        {
            //            _ssn = CryptographyManager.DecryptText(value, ConfigurationManager.AppSettings["SecretKey"], ConfigurationManager.AppSettings["SecretIV"]);
            //            if (_ssn != null && _ssn == "000000000")
            //                _ssn = "";
            //        }
            //    }
            //    else
            //        _ssn = value;

            //}
        }

        private string _tin;
        public virtual string TIN
        {
            get { return _tin; }
            set { _tin = value; }
            //{
            //    if (Convert.ToBoolean(ConfigurationManager.AppSettings["ShowSSN"]))
            //    {
            //        if (!string.IsNullOrEmpty(value))
            //        {
            //            _tin = CryptographyManager.DecryptText(value, ConfigurationManager.AppSettings["SecretKey"], ConfigurationManager.AppSettings["SecretIV"]);
            //            if (_tin != null && _tin == "000000000")
            //                _tin = string.Empty;
            //        }
            //    }
            //    else
            //        _tin = value;

            //}
        }
    }

    public enum SSN_TIN_Format
    {
        SSN,
        TIN
    }
}

