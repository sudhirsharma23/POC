
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CP.DTO.Admin.ViewModels
{
    public class FileExceptionsViewModel
    {
        public virtual IEnumerable<FileException> FileExceptions
        {
            get;
            set;
        }
    }
    public class FileException
    {
        public virtual FastFile FastFile
        {
            get;
            set;
        }

        public virtual IEnumerable<ConsumerFile> ConsumerFiles
        {
            get;
            set;
        }

    }
    public class FastFile : File
    {


        public virtual string EscrowOfficerState
        {
            get;
            set;
        }

        public virtual string EscrowOfficerName
        {
            get;
            set;
        }

        public virtual string EligibilityDate
        {
            get;
            set;
        }

        public virtual MismatchBy MismatchBy
        {
            get;
            set;
        }
        public ExceptionUIEventType Event { get; set; }
        public string Comments { get; set; }
        public string EscrowOfficerEmail { get; set; }
        public string EscrowAssistantEmail { get; set; }
        public bool SpouseOnRegistrationScreen { get; set; }
        public bool IsNamingException { get; set; }
        public int? FileBusinessPartyID { get; set; }

    }
    public enum MismatchBy
    {
        None,
        FirstName,
        LastName,
        Email,
        MobilePhone,
        HomePhone,
        WorkPhone,
    }
    public class ConsumerFile : File
    {
        public virtual string UserName
        {
            get;
            set;
        }
        public ExceptionUIEventType Event { get; set; }
    }
    public class File
    {
        public virtual string FileNumber
        {
            get;
            set;
        }
        public int ConsumerFileId { get; set; }
        public virtual string FirstName
        {
            get;
            set;
        }

        public virtual string LastName
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string MobilePhone
        {
            get;
            set;
        }

        public virtual string HomePhone
        {
            get;
            set;
        }

        public virtual string WorkPhone
        {
            get;
            set;
        }

        public virtual ConsumerType Type
        {
            get;
            set;
        }
        public virtual BuyerSellerType BuyerSellerType { get; set; }

        public virtual string PhoneAuthChallenge { get; set; }

        public virtual string UserNameSuffix { get; set; }

    }

}
