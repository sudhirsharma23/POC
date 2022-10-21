using System;
using System.Globalization;
using System.Xml;
namespace FirstAmerican.Common
{
	public class XsltFunctions
	{
		public string CurrentDateTime()
		{
			return DateTime.Now.ToString();
		}
		public string CurrentDateTime(string format)
		{
			return DateTime.Now.ToString(format, CultureInfo.InvariantCulture);
		}
		public string FormatDateTime(string date, string dateFormat)
		{
			string result = string.Empty;
			DateTime dateTime;
			if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out dateTime))
			{
				result = dateTime.ToString(dateFormat, CultureInfo.InvariantCulture);
			}
			return result;
		}
		public string FormatDuration(string duration)
		{
			string result = string.Empty;
			if (!string.IsNullOrEmpty(duration))
			{
				result = XmlConvert.ToTimeSpan(duration).ToString();
			}
			return result;
		}
		public string Contains(string target, string value, bool ignoreCase)
		{
			ParameterValidator.VerifyStringParameter("target", target, true, false, null, null);
			ParameterValidator.VerifyStringParameter("value", value, true, false, null, null);
			if (ignoreCase)
			{
				target = target.ToUpperInvariant();
				value = value.ToUpperInvariant();
			}
			return target.Contains(value).ToString();
		}
	}
}
