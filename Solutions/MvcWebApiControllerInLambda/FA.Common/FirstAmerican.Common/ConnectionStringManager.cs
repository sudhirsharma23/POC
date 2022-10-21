using FirstAmerican.Common.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
namespace FirstAmerican.Common
{
    public static class ConnectionStringManager
	{
		private static readonly object _lockObject = new object();
		private static Dictionary<string, string> _cache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		public static string GetConnectionString(string name, SymmetricAlgorithmType symmetricAlgorithmType, byte[] key, byte[] iv)
		{
			ParameterValidator.VerifyStringParameter("name", name, false, false, null, null);
			ParameterValidator.VerifyParameterIsNotNull("key", key, null);
			ParameterValidator.VerifyParameterIsNotNull("iv", iv, null);
			string result = null;
			//if (!ConnectionStringManager._cache.TryGetValue(name, out result))
			//{
			//	lock (ConnectionStringManager._lockObject)
			//	{
			//		if (!ConnectionStringManager._cache.TryGetValue(name, out result))
			//		{
			//			ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[name];
			//			if (connectionStringSettings == null)
			//			{
			//				string message = string.Format(ErrorResources.Culture, ErrorResources.CONNECTION_STRING_NOT_FOUND, new object[]
			//				{
			//					name
			//				});
			//				throw new ConfigurationErrorsException(message);
			//			}
			//			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionStringSettings.ConnectionString);
			//			if (!string.IsNullOrEmpty(sqlConnectionStringBuilder.UserID))
			//			{
			//				sqlConnectionStringBuilder.UserID = CryptographyManager.DecryptSymmetric(symmetricAlgorithmType, key, iv, sqlConnectionStringBuilder.UserID);
			//			}
			//			if (!string.IsNullOrEmpty(sqlConnectionStringBuilder.Password))
			//			{
			//				sqlConnectionStringBuilder.Password = CryptographyManager.DecryptSymmetric(symmetricAlgorithmType, key, iv, sqlConnectionStringBuilder.Password);
			//			}
			//			result = sqlConnectionStringBuilder.ToString();
			//		}
			//	}
			//}
			return result;
		}
		public static string EncryptConnectionString(string connectionString, SymmetricAlgorithmType symmetricAlgorithmType, byte[] key, byte[] iv)
		{
			ParameterValidator.VerifyStringParameter("connectionString", connectionString, false, false, null, null);
			ParameterValidator.VerifyParameterIsNotNull("key", key, null);
			ParameterValidator.VerifyParameterIsNotNull("iv", iv, null);
			//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
			//if (!string.IsNullOrEmpty(sqlConnectionStringBuilder.UserID))
			//{
			//	sqlConnectionStringBuilder.UserID = CryptographyManager.EncryptSymmetric(symmetricAlgorithmType, key, iv, sqlConnectionStringBuilder.UserID);
			//}
			//if (!string.IsNullOrEmpty(sqlConnectionStringBuilder.Password))
			//{
			//	sqlConnectionStringBuilder.Password = CryptographyManager.EncryptSymmetric(symmetricAlgorithmType, key, iv, sqlConnectionStringBuilder.Password);
			//}
			//return sqlConnectionStringBuilder.ToString();
			return connectionString;
		}
	}
}
