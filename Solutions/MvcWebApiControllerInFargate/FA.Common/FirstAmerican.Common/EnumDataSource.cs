using FirstAmerican.Common.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
namespace FirstAmerican.Common
{
	public sealed class EnumDataSource : IListSource
	{
		private Type _enumType;
		private ReadOnlyCollection<EnumerationValue> _enumValueArray;
		bool IListSource.ContainsListCollection
		{
			get
			{
				return false;
			}
		}
		public Type EnumType
		{
			get
			{
				return this._enumType;
			}
		}
		public EnumDataSource(Type enumType)
		{
			ParameterValidator.VerifyParameterIsNotNull("enumType", enumType, null);
			if (!enumType.IsEnum)
			{
				throw new ArgumentException(ErrorResources.PARAMETER_NOT_TYPE_OF_ENUMERATION, "enumType");
			}
			this._enumType = enumType;
		}
		public IList GetList()
		{
			if (this._enumValueArray == null)
			{
				List<EnumerationValue> list = new List<EnumerationValue>();
				FieldInfo[] fields = this._enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
				FieldInfo[] array = fields;
				for (int i = 0; i < array.Length; i++)
				{
					FieldInfo enumField = array[i];
					list.Add(EnumerationValue.GetValue(this._enumType, enumField));
				}
				this._enumValueArray = list.AsReadOnly();
			}
			return this._enumValueArray;
		}
	}
}
