using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using IISLog.Common;

namespace REP.IISLog.ImportLogs
{
    class Program
    {
        static void Main(string[] args)
        {

            Settings.CreateTableSQL = @"
			Create Table [dbo].[{0}] (
				[logdate] [DateTime] Null,
				[logtime] [DateTime] Null,
				[s_sitename] [Varchar] (4096) Null,
                [cs_User_Agent] [Varchar] (4096) Null,
				[s_ip] [Varchar] (4096) Null,
				[cs_method] [Varchar] (255) Null,
				[cs_uri_stem] [varchar](max) Null,
				[cs_uri_query] [Varchar] (4096) Null,
				[s_port] [Varchar] (255) Null,
				[cs_username] [Varchar] (255) Null,
				[c_ip] [Varchar] (255) Null,
				[sc_status] [Int] Null,
				[sc_substatus] [Int] Null,
                [sc_win32_status] [Int] Null,   
				[sc_bytes] [Int] Null,
				[cs_bytes] [Int] Null,            
                [time_taken] [Int] Null,
                [server_name] [Varchar] (255) Null
			)
			";

            Builder.Build();
            System.Console.WriteLine("Import successful");

        }

    }
}
