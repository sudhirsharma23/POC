using CP.DTO.FastFileData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
   public class FileInfoDto
    {
        public int FileId { get; set; }

        public string FileNumber { get; set; }
        public int FileStatus { get; set; }

        public int RegionId { get; set; }

        public string EscrowOfficerObjectCode { get; set; }
        public int OwningOfficeId { get; set; }
        public string OwningOfficeName{ get; set; }
        public string OwningOfficePhone { get; set; }

        public string AssistantName { get; set; }
        public string AssistantObjectCode { get; set; }
        public DateTime? EstimatedClosingDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public  string Amount { get; set; }

        public string LoanAmount { get; set; }
        public Address Address { get; set; }

        public string EscrowOfficerName { get; set; }
        public  string LenderName { get; set; }
    }
}
