using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaiokane
{
    public class RWConfig
    {
        /// <summary>
        /// connectionStrings读取指定key的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path">配置文件路径（不需要后缀）</param>
        /// <returns></returns>
        public static string GetconnectionStringsValue(string key, string path)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            if (config.ConnectionStrings.ConnectionStrings[key] == null)
                return "";
            else
                return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        /// <summary>
        /// connectionStrings更新，若为null则会新建
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="path">配置文件路径（不需要后缀）</param>
        public static void SetconnectionStringsValue(string key, string value, string path)
        {
            //增加的内容写在connectionStrings段下 <add key="RegCode" value="0"/>
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            ConnectionStringSettings mySettings = new ConnectionStringSettings(key, value);
            if (config.ConnectionStrings.ConnectionStrings[key] == null)
            {
                config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Remove(key);
                config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");//重新加载新的配置文件
        }

        /// <summary>
        /// connectionStrings删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns>true:删除成功，false：删除失败</returns>
        public static bool DelconnectionStringsValue(string key, string path)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            if (config.ConnectionStrings.ConnectionStrings[key] == null)
            {
                return false;
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Remove(key);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");//重新加载新的配置文件
                return true;
            }
        }

        /// <summary>
        /// appSettings读取指定key的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path">配置文件路径（不需要后缀）</param>
        /// <returns></returns>
        public static string GetappSettingsValue(string key, string path)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// appSettings更新，若为null则会新建
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="path">配置文件路径（不需要后缀）</param>
        public static void SetappSettingsValue(string key, string value, string path)
        {
            //增加的内容写在appSettings段下 <add key="RegCode" value="0"/>
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
        }

        /// <summary>
        /// appSettings删除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns>true:删除成功，false：删除失败</returns>
        public static bool DelappSettingsValue(string key, string path)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            if (config.AppSettings.Settings[key] == null)
            {
                return false;
            }
            else
            {
                config.AppSettings.Settings.Remove(key);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件
                return true;
            }
        }
    }
}