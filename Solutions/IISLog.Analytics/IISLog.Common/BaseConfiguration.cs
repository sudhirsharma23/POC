using Microsoft.Extensions.Configuration;
using System;

namespace IISLog.Common
{
    public class BaseConfiguration
    {
        IConfigurationRoot config;
        public BaseConfiguration()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        /// <summary>
        /// Checks a given setting if not loaded. If null or empty try to load setting from config. Throw exception if setting does not exist in the config file.
        /// </summary>
        /// <param name="appSettingKey"></param>
        /// <param name="setting"></param>
        public string GetAppSetting(string appSettingKey)
        {
            return config.GetSection("appSettings")[appSettingKey];
        }
    }
}
