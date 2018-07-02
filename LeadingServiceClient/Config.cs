using System;
using System.Reflection;

namespace Leading.Services.Client
{
    public static class Config
    {

        public static string getConfig(string fileName, string settingName)
        {
            System.Configuration.Configuration cfg = System.Configuration.ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            return cfg.AppSettings.Settings[settingName].Value.ToString();
        }


    }
}
