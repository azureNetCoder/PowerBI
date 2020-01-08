using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PowerBI.Worker.Common
{
    public static class ConfigurationManager
    {
        public static Dictionary<string, string> configurationSettings = new Dictionary<string, string>();

        public static void InitializeConfigurationSettingsIntoDictionary()
        {
            var configurationCollection = ConfigurationSettings.AppSettings.AllKeys;

            foreach (var item in configurationCollection)
            {
                configurationSettings.Add(item, ConfigurationSettings.AppSettings[item]);
            }
        }
    }
}
