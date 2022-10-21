using System;
using System.ComponentModel;
namespace FirstAmerican.Common
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class EnumDisplayNameAttribute : DisplayNameAttribute
	{
		public EnumDisplayNameAttribute(string displayName) : base(displayName)
		{
		}
	}
}
