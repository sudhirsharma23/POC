using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLog.Common
{
    public class Settings
    {
        public static string ConnectionString;
        public static string DatabaseName;
        public static string IISLogREPO;
        public static string IISLogFilePreFix;
        public static string ServerRole;
        public static string ServerPrefix;
        public static string IISLogSourceFolderList;
        public static string ReportFolder;
        public static string TransactionCountTemplate;
        public static string ReportDate;
        public static string DateFormat;
        public static string CreateTableSQL;
        public static bool CopyIISLogFile = true;
        public static bool ImportIISLogFile = true;
        public static bool RunReport = true;
        public static string SubTitle;
        public static string DataLake;
    }
}
