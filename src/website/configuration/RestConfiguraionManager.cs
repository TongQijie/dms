using Petecat.Caching;
using Petecat.Data.Formatters;
using Petecat.Extension;
using Petecat.Logging;
using System;
using System.Text;

namespace Dade.Dms.Website.Configuration
{
    public static class RestConfiguraionManager
    {
        private const string CacheObjectName = "Global_RestConfigs";

        static RestConfiguraionManager()
        {
            CacheObjectManager.Instance.Add<Rest.RestConfig>(CacheObjectName, "./Configuration/Rest.config".FullPath(), Encoding.UTF8,
                ObjectFormatterFactory.GetFormatter(ObjectFormatterType.Xml), true);
        }

        public static Rest.RestConfig RestConfig
        {
            get
            {
                try
                {
                    return CacheObjectManager.Instance.GetValue<Rest.RestConfig>(CacheObjectName);
                }
                catch (Exception e)
                {
                    LoggerManager.GetLogger().LogEvent("RestConfiguraionManager", LoggerLevel.Error, e);
                }

                return null;
            }
        }

        public static int PageSize
        {
            get
            {
                return RestConfig == null ? 10 : RestConfig.PageSize;
            }
        }
    }
}
