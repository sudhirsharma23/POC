using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace FirstAmerican.Common.Data
{
	public static class FullTextCriteriaParser
	{
		public static List<string> ParseCriteria(string criteria)
		{
			ParameterValidator.VerifyStringParameter("criteria", criteria, false, false, null, null);
			criteria = criteria.Trim();
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(criteria))
			{
				StringBuilder stringBuilder = new StringBuilder();
				char[] array = new char[1];
				using (StringReader stringReader = new StringReader(criteria))
				{
					bool flag = false;
					while (stringReader.Peek() > -1)
					{
						stringReader.Read(array, 0, 1);
						switch (array[0])
						{
						case ' ':
							if (flag)
							{
								stringBuilder.Append(array[0]);
								continue;
							}
							if (stringBuilder.Length > 0)
							{
								list.Add(stringBuilder.ToString());
								stringBuilder.Remove(0, stringBuilder.Length);
								continue;
							}
							continue;
						case '"':
							if (!flag)
							{
								flag = true;
								continue;
							}
							list.Add(stringBuilder.ToString());
							stringBuilder.Remove(0, stringBuilder.Length);
							flag = false;
							continue;
						}
						stringBuilder.Append(array[0]);
					}
					if (stringBuilder.Length > 0)
					{
						list.Add(stringBuilder.ToString());
					}
				}
			}
			return list;
		}
	}
}
