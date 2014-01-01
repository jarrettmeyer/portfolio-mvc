using System;
using System.Configuration;
using System.Diagnostics.Contracts;

namespace Portfolio.Lib
{
    public static class Config
    {
        private const int DEFAULT_PAGE_SIZE = 10;
        private static string connectionString;
        private static bool? logSql;
        private static int pageSize;

        public static string ConnectionString
        {
            get { return connectionString ?? (connectionString = GetConfigValue("PortfolioDBConnectionString")); }
            set { connectionString = value; }
        }

        public static bool LogSql
        {
            get
            {
                if (logSql.HasValue)
                    return logSql.Value;

                string value = GetConfigValue("LogSql");
                bool temp;
                logSql = bool.TryParse(value, out temp) && temp;
                return logSql.Value;
            }
            set { logSql = value; }
        }

        public static int PageSize
        {
            get
            {
                if (pageSize < 1)
                {
                    string pageSizeString = GetConfigValue("PageSize");
                    int.TryParse(pageSizeString, out pageSize);
                }
                if (pageSize < 1)
                {
                    pageSize = DEFAULT_PAGE_SIZE;
                }
                return pageSize;
            }
            set { pageSize = value; }
        }

        public static string GetConfigValue(string key)
        {
            Contract.Requires<ArgumentException>(string.IsNullOrEmpty(key) == false);

            string value;
            if (TryGetConfigValueFromEnvironment(key, out value))
                return value;
            if (TryGetConfigValueFromAppSettings(key, out value))
                return value;
            
            return null;
        }

        public static void Reset()
        {
            connectionString = null;
            pageSize = 0;
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
