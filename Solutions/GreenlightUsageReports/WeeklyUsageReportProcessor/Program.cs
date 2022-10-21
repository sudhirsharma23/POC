using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WeeklyUsageReportProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var reportRows = File.ReadAllLines("./CSV/NOV-09-2020 - Weekly Greenlight Usage Report.csv").ToList();
            reportRows.RemoveAt(0);
            var displayRows = new StringBuilder();
            foreach (var row in reportRows)
            {
                var displayRow = "['" + row.Replace(",", "','") + "'],";
                displayRows.Append(displayRow);
            }

            var reportTemplate = File.ReadAllText("./Template/WeeklyUsageReport_Template.html");
            var reportHtml = reportTemplate.Replace("{{data}}",displayRows.ToString());
            reportHtml = reportHtml.Replace("{{date}}", "11/09/2020");

            File.WriteAllText("./HTML/WeeklyUsageReport.html", reportHtml);

        }
    }
}
