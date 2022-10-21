using System;
using System.ComponentModel;
using System.Reflection;
namespace FirstAmerican.Common
{
	public class EnumerationValue
	{
		private int _enumValue;
		private string _enumName;
		private string _displayName = string.Empty;
		private string _description = string.Empty;
		public string Description
		{
			get
			{
				return this._description;
			}
		}
		public string DisplayName
		{
			get
			{
				if (string.IsNullOrEmpty(this._displayName))
				{
					return this._enumName;
				}
				return this._displayName;
			}
		}
		public string EnumName
		{
			get
			{
				return this._enumName;
			}
		}
		public int EnumValue
		{
			get
			{
				return this._enumValue;
			}
		}
		internal EnumerationValue(int enumValue, string enumName, string displayName, string description)
		{
			this._enumValue = enumValue;
			this._enumName = enumName;
			if (!string.IsNullOrEmpty(displayName))
			{
				this._displayName = displayName;
			}
			if (!string.IsNullOrEmpty(description))
			{
				this._description = description;
			}
		}
		public static EnumerationValue GetValue(Enum enumValue)
		{
			ParameterValidator.VerifyParameterIsNotNull("enumValue", enumValue, null);
			Type type = enumValue.GetType();
			FieldInfo field = type.GetField(enumValue.ToString());
			return EnumerationValue.GetValue(type, field);
		}
		internal static EnumerationValue GetValue(Type enumType, FieldInfo enumField)
		{
			DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(enumField, typeof(DescriptionAttribute)) as DescriptionAttribute;
			EnumDisplayNameAttribute enumDisplayNameAttribute = Attribute.GetCustomAttribute(enumField, typeof(EnumDisplayNameAttribute)) as EnumDisplayNameAttribute;
			string description = (descriptionAttribute != null) ? descriptionAttribute.Description : string.Empty;
			string displayName = (enumDisplayNameAttribute != null) ? enumDisplayNameAttribute.DisplayName : string.Empty;
			int value = (int)Enum.Parse(enumType, enumField.Name);
			return new EnumerationValue(Convert.ToInt32(value), enumField.Name, displayName, description);
		}
	}
}
