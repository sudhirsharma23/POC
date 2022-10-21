using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
namespace FirstAmerican.Common
{
	public static class XmlHelper
	{
		private const string XSLT_FUNCTIONS_NAMESPACE = "FirstAmerican.Common.XsltFunctions";
		private static Dictionary<string, XslCompiledTransform> _xsltCache = new Dictionary<string, XslCompiledTransform>(StringComparer.OrdinalIgnoreCase);
		private static readonly object _lockObject = new object();
		private static readonly XsltFunctions _xsltFunctions = new XsltFunctions();
		public static string TransformXml(string xml, string xsltPath)
		{
			return XmlHelper.TransformXml(xml, xsltPath, true);
		}
		public static string TransformXml(string xml, string xsltPath, XsltArgumentList arguments)
		{
			return XmlHelper.TransformXml(xml, xsltPath, true, arguments);
		}
		public static string TransformXml(string xml, string xsltPath, bool useCache)
		{
			return XmlHelper.TransformXml(xml, xsltPath, useCache, null);
		}
		public static string TransformXml(string xml, string xsltPath, bool useCache, XsltArgumentList arguments)
		{
			ParameterValidator.VerifyStringParameter("xsltPath", xsltPath, false, false, null, null);
			XslCompiledTransform xslCompiledTransform = null;
			if (useCache)
			{
				if (XmlHelper._xsltCache.TryGetValue(xsltPath, out xslCompiledTransform))
				{
					goto IL_68;
				}
				lock (XmlHelper._lockObject)
				{
					if (!XmlHelper._xsltCache.TryGetValue(xsltPath, out xslCompiledTransform))
					{
						xslCompiledTransform = XmlHelper.CreateXslt(xsltPath);
						XmlHelper._xsltCache.Add(xsltPath, xslCompiledTransform);
					}
					goto IL_68;
				}
			}
			xslCompiledTransform = XmlHelper.CreateXslt(xsltPath);
			IL_68:
			return XmlHelper.TransformXml(xml, xslCompiledTransform, arguments);
		}
		public static string TransformXml(string xml, XslCompiledTransform xslt)
		{
			return XmlHelper.TransformXml(xml, xslt, null);
		}
		public static string TransformXml(string xml, XslCompiledTransform xslt, XsltArgumentList arguments)
		{
			ParameterValidator.VerifyStringParameter("xml", xml, false, false, null, null);
			ParameterValidator.VerifyParameterIsNotNull("xslt", xslt, null);
			if (arguments == null)
			{
				arguments = new XsltArgumentList();
			}
			string result;
			using (StringReader stringReader = new StringReader(xml))
			{
				using (XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings
				{
					IgnoreWhitespace = true
				}))
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						arguments.AddExtensionObject("FirstAmerican.Common.XsltFunctions", XmlHelper._xsltFunctions);
						xslt.Transform(xmlReader, arguments, memoryStream);
						memoryStream.Position = 0L;
						using (StreamReader streamReader = new StreamReader(memoryStream))
						{
							result = streamReader.ReadToEnd();
						}
					}
				}
			}
			return result;
		}
		private static XslCompiledTransform CreateXslt(string xsltPath)
		{
			XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
            xsltPath = SanitizeFileOrDirectoryName(xsltPath);
            XsltSettings settings = new XsltSettings(true, false);
			xslCompiledTransform.Load(xsltPath, settings, new XmlUrlResolver());
			return xslCompiledTransform;
		}

        private static string SanitizeFileOrDirectoryName(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                inputString = HttpUtility.UrlDecode(inputString);

                inputString = inputString.Replace(".rem", string.Empty).Replace(".soap", string.Empty).Replace(".bat", string.Empty).Replace(".exe", string.Empty);

                inputString = inputString.Replace("..%5C", string.Empty).Replace("..\\", string.Empty).Replace(@"..\", string.Empty).Replace(@"../", string.Empty);

                inputString = inputString.Replace("\0", string.Empty);

                var currFileName = Path.GetFileNameWithoutExtension(inputString);

                var newFileName = Path.GetInvalidFileNameChars().Aggregate(currFileName, (current, c) => current.Replace(c.ToString(), string.Empty));

                if (!string.Equals(currFileName, newFileName))
                {
                    inputString = inputString.Replace(currFileName, newFileName);
                }
            }
            return inputString;
        }
    }
}
