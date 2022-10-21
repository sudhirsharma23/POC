using System;

namespace IISLog.Common
{
    public class Builder
    {
        public static void Build()
        {
            try
            {
                var config = new BaseConfiguration();
                var iisLogRepo = config.GetAppSetting("iisLogRepo");// @"C:\Documents\IISLogs\";
                var iisLogSourceFolderList = config.GetAppSetting("iisLogSourceFolderList");// @"\\Snavpiisfast005\w3svc1\;\\Snavpiisfast006\w3svc1\;\\Snavpiisfast010\w3svc1\;\\Snavpiisfast011\w3svc1\;\\Snavpiisfast015\w3svc1\;\\Snavpiisfast026\w3svc1\;\\Snavpiisfast037\w3svc1\;\\Snavpiisfast043\w3svc1\;\\Snavpiisfast048\w3svc1\;\\Snavpiisfast050\w3svc1\;\\Snavpiisfast053\w3svc1\;\\Snavpiisfast061\w3svc1\"; //\\Snavpintfast011\w3svc1\;
                var iisLogSourceFolderArray = iisLogSourceFolderList.Split(';');
                var iisLogFilePrefix = "u_ex";
                var serverRole = config.GetAppSetting("serverRole");
                var serverPrefix = config.GetAppSetting("serverPrefix");// $"SNAVP{serverRole}FAST";
                var dateFormat = config.GetAppSetting("dateFormat");// "MM -dd-yyyy";
                var reportDate = DateTime.Now.ToString(dateFormat);
                if (!string.IsNullOrEmpty(config.GetAppSetting("reportDate")))
                {
                    reportDate = config.GetAppSetting("reportDate");
                }
                var reportFolder = config.GetAppSetting("reportFolder");// @"C:\Documents\IISLogs\ReportFolder\";
                var templateFilePath = config.GetAppSetting("templateFilePath");// @"C:\Documents\IISLogs\Templates\"+$"{serverRole}_v2Good_04_23_2015.html";
                Settings.ReportFolder = reportFolder;
                Settings.TransactionCountTemplate = templateFilePath;
                Settings.ReportDate = reportDate;
                Settings.DateFormat = dateFormat;
                Settings.IISLogFilePreFix = iisLogFilePrefix;
                Settings.ServerRole = serverRole;
                Settings.ServerPrefix = serverPrefix;
                Settings.IISLogSourceFolderList = iisLogSourceFolderList;
                Settings.SubTitle = config.GetAppSetting("subTitle");
                Settings.DataLake = config.GetAppSetting("dataLake");
                if (Settings.CopyIISLogFile)
                {
                    IISLogHelper.Copy(iisLogRepo, iisLogSourceFolderArray);
                }

                if (Settings.ImportIISLogFile)
                {
                    SQLHelper.Import(iisLogRepo);
                }

                Console.WriteLine("Import successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
