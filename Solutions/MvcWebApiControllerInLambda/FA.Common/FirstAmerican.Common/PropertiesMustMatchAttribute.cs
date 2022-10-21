using FirstAmerican.Common.Properties;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FirstAmerican.Common
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public sealed class PropertiesMustMatchAttribute : ValidationAttribute
	{
		private static readonly object _typeId = new object();
		public override object TypeId
		{
			get
			{
				return PropertiesMustMatchAttribute._typeId;
			}
		}
		public string Property
		{
			get;
			private set;
		}
		public string PropertyToCompareAgainst
		{
			get;
			private set;
		}
		public PropertiesMustMatchAttribute(string property, string propertyToCompareAgainst)
		{
			this.Property = property;
			this.PropertyToCompareAgainst = propertyToCompareAgainst;
		}
		public override string FormatErrorMessage(string name)
		{
			return string.Format(ErrorResources.Culture, ErrorResources.PROPERTIES_MUST_MATCH_INVALID, new object[]
			{
				this.Property,
				this.PropertyToCompareAgainst
			});
		}
		public override bool IsValid(object value)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
			object value2 = properties.Find(this.Property, true).GetValue(value);
			object value3 = properties.Find(this.PropertyToCompareAgainst, true).GetValue(value);
			return object.Equals(value2, value3);
		}
	}
}
