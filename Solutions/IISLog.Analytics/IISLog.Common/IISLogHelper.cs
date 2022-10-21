using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace IISLog.Common
{
    class IISLogHelper
    {

        public static void Copy(string rootFolder, string[] iisLogSourceFolderArray)
        {
            DateTime datetime = GetReportDateTime();

            string logFileName = GetTodaysIISLogFileName(datetime);
            string serverFolder = rootFolder + GetINTFolderName(datetime);

            int count = 1;
            foreach (string srvr in iisLogSourceFolderArray)
            {
                try
                {
                    Console.WriteLine($"Copying {srvr + logFileName}");
                    if (Directory.Exists(serverFolder) == false)
                        Directory.CreateDirectory(serverFolder);
                    System.IO.File.Copy(srvr + logFileName, serverFolder + "\\" + count + "_" + logFileName, true);
                    count++;
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static DateTime GetReportDateTime()
        {
            string reportDate = Settings.ReportDate;
            string dateFormat = Settings.DateFormat;
            DateTime datetime = DateTime.Now;
            if (!string.IsNullOrEmpty(reportDate))
            {
                datetime = DateTime.Parse(reportDate);
            }
            return datetime;
        }

        public static string GetINTFolderName(DateTime date)
        {
            string role = "INT";
            if (!string.IsNullOrEmpty(Settings.ServerRole))
            {
                role = Settings.ServerRole;
            }
            
            return role+"_" + date.Month + "_" + date.Day;    
        }

        private static string GetTodaysIISLogFileName(DateTime date)
        {
            string day = Convert.ToString(date.Day);
            string month = GetMonthString(date.Month);
            string year = Convert.ToString(date.Year - 2000);

            if (Convert.ToInt32(day) < 10)
            {
                day = "0" + day;
            }

            string filePrefix = Settings.IISLogFilePreFix;
            if (!string.IsNullOrEmpty(Settings.IISLogFilePreFix))
            {
                filePrefix = Settings.IISLogFilePreFix;
            }
            StringBuilder nameBuilder = new StringBuilder(filePrefix);

            nameBuilder.Append(year).Append(month).Append(day).Append(".log");

            return nameBuilder.ToString();
        }

        private static string GetMonthString(int m)
        {
            if (m < 10)
            {
                return "0" + m;
            }
            return "" + m;
        }
    }
}
