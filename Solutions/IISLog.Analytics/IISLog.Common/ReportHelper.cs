using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace IISLog.Common
{
    class ReportHelper
    {

        public static void REPReport(string connectionString)
        {

            string totalHits = "0";// REPReportHelper.RunTransactionCountReport(connectionString);
            string countByService = RunTransactionCountByServiceReportNDLV(connectionString);
            string countByHour = RunTransactionCountHourlyReport(connectionString);
            string ServerData = RunHitsCountByServer(connectionString);

            string reportFolder = GetReportFolder(Settings.ReportFolder);
            string templateFilePath = Settings.TransactionCountTemplate;
            string templateFileContent = System.IO.File.ReadAllText(templateFilePath);
            string dateString = IISLogHelper.GetReportDateTime().ToString("D");
            templateFileContent = templateFileContent.Replace("{TotalHits}", totalHits);
            templateFileContent = templateFileContent.Replace("{HourlyData}", countByHour);
            templateFileContent = templateFileContent.Replace("{Date}", dateString);
            templateFileContent = templateFileContent.Replace("{ServiceData}", countByService);
            templateFileContent = templateFileContent.Replace("{ServerData}", ServerData);
            dateString = IISLogHelper.GetReportDateTime().ToString(Settings.DateFormat);
            System.IO.File.WriteAllText(reportFolder + dateString + ".html", templateFileContent);
        }


        public static void NDLVReport(string connectionString)
        {

            string totalHits = RunTransactionCountReport(connectionString);
            string countByService = RunTransactionCountByServiceReportNDLV(connectionString);
            string countByHour = RunTransactionCountHourlyReport(connectionString);
            string ServerData = RunHitsCountByServer(connectionString);

            string reportFolder = GetReportFolder(Settings.ReportFolder);
            string templateFilePath = Settings.TransactionCountTemplate;
            string templateFileContent = System.IO.File.ReadAllText(templateFilePath);
            string dateString = IISLogHelper.GetReportDateTime().ToString("D");
            templateFileContent = templateFileContent.Replace("{TotalHits}", totalHits);
            templateFileContent = templateFileContent.Replace("{HourlyData}", countByHour);
            templateFileContent = templateFileContent.Replace("{Date}", dateString);
            templateFileContent = templateFileContent.Replace("{ServiceData}", countByService);
            templateFileContent = templateFileContent.Replace("{ServerData}", ServerData);
            dateString = IISLogHelper.GetReportDateTime().ToString(Settings.DateFormat);
            System.IO.File.WriteAllText(reportFolder + dateString + ".html", templateFileContent);
        }

        public static void Report(string connectionString)
        {
            if (Settings.ServerRole.Equals("NDLV"))
            {
                NDLVReport(connectionString);
                return;
            }

            Console.WriteLine("Building Report");
            string countByApplication = RunTransactionCountByApplicationReport(connectionString);

            string countByHour = RunTransactionCountHourlyReport(connectionString);

            string totalHits = RunTransactionCountReport(connectionString);

            string countByService = "";
            string ApplicationServiceData = "";
            if (Settings.ServerRole.Equals("INT"))
            {
                countByService = RunTransactionCountByServiceReport(connectionString);
                //ApplicationServiceData = RunTransactionDetailsByApplicationService(connectionString);
            }
            else if (Settings.ServerRole.Equals("IIS"))
            {
                countByService = RunIISTransactionCountByServiceReport(connectionString);
            }
            string slowTrasactionData = RunSlowTransactionCountHourlyReport(connectionString);

            string ServerData = RunHitsCountByServer(connectionString);

            string reportFolder = GetReportFolder(Settings.ReportFolder);
            string templateFilePath = Settings.TransactionCountTemplate;
            string templateFileContent = System.IO.File.ReadAllText(templateFilePath);
            string dateString = IISLogHelper.GetReportDateTime().ToString("D");
            templateFileContent = templateFileContent.Replace("{Web Service}", $"{Settings.ServerRole} Servers");
            templateFileContent = templateFileContent.Replace("{TotalHits}", totalHits);
            templateFileContent = templateFileContent.Replace("{HourlyData}", countByHour);
            templateFileContent = templateFileContent.Replace("{ApplicationData}", countByApplication);
            templateFileContent = templateFileContent.Replace("{Date}", dateString);
            templateFileContent = templateFileContent.Replace("{ServiceData}", countByService);
            templateFileContent = templateFileContent.Replace("{ApplicationServiceData}", ApplicationServiceData);
            templateFileContent = templateFileContent.Replace("{ServerData}", ServerData);
            templateFileContent = templateFileContent.Replace("{HourlyLongRequest}", slowTrasactionData);
            dateString = IISLogHelper.GetReportDateTime().ToString(Settings.DateFormat);
            System.IO.File.WriteAllText(reportFolder + dateString + ".html", templateFileContent);
            System.IO.File.WriteAllText(reportFolder + dateString + ".txt", totalHits+@"\n"+ServerData);
            var reportTitle = dateString;
            if (!string.IsNullOrEmpty(Settings.SubTitle))
            {
                reportTitle += $"_{Settings.SubTitle}";
            }
            System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\UsageReport\"+$"{Settings.ServerRole}\\" + dateString + ".html", templateFileContent);
        }

        public static string RunTransactionCountReport(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                string command = String.Format("select COUNT(*) from {0} where cs_uri_stem !='/'", tableName);

                sqlCommand.CommandText = command;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                try
                {
                    StringBuilder builder = new StringBuilder();
                    int value = 0;
                    while (reader.Read())
                    {
                        value = (Int32)reader[0];
                        break;
                    }

                    return value.ToString("#,###");

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }

            }
        }

        public static string RunSlowTransactionCountHourlyReport(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                string command = String.Format("SELECT '['''+ CASE  CONVERT(varchar(5), DATEADD(HH, datepart(hour,logtime), 0), 108)   " +
               "WHEN '00:00' THEN '17:00'  " +
               "WHEN '01:00' THEN '18:00'  " +
               "WHEN '02:00' THEN '19:00'  " +
               "WHEN '03:00' THEN '20:00'  " +
               "WHEN '04:00' THEN '21:00'  " +
               "WHEN '05:00' THEN '22:00'  " +
               "WHEN '06:00' THEN '23:00'  " +
               "WHEN '07:00' THEN '00:00'  " +
               "WHEN '08:00' THEN '01:00'  " +
               "WHEN '09:00' THEN '02:00'  " +
               "WHEN '10:00' THEN '03:00'  " +
               "WHEN '11:00' THEN '04:00'  " +
               "WHEN '12:00' THEN '05:00'  " +
               "WHEN '13:00' THEN '06:00'  " +
               "WHEN '14:00' THEN '07:00'  " +
               "WHEN '15:00' THEN '08:00'  " +
               "WHEN '16:00' THEN '09:00'  " +
               "WHEN '17:00' THEN '10:00'  " +
               "WHEN '18:00' THEN '11:00'  " +
               "WHEN '19:00' THEN '12:00'  " +
               "WHEN '20:00' THEN '13:00'  " +
               "WHEN '21:00' THEN '14:00'  " +
               "WHEN '22:00' THEN '15:00'  " +
               "WHEN '23:00' THEN '16:00' " +
               "ELSE 'Unexp'  " +
               "END  " +
               "+''',' AS [Hour]  " +
               ", COUNT(*),']' as [Count]  " +
               "FROM {0}  " +
               "where  " +
               "cs_uri_stem != '/'  " +
               "and time_taken >=5000  " +
               "GROUP BY datepart(hour,logtime)  " +
               "ORDER BY DATEADD(HH, datepart(hour,logtime), 0)", tableName);

                sqlCommand.CommandText = command;



                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                try
                {
                    StringBuilder builder = new StringBuilder("['Hour', 'Requests'],");
                    while (reader.Read())
                    {
                        builder.Append(String.Format("{0} {1} {2}", reader[0], reader[1], reader[2])).Append(",");
                    }

                    return builder.ToString();

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }

            }

        }

        public static string RunTransactionCountHourlyReport(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                string command = String.Format("SELECT '['''+ CASE  CONVERT(varchar(5), DATEADD(HH, datepart(hour,logtime), 0), 108)   " +
               "WHEN '00:00' THEN '17:00'  " +
               "WHEN '01:00' THEN '18:00'  " +
               "WHEN '02:00' THEN '19:00'  " +
               "WHEN '03:00' THEN '20:00'  " +
               "WHEN '04:00' THEN '21:00'  " +
               "WHEN '05:00' THEN '22:00'  " +
               "WHEN '06:00' THEN '23:00'  " +
               "WHEN '07:00' THEN '00:00'  " +
               "WHEN '08:00' THEN '01:00'  " +
               "WHEN '09:00' THEN '02:00'  " +
               "WHEN '10:00' THEN '03:00'  " +
               "WHEN '11:00' THEN '04:00'  " +
               "WHEN '12:00' THEN '05:00'  " +
               "WHEN '13:00' THEN '06:00'  " +
               "WHEN '14:00' THEN '07:00'  " +
               "WHEN '15:00' THEN '08:00'  " +
               "WHEN '16:00' THEN '09:00'  " +
               "WHEN '17:00' THEN '10:00'  " +
               "WHEN '18:00' THEN '11:00'  " +
               "WHEN '19:00' THEN '12:00'  " +
               "WHEN '20:00' THEN '13:00'  " +
               "WHEN '21:00' THEN '14:00'  " +
               "WHEN '22:00' THEN '15:00'  " +
               "WHEN '23:00' THEN '16:00' " +
               "ELSE 'Unexp'  " +
               "END  " +
               "+''',' AS [Hour]  " +
               ", COUNT(*),']' as [Count]  " +
               "FROM {0}  " +
               "where  " +
               "cs_uri_stem != '/'  " +
               "GROUP BY datepart(hour,logtime)  " +
               "ORDER BY DATEADD(HH, datepart(hour,logtime), 0)", tableName);

                sqlCommand.CommandText = command;



                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                try
                {
                    StringBuilder builder = new StringBuilder("['Hour', 'Requests'],");
                    while (reader.Read())
                    {
                        builder.Append(String.Format("{0} {1} {2}", reader[0], reader[1], reader[2])).Append(",");
                    }

                    return builder.ToString();
                    
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }

            }
        
        }

        public static string RunTransactionCountByApplicationReport(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                sqlCommand.CommandText = String.Format("select '['''+ app.Name +''',' as 'Application', count(lg.cs_username), ']' as 'Call Count' from {0} lg " +
                                         "join Application (nolock) app on app.Username = lg.cs_username " +
                                         "where lg.cs_username in " +
                                         "(select cs_username from {1} group by cs_username) " +
                                         "group by lg.cs_username, app.Name order by 2 desc", tableName, tableName);

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    StringBuilder builder = new StringBuilder("['App', 'Request Count'],");
                    while (reader.Read())
                    {
                        builder.Append(String.Format("{0} {1} {2}", reader[0], reader[1], reader[2])).Append(",");
                    }

                    return builder.ToString();

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }
            }
        }

        public static string RunTransactionCountByServiceReportNDLV(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                string serviceCountCommand = string.Format("select COUNT(*), cs_uri_stem " +
                                             "from {0} " +
                                              "where cs_uri_stem like '%service%' " +
                                             "group by cs_uri_stem " +
                                             "order by 1 desc ", tableName);

                                             //"where cs_uri_stem not like '/xmldata%' " +
                                             //"and cs_uri_stem != '/' " +
                                             //"and cs_uri_stem not like '/itassistant%' " +
                                             //"group by cs_uri_stem " +
                                             //"order by 1 desc ", tableName);


                sqlCommand.CommandText = serviceCountCommand;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    List<ServiceInfo> serviceInfoList = new List<ServiceInfo>();
                    while (reader.Read())
                    {
                        serviceInfoList.Add(new ServiceInfo((int)reader[0], (string)reader[1]));
                    }

                    reader.Close();

                    foreach (ServiceInfo info in serviceInfoList)
                    {
                       

                        sqlCommand.CommandText = string.Format("select MAX(cs_bytes) from {0} where cs_uri_stem like '%{1}%'", tableName, info.path);
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            info.maxReq = string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB";
                        }
                        reader.Close();

                        sqlCommand.CommandText = string.Format("select MAX(sc_bytes) from {0} where cs_uri_stem like '%{1}%'", tableName, info.path);
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            info.maxRes = string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB";
                        }
                        reader.Close();

                        sqlCommand.CommandText = string.Format("select COUNT(*) " +
                                            "from {0} " +
                                            "where cs_uri_stem like '%{1}%' " +
                                            "and sc_status = '500' ", tableName, info.path);

                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            info.err500Count = (int)reader[0];
                        }
                        reader.Close();
                    }


                    return ServiceStats.BuildStatsNDLV(serviceInfoList);

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }
            }

        }

        public static string RunTransactionCountByServiceReport(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                string serviceCountCommand = string.Format("select COUNT(*), cs_uri_stem " +
                                             "from {0} " +
                                             "where cs_uri_stem not like '/TempIntDocs%' " +
                                             "and cs_uri_stem != '/' " +
                                             "and cs_uri_stem not like '/Logs%' " +
                                             "and cs_uri_stem not like '/c$%' " +
                                             "and cs_uri_stem !='/xmldata' " +
                                             "and cs_uri_stem != '/favicon.ico' " +
                                             "and cs_uri_stem != '/itassistant/ui/omaBaseFrame.htm' " +
                                             "group by cs_uri_stem " +
                                             "order by 1 desc ", tableName);


                sqlCommand.CommandText = serviceCountCommand;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    List<ServiceInfo> serviceInfoList = new List<ServiceInfo>();
                    StringBuilder builder = new StringBuilder("['App', 'Request Count', 'In 1 SEC', 'PCT', 'Error Count'],");
                    while (reader.Read())
                    {
                        serviceInfoList.Add(new ServiceInfo((int)reader[0], (string)reader[1]));
                    }

                    reader.Close();

                    sqlCommand.CommandText = string.Format("select COUNT(*) from {0} where cs_uri_stem like '/TempIntDocs%'", tableName);

                    reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        serviceInfoList.Add(new ServiceInfo((int)reader[0], "/TempIntDocs"));
                    }

                    reader.Close();

                    sqlCommand.CommandText = string.Format("select COUNT(*), cs_uri_stem " +
                                             "from {0} " +
                                             "where cs_uri_stem not like '/TempIntDocs%' " +
                                             "and cs_uri_stem != '/' " +
                                             "and cs_uri_stem not like '/Logs%' " +
                                             "and cs_uri_stem not like '/c$%' " +
                                             "and cs_uri_stem !='/xmldata' " +
                                             "and cs_uri_stem != '/favicon.ico' " +
                                             "and cs_uri_stem != '/itassistant/ui/omaBaseFrame.htm' " +
                                             "and sc_status = '500' " +
                                             "group by cs_uri_stem " +
                                             "order by 1 desc ", tableName);

                    reader = sqlCommand.ExecuteReader();

                    List<ServiceInfo> serviceErrorInfoList = new List<ServiceInfo>();

                    while (reader.Read())
                    {
                        serviceErrorInfoList.Add(new ServiceInfo((int)reader[0], (string)reader[1]));
                    }

                    reader.Close();

                    List<ServiceInfo> populatedList = ServiceStats.PopulateServiceInfo(serviceInfoList, serviceErrorInfoList);

                    //foreach (ServiceInfo info in populatedList)
                    //{
                    //    sqlCommand.CommandText = string.Format("select count(*) from {0} where cs_uri_stem like '%{1}%' and time_taken <= 1000", tableName, info.dbPath);
                    //    reader = sqlCommand.ExecuteReader();
                    //    while (reader.Read())
                    //    {
                    //        info.ltOneSecondCount = (int)reader[0];
                    //    }
                    //    reader.Close();

                    //    if (info.dbPath == "FASTSERVICEINTERFACE")
                    //    {
                    //        sqlCommand.CommandText = string.Format("select count(*) from {0} where cs_uri_stem like '%{1}%' and time_taken <= 1000", tableName, "fastwebservice");
                    //        reader = sqlCommand.ExecuteReader();
                    //        while (reader.Read())
                    //        {
                    //            info.ltOneSecondCount += (int)reader[0];
                    //        }
                    //        reader.Close();

                    //    }

                    //    sqlCommand.CommandText = string.Format("select MAX(cs_bytes) from {0} where cs_uri_stem like '%{1}%'", tableName, info.dbPath);
                    //    reader = sqlCommand.ExecuteReader();
                    //    while (reader.Read())
                    //    {
                    //        try
                    //        {
                    //            info.maxReq = string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB";
                    //        }
                    //        catch (Exception e) { }

                    //    }
                    //    reader.Close();

                    //    sqlCommand.CommandText = string.Format("select MAX(sc_bytes) from {0} where cs_uri_stem like '%{1}%'", tableName, info.dbPath);
                    //    reader = sqlCommand.ExecuteReader();
                    //    while (reader.Read())
                    //    {
                    //        try
                    //        {
                    //            info.maxRes = string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB";
                    //        }
                    //        catch (Exception e) { }

                    //    }
                    //    reader.Close();
                    //}

                    return ServiceStats.BuildStats(populatedList);

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }
            }

        }

        public static string RunIISTransactionCountByServiceReport(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                string serviceCountCommand = string.Format("select COUNT(*), cs_uri_stem " +
                                             "from {0} " +
                                             "where time_taken >= 5000" +
                                             "group by cs_uri_stem " +
                                             "order by 1 desc ", tableName);


                sqlCommand.CommandText = serviceCountCommand;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    List<ServiceInfo> serviceInfoList = new List<ServiceInfo>();
                    StringBuilder builder = new StringBuilder("['App', 'Request Count'],");
                    while (reader.Read())
                    {
                        serviceInfoList.Add(new ServiceInfo((int)reader[0], (string)reader[1]));
                    }

                    reader.Close();

                    List<ServiceInfo> serviceErrorInfoList = new List<ServiceInfo>();

                   
                    List<ServiceInfo> populatedList = ServiceStats.PopulateIISServiceInfo(serviceInfoList, serviceErrorInfoList);

                    return ServiceStats.BuildStatsSimple(populatedList);

                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }
            }

        }

        public static string RunTransactionDetailsByApplicationService(string connectionString)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                sqlCommand.CommandText = "select * from Application(nolock) order by Name";

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    List<ApplicationInfo> applicationInfoList = new List<ApplicationInfo>();

                    while (reader.Read())
                    {
                        applicationInfoList.Add(new ApplicationInfo((string)reader[0], (string)reader[1]));
                    }

                    reader.Close();
                    StringBuilder appBuilder = new StringBuilder(string.Empty);
                    foreach (ApplicationInfo appInfo in applicationInfoList)
                    {
                        int total = 0;
                        int totalInSecond = 0;
                        List<ServiceInfo> serviceList = new List<ServiceInfo>();
                        if (appInfo.Name == "Others")
                        {
                            continue;
                        }

                        if (appInfo.Name == "SOASoftware")
                        {
                            appBuilder.Append("['" + appInfo.Name + "','Total',");
                            sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_user_agent like '%{1}%'", tableName, appInfo.Username);
                            reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                total = (int)reader[0];
                                appBuilder.Append("'" + string.Format("{0:n0}", total) + "',");
                            }
                            reader.Close();
                            sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_user_agent like '%{1}%' and time_taken <=1000", tableName, appInfo.Username);
                            reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                totalInSecond = (int)reader[0];
                                appBuilder.Append("'" + string.Format("{0:n0}", totalInSecond) + "',");
                            }
                            reader.Close();
                            appBuilder.Append("'" + (Convert.ToDouble(totalInSecond) / total).ToString("0.0%") + "',");

                            sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_user_agent like '%{1}%' and sc_status='500'", tableName, appInfo.Username);
                            reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                appBuilder.Append("'" + string.Format("{0:n0}", (int)reader[0]) + "',");
                            }
                            reader.Close();
                            sqlCommand.CommandText = string.Format("select MAX(cs_bytes) from {0} where cs_user_agent like '%{1}%'", tableName, appInfo.Username);
                            reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                appBuilder.Append("'" + string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB',");
                            }
                            reader.Close();
                            sqlCommand.CommandText = string.Format("select MAX(sc_bytes) from {0} where cs_user_agent like '%{1}%'", tableName, appInfo.Username);
                            reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                appBuilder.Append("'" + string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB',");
                            }
                            reader.Close();
                            appBuilder.Append("],");

                            sqlCommand.CommandText = string.Format("select count(*), cs_uri_stem from {0} where cs_user_agent like '%{1}%' group by cs_uri_stem order by 1 desc", tableName, appInfo.Username);
                            reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                serviceList.Add(new ServiceInfo((int)reader[0], (string)reader[1]));
                            }
                            reader.Close();

                            foreach (ServiceInfo serviceInfo in serviceList)
                            {
                                appBuilder.Append("['','" + serviceInfo.GetServiceName() + "',");

                                sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_user_agent like '%{1}%' and cs_uri_stem like '%{2}%'", tableName, appInfo.Username, serviceInfo.path);
                                reader = sqlCommand.ExecuteReader();
                                int totalS = 0;
                                while (reader.Read())
                                {
                                    totalS = (int)reader[0];
                                    appBuilder.Append("'" + string.Format("{0:n0}", totalS) + "',");
                                }
                                reader.Close();
                                sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_user_agent like '%{1}%' and time_taken <=1000 and cs_uri_stem like '%{2}%'", tableName, appInfo.Username, serviceInfo.path);
                                reader = sqlCommand.ExecuteReader();
                                int totalInSecondS = 0;
                                while (reader.Read())
                                {
                                    totalInSecondS = (int)reader[0];
                                    appBuilder.Append("'" + string.Format("{0:n0}", totalInSecondS) + "',");
                                }
                                reader.Close();
                                appBuilder.Append("'" + (Convert.ToDouble(totalInSecondS) / totalS).ToString("0.0%") + "',");

                                sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_user_agent like '%{1}%' and sc_status='500' and cs_uri_stem like '%{2}%'", tableName, appInfo.Username, serviceInfo.path);
                                reader = sqlCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    appBuilder.Append("'" + string.Format("{0:n0}", (int)reader[0]) + "',");
                                }
                                reader.Close();
                                sqlCommand.CommandText = string.Format("select MAX(cs_bytes) from {0} where cs_user_agent like '%{1}%' and cs_uri_stem like '%{2}%'", tableName, appInfo.Username, serviceInfo.path);
                                reader = sqlCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    appBuilder.Append("'" + string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB',");
                                }
                                reader.Close();
                                sqlCommand.CommandText = string.Format("select MAX(sc_bytes) from {0} where cs_user_agent like '%{1}%' and cs_uri_stem like '%{2}%'", tableName, appInfo.Username, serviceInfo.path);
                                reader = sqlCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    appBuilder.Append("'" + string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB',");
                                }
                                reader.Close();
                                appBuilder.Append("],");
                            }
                            appBuilder.Append("['',     '','','','','','',''],");
                            continue;
                        }
                        appBuilder.Append("['"+appInfo.Name+"','Total',");
                        sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_username='{1}'", tableName, appInfo.Username);
                        reader = sqlCommand.ExecuteReader();
                       
                        while (reader.Read())
                        {
                            total = (int)reader[0];
                            appBuilder.Append("'" + string.Format("{0:n0}", total) + "',");
                        }
                        reader.Close();
                        sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_username='{1}' and time_taken <=1000",tableName,appInfo.Username);
                        reader = sqlCommand.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            totalInSecond = (int)reader[0];
                            appBuilder.Append("'" + string.Format("{0:n0}", totalInSecond) + "',");
                        }
                        reader.Close();
                        appBuilder.Append("'" + (Convert.ToDouble(totalInSecond) / total).ToString("0.0%") + "',");

                        sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_username='{1}' and sc_status='500'",tableName,appInfo.Username);
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            appBuilder.Append("'"+string.Format("{0:n0}",(int)reader[0])+"',");
                        }
                        reader.Close();
                        sqlCommand.CommandText = string.Format("select MAX(cs_bytes) from {0} where cs_username='{1}'", tableName, appInfo.Username);
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            try
                            {
                                appBuilder.Append("'" + string.Format("{0:n0}", ((int)reader[0] / 1024)) + "KB',");
                            }
                            catch (Exception e) { 
                            
                            }

                            
                        }
                        reader.Close();
                        sqlCommand.CommandText = string.Format("select MAX(sc_bytes) from {0} where cs_username='{1}'", tableName,appInfo.Username);
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            appBuilder.Append("'"+string.Format("{0:n0}",((int)reader[0]/1024))+"KB',");
                        }
                        reader.Close();
                        appBuilder.Append("],");

                        
                        sqlCommand.CommandText = string.Format("select count(*), cs_uri_stem from {0} where cs_username='{1}' group by cs_uri_stem order by 1 desc", tableName, appInfo.Username);
                        reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            serviceList.Add(new ServiceInfo((int)reader[0], (string)reader[1]));
                        }
                        reader.Close();

                        //foreach (ServiceInfo serviceInfo in serviceList)
                        //{
                        //    appBuilder.Append("['','"+serviceInfo.GetServiceName()+"',");
                            
                        //    sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_username='{1}' and cs_uri_stem like '{2}'", tableName, appInfo.Username, serviceInfo.path);
                        //    reader = sqlCommand.ExecuteReader();
                        //    int totalS = 0;
                        //    while (reader.Read())
                        //    {
                        //        totalS = (int)reader[0];
                        //        appBuilder.Append("'" + string.Format("{0:n0}", totalS) + "',");
                        //    }
                        //    reader.Close();
                        //    sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_username='{1}' and time_taken <=1000 and cs_uri_stem like '{2}'", tableName, appInfo.Username, serviceInfo.path);
                        //    reader = sqlCommand.ExecuteReader();
                        //    int totalInSecondS = 0;
                        //    while (reader.Read())
                        //    {
                        //        totalInSecondS = (int)reader[0];
                        //        appBuilder.Append("'" + string.Format("{0:n0}", totalInSecondS) + "',");
                        //    }
                        //    reader.Close();
                        //    appBuilder.Append("'" + (Convert.ToDouble(totalInSecondS) / totalS).ToString("0.0%") + "',");

                        //    sqlCommand.CommandText = string.Format("select  COUNT(*) from {0} where cs_username='{1}' and sc_status='500' and cs_uri_stem like '{2}'", tableName, appInfo.Username,serviceInfo.path);
                        //    reader = sqlCommand.ExecuteReader();
                        //    while (reader.Read())
                        //    {
                        //        appBuilder.Append("'" + string.Format("{0:n0}", (int)reader[0]) + "',");
                        //    }
                        //    reader.Close();
                        //    sqlCommand.CommandText = string.Format("select MAX(cs_bytes) from {0} where cs_username='{1}' and cs_uri_stem like '{2}'", tableName, appInfo.Username, serviceInfo.path);
                        //    reader = sqlCommand.ExecuteReader();
                        //    while (reader.Read())
                        //    {
                        //        appBuilder.Append("'" + string.Format("{0:n0}",((int)reader[0]/1024)) + "KB',");
                        //    }
                        //    reader.Close();
                        //    sqlCommand.CommandText = string.Format("select MAX(sc_bytes) from {0} where cs_username='{1}' and cs_uri_stem like '{2}'", tableName, appInfo.Username,serviceInfo.path);
                        //    reader = sqlCommand.ExecuteReader();
                        //    while (reader.Read())
                        //    {
                        //        appBuilder.Append("'" + string.Format("{0:n0}",((int)reader[0]/1024)) + "KB',");
                        //    }
                        //    reader.Close();
                        //    appBuilder.Append("],");
                        //}
                        appBuilder.Append("['',     '','','','','','',''],");
                    }

                    return appBuilder.ToString();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }
            }
            
        }

        public static string RunHitsCountByServer(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                string tableName = IISLogHelper.GetINTFolderName(IISLogHelper.GetReportDateTime());

                
                sqlCommand.CommandText = string.Format("select COUNT(*), server_name from {0} group by server_name order by 2", tableName);
               
                //commented out on 6/27
                //sqlCommand.CommandText = string.Format("select COUNT(*), server_name from {0} where cs_uri_stem not like '/DocumentPreparation%' group by server_name order by 2", tableName);
                
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                try
                {
                    
                    StringBuilder builder = new StringBuilder("['INT', 'Hits per Day'],");
                    while (reader.Read())
                    {
                        builder.Append("['" + reader[1]+"',"+reader[0]+"]").Append(",");
                    }
                    return builder.ToString();
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    reader.Close();
                    sqlConnection.Close();
                }
            }
        
        }

        private static string GetReportFolder(string rootFolder)
        {
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }

            int year = DateTime.Now.Year;
            if (!Directory.Exists(rootFolder + year))
            {
                Directory.CreateDirectory(rootFolder + year);
            }

            int month = IISLogHelper.GetReportDateTime().Month;
            if (!Directory.Exists(rootFolder + year + "\\" + month))
            {
                Directory.CreateDirectory(rootFolder + year + "\\" + month);
            }

            if (!Directory.Exists(rootFolder + year + "\\" + month + "\\" + Settings.ServerRole))
            {
                Directory.CreateDirectory(rootFolder + year + "\\" + month + "\\" + Settings.ServerRole);
            }

            return rootFolder + year + "\\" + month + "\\" + Settings.ServerRole + "\\";
        }
    }
}
