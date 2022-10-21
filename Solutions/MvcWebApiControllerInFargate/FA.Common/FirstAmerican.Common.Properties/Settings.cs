using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace FirstAmerican.Common.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("http://prod.svclog.lendersadvantage.com/LogService.asmx"), SpecialSetting(SpecialSetting.WebServiceUrl), DebuggerNonUserCode]
		public string FirstAmerican_Common_ServiceLoggerWebService_LogService
		{
			get
			{
				return (string)this["FirstAmerican_Common_ServiceLoggerWebService_LogService"];
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("http://localhost/ramwebservicejw/logservice.asmx"), SpecialSetting(SpecialSetting.WebServiceUrl), DebuggerNonUserCode]
		public string FirstAmerican_Common_RAMLogService_LogService
		{
			get
			{
				return (string)this["FirstAmerican_Common_RAMLogService_LogService"];
			}
		}
	}
}
