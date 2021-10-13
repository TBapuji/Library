using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Library.Helpers
{
    public static class ConfigurationSettings
    {
        public static string GetSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string setting = appSettings[key];
            if(String.IsNullOrEmpty(setting)) { throw new ConfigurationErrorsException($"Appsetting {key} not found."); }
            return setting;
        }

        public static string GetConnectionString(string name)
        {
            string setting = String.Empty;

            ConnectionStringSettings connectionSetting =
                ConfigurationManager.ConnectionStrings[name];

            if(connectionSetting != null)
                setting = connectionSetting.ConnectionString;

            if(String.IsNullOrEmpty(setting)) { throw new ConfigurationErrorsException($"ConnectionString {name} not found."); }

            return setting;
        }

    }
}