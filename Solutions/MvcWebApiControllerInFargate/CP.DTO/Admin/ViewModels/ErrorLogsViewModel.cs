using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Admin.ViewModels
{
    public class ErrorLogsViewModel
    {
        public IEnumerable<ErrorLog> ErrorLogs { get; set; }     
    }

    public class ErrorLog
    {
        public int CPExceptionLogId { get; set; }
        public string UniqueId { get; set; }
        public string ErrorMessage { get; set; }
        public string Exception { get; set; }
        public string CreatedOn { get; set; }
        public string MethodName { get; set; }
        public string ProcessName { get; set; }
        public string ServerName { get; set; }
    }
}
