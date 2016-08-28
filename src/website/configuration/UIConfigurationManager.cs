using Petecat.Caching;
using Petecat.Logging;
using Petecat.Extension;
using Petecat.Data.Formatters;

using System;
using System.Text;
using System.Linq;

namespace Dade.Dms.Website.Configuration
{
    public static class UIConfigurationManager
    {
        private const string CacheObjectName = "Global_UIConfigs";

        static UIConfigurationManager()
        {
            CacheObjectManager.Instance.Add<UI.UIConfig>(CacheObjectName, "./Configuration/UI.config".FullPath(), Encoding.UTF8,
                ObjectFormatterFactory.GetFormatter(ObjectFormatterType.Xml), true);
        }

        public static UI.UIConfig UIConfig
        {
            get
            {
                try
                {
                    return CacheObjectManager.Instance.GetValue<UI.UIConfig>(CacheObjectName);
                }
                catch (Exception e)
                {
                    LoggerManager.GetLogger().LogEvent("UIConfigurationManager", LoggerLevel.Error, e);
                }

                return null;
            }
        }

        public static string DefaultLanguage
        {
            get
            {
                return UIConfig == null ? "chs" : UIConfig.DefaultLang;
            }
        }

        public static string GetResource(string name)
        {
            return GetResource(DefaultLanguage, name);
        }

        public static string GetResource(string language, string name)
        {
            if (UIConfig == null || UIConfig.Languages == null || UIConfig.Languages.Length == 0)
            {
                return string.Empty;
            }

            var lang = UIConfig.Languages.FirstOrDefault(x => string.Equals(x.Name, language, StringComparison.OrdinalIgnoreCase));
            if (lang == null)
            {
                return string.Empty;
            }

            var resource = lang.Resources.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            if (resource == null)
            {
                return string.Empty;
            }

            return resource.Value;
        }
    }
}
