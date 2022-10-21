using System;
using System.Collections;
using System.IO;

namespace IISLog.Common
{
    public class SQLHelper
    {
        public static void Import(string iisLogRepo)
        {
            var reportDate = Settings.ReportDate;
            DateTime datetime = DateTime.Now;
            if (!string.IsNullOrEmpty(reportDate))
            {
                datetime = DateTime.Parse(reportDate);
            }
            var foldername = IISLogHelper.GetINTFolderName(datetime);//"INT_4_22";

            var logFileFolder = iisLogRepo + foldername;

            var files = Directory.GetFiles(logFileFolder, "*.log", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                Console.WriteLine(string.Format("Starting to process {0}", file));

                var serverName = Settings.ServerPrefix;

                var serverIndex = GetServerNumber(file);
                serverName += serverIndex;

                var nameInConfig = GetServerName(Convert.ToInt32(serverIndex) - 1);

                if (!string.IsNullOrEmpty(nameInConfig))
                {
                    serverName = nameInConfig;
                }

                _ = CreateLogFileWithoutComments(file, serverName);

            }
        }

        private static string GetServerName(int index)
        {
            try
            {
                var iisLogSourceFolderList = Settings.IISLogSourceFolderList;
                var iisLogSourceFolderArray = iisLogSourceFolderList.Split(';');
                var path = iisLogSourceFolderArray[index];

                //\\Snavpiisfast003\W3SVC1\
                var pathParts = path.Split('\\');
                return pathParts[2];

            }
            catch (Exception)
            {
                return null;
            }
        }

        //C:\Documents\IISLogs\INT\001_ex140611.log
        private static string GetServerNumber(string filePath)
        {
            try
            {
                var firstParts = filePath.Split('\\');
                var len = firstParts.Length;
                var namePart = firstParts[len - 1];
                var lastParts = namePart.Split('_');
                return lastParts[0];
            }
            catch (Exception)
            {
                return "0";
            }
        }

        private static string CreateLogFileWithoutComments(string file, string serverName)
        {
            var lines = File.ReadAllLines(file);

            var linesWithoutComments = new ArrayList();

            foreach (var line in lines)
            {
                if (line.StartsWith("#Fields: "))
                {
                    var fieldLine = line.Replace("#Fields: ", "");
                    fieldLine = fieldLine + " server-name";
                    fieldLine = fieldLine.Replace(",", "_");
                    fieldLine = fieldLine.Replace(" ", ",");
                    _ = linesWithoutComments.Add(fieldLine);
                    break;
                }
            }

            foreach (var line in lines)
            {
                if (line.StartsWith("#") == false)
                {
                    var newLine = line + " " + serverName;
                    newLine = newLine.Replace(",", "_");
                    newLine = newLine.Replace(" ", ",");
                    newLine = newLine.Replace(",-,-,", ",NULL,NULL,");
                    newLine = newLine.Replace(",-,", ",NULL,");
                    _ = linesWithoutComments.Add(newLine);
                }
            }

            var fileWithoutComments = file.Replace(".log", "_log");
            fileWithoutComments += ".csv";

            if (File.Exists(fileWithoutComments))
            {
                File.Delete(fileWithoutComments);
            }

            File.WriteAllLines(fileWithoutComments, (string[])linesWithoutComments.ToArray(typeof(string)));

            return fileWithoutComments;
        }
    }
}
