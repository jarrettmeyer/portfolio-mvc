using System;
using System.Configuration;

namespace Portfolio.Common
{
    public static class Config
    {
        private static string connectionString;

        public static string ConnectionString
        {
            get { return connectionString ?? (connectionString = GetConfigValue("PortfolioDBConnectionString")); }
            set { connectionString = value; }
        }

        public static string GetConfigValue(string key)
        {
            string value;
            if (TryGetConfigValueFromEnvironment(key, out value))
                return value;
            if (TryGetConfigValueFromAppSettings(key, out value))
                return value;
            
            return null;
        }

        private static bool TryGetConfigValueFromAppSettings(string key, out string value)
        {
            value = ConfigurationManager.AppSettings[key];
            return !string.IsNullOrEmpty(value);
        }

        private static bool TryGetConfigValueFromEnvironment(string key, out string value)
        {
            value = Environment.GetEnvironmentVariable(key);
            return !string.IsNullOrEmpty(value);            
        }
    }
}
