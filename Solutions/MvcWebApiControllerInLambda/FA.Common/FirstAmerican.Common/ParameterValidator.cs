using FirstAmerican.Common.Properties;
using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
namespace FirstAmerican.Common
{
	public static class ParameterValidator
	{
		[DebuggerStepThrough]
		public static void VerifyArrayParameterDoesNotContainNullValue<TValue>(string parameterName, TValue[] parameterValue, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			for (int i = 0; i < parameterValue.Length; i++)
			{
				if (parameterValue[i] == null)
				{
					string message = (!string.IsNullOrEmpty(exceptionMessage)) ? exceptionMessage : string.Format(ErrorResources.Culture, ErrorResources.ARRAY_PARAMETER_CONTAINS_NULL_VALUE, new object[]
					{
						i
					});
					throw new ArgumentNullException(parameterName, message);
				}
			}
		}
		[DebuggerStepThrough]
		public static void VerifyParameterInRange<TParameter>(string parameterName, TParameter parameterValue, TParameter minValue, TParameter maxValue, string exceptionMessage = null) where TParameter : IComparable<TParameter>
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			if (parameterValue.CompareTo(minValue) < 0 || parameterValue.CompareTo(maxValue) > 0)
			{
				string message = (!string.IsNullOrEmpty(exceptionMessage)) ? exceptionMessage : string.Format(ErrorResources.Culture, ErrorResources.PARAMETER_NOT_IN_RANGE, new object[]
				{
					minValue,
					maxValue
				});
				throw new ArgumentOutOfRangeException(parameterName, parameterValue, message);
			}
		}
		[DebuggerStepThrough]
		public static void VerifyParameterIsAssignableFrom(string parameterName, object parameterValue, Type[] expectedParameterTypes, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			ParameterValidator.VerifyParameterIsAssignableFrom(parameterName, parameterValue.GetType(), expectedParameterTypes, exceptionMessage);
		}
		[DebuggerStepThrough]
		public static void VerifyParameterIsAssignableFrom(string parameterName, Type parameterValue, Type[] expectedParameterTypes, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			if (expectedParameterTypes == null)
			{
				throw new ArgumentNullException("expectedParameterTypes");
			}
			bool flag = false;
			string[] array = new string[expectedParameterTypes.Length];
			for (int i = 0; i < expectedParameterTypes.Length; i++)
			{
				Type type = expectedParameterTypes[i];
				array[i] = type.FullName;
				if (type.IsAssignableFrom(parameterValue))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				string message = (!string.IsNullOrEmpty(exceptionMessage)) ? exceptionMessage : string.Format(ErrorResources.Culture, "Value must be assignable from one of the following: {0}.", new object[]
				{
					string.Join(", ", array)
				});
				throw new ArgumentException(message, parameterName);
			}
		}
		[DebuggerStepThrough]
        public static void VerifyParameterIsNotNull(string parameterName, [ValidatedNotNull]object parameterValue, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				ArgumentNullException ex = (!string.IsNullOrEmpty(exceptionMessage)) ? new ArgumentNullException(parameterName, exceptionMessage) : new ArgumentNullException(parameterName);
				throw ex;
			}
		}
		[DebuggerStepThrough]
		public static void VerifyParameterIsOfType(string parameterName, object parameterValue, Type expectedParameterType, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			if (expectedParameterType == null)
			{
				throw new ArgumentNullException("expectedParameterType");
			}
			Type type = parameterValue.GetType();
			if (type != expectedParameterType)
			{
				string message = (!string.IsNullOrEmpty(exceptionMessage)) ? exceptionMessage : string.Format(ErrorResources.Culture, "Value must be of type '{0}'.", new object[]
				{
					expectedParameterType.FullName
				});
				throw new ArgumentException(message, parameterName);
			}
		}
		[DebuggerStepThrough]
		public static void VerifyParameterWithComparison<TParameter>(string parameterName, TParameter parameterValue, ComparisonType comparisonType, TParameter valueToCompareAgainst, string exceptionMessage = null) where TParameter : IComparable<TParameter>
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			bool flag = false;
			string format = null;
			switch (comparisonType)
			{
			case ComparisonType.EqualTo:
				if (parameterValue.CompareTo(valueToCompareAgainst) != 0)
				{
					flag = true;
					format = ErrorResources.PARAMETER_NOT_EQUAL_TO;
				}
				break;
			case ComparisonType.GreaterThan:
				if (parameterValue.CompareTo(valueToCompareAgainst) <= 0)
				{
					flag = true;
					format = ErrorResources.PARAMETER_NOT_GREATER_THAN;
				}
				break;
			case ComparisonType.GreaterThanOrEqualTo:
				if (parameterValue.CompareTo(valueToCompareAgainst) < 0)
				{
					flag = true;
					format = ErrorResources.PARAMETER_NOT_GREATER_THAN_OR_EQUAL_TO;
				}
				break;
			case ComparisonType.LessThan:
				if (parameterValue.CompareTo(valueToCompareAgainst) >= 0)
				{
					flag = true;
					format = ErrorResources.PARAMETER_NOT_LESS_THAN;
				}
				break;
			case ComparisonType.LessThanOrEqualTo:
				if (parameterValue.CompareTo(valueToCompareAgainst) > 0)
				{
					flag = true;
					format = ErrorResources.PARAMETER_NOT_LESS_THAN_OR_EQUAL_TO;
				}
				break;
			case ComparisonType.NotEqualTo:
				if (parameterValue.CompareTo(valueToCompareAgainst) == 0)
				{
					flag = true;
					format = ErrorResources.PARAMETER_EQUAL_TO;
				}
				break;
			default:
				throw new NotSupportedException();
			}
			if (flag)
			{
				string message = string.IsNullOrEmpty(exceptionMessage) ? string.Format(ErrorResources.Culture, format, new object[]
				{
					valueToCompareAgainst
				}) : exceptionMessage;
				throw new ArgumentException(message, parameterName);
			}
		}
        
		[DebuggerStepThrough]
		public static void VerifyStringParameter(string parameterName, string parameterValue, bool allowEmpty = false, bool allowNull = false, string emptyExceptionMessage = null, string nullExceptionMessage = null)
		{
			if (!allowNull && parameterValue == null)
			{
				ArgumentNullException ex = (!string.IsNullOrEmpty(nullExceptionMessage)) ? new ArgumentNullException(parameterName, nullExceptionMessage) : new ArgumentNullException(parameterName);
				throw ex;
			}            
			if (!allowEmpty && parameterValue != null && parameterValue.Length == 0)
			{
				string message = (!string.IsNullOrEmpty(emptyExceptionMessage)) ? emptyExceptionMessage : ErrorResources.STRING_PARAMETER_EMPTY;
				throw new ArgumentException(message, parameterName);
			}
		}

        public static void VerifyStringParameterLength(string parameterName, string parameterValue, int length, string exceptionMessage = null)
		{
			ParameterValidator.VerifyStringParameterLength(parameterName, parameterValue, length, length, exceptionMessage);
		}
		public static void VerifyStringParameterLength(string parameterName, string parameterValue, int minLength, int maxLength, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			if (parameterValue.Length < minLength || parameterValue.Length > maxLength)
			{
				string message;
				if (!string.IsNullOrEmpty(exceptionMessage))
				{
					message = exceptionMessage;
				}
				else
				{
					if (minLength == maxLength)
					{
						message = string.Format(ErrorResources.Culture, ErrorResources.STRING_PARAMETER_NOT_EXACT_LENGTH, new object[]
						{
							minLength
						});
					}
					else
					{
						message = string.Format(ErrorResources.Culture, ErrorResources.STRING_PARAMETER_NOT_WITHIN_LENGTH, new object[]
						{
							minLength,
							maxLength
						});
					}
				}
				throw new ArgumentException(message, parameterName);
			}
		}
		[DebuggerStepThrough]
		public static void VerifyStringParameterDoesNotContain(string parameterName, string parameterValue, string[] invalidStrings, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			if (invalidStrings == null)
			{
				throw new ArgumentNullException("invalidStrings");
			}
			bool flag = false;
			for (int i = 0; i < invalidStrings.Length; i++)
			{
				string value = invalidStrings[i];
				if (parameterValue.Contains(value))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < invalidStrings.Length; j++)
				{
					string arg = invalidStrings[j];
					stringBuilder.AppendFormat("'{0}',", arg);
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				string message = (!string.IsNullOrEmpty(exceptionMessage)) ? exceptionMessage : string.Format(ErrorResources.Culture, ErrorResources.STRING_PARAMETER_CONTAINS_INVALID_STRING, new object[]
				{
					stringBuilder
				});
				throw new ArgumentException(message, parameterName);
			}
		}
		[DebuggerStepThrough]
		public static void VerifyStringParameterWithRegex(string parameterName, string parameterValue, string regex, string exceptionMessage = null)
		{
			if (parameterValue == null)
			{
				throw new ArgumentNullException("parameterValue");
			}
			if (regex == null)
			{
				throw new ArgumentNullException("regex");
			}
			if (regex.Length == 0)
			{
				throw new ArgumentException(ErrorResources.STRING_PARAMETER_EMPTY, "regex");
			}
			if (!Regex.IsMatch(parameterValue, regex))
			{
				string message = (!string.IsNullOrEmpty(exceptionMessage)) ? exceptionMessage : string.Format(ErrorResources.Culture, ErrorResources.PARAMETER_NOT_MATCH_REGEX, new object[]
				{
					regex
				});
				throw new ArgumentException(message, parameterName);
			}
		}
	}
}
