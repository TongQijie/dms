using Petecat.Caching;
using Petecat.Logging;
using System;
using System.IO;
using System.Linq;

namespace Dade.Dms.Dev
{
    public class DataSetConfigurationManager
    {
        private const string CacheObjectName = "Global_DataSet";

        private static DataSetConfigurationManager _Instance = null;

        public static DataSetConfigurationManager Instance { get { return _Instance ?? (_Instance = new DataSetConfigurationManager()); } }

        public void Initialize(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(configFile);
            }

            CacheObjectManager.Instance.AddXml<Configuration.DataSetConfig>(CacheObjectName, configFile, true);
        }

        public Configuration.DataRowConfig GetDataRowConfig(string collectorId)
        {
            var dataSetConfig = CacheObjectManager.Instance.GetValue<Configuration.DataSetConfig>(CacheObjectName);
            if (dataSetConfig == null)
            {
                LoggerManager.GetLogger().LogEvent("DataSetConfigurationManager", LoggerLevel.Error, "dataset configuration manager is not initialzied.");
                return null;
            }

            if (dataSetConfig.Rows == null || dataSetConfig.Rows.Length == 0)
            {
                LoggerManager.GetLogger().LogEvent("DataSetConfigurationManager", LoggerLevel.Error, string.Format("datarow {0} does not exists.", collectorId));
                return null;
            }

            var dataRowConfig = dataSetConfig.Rows.FirstOrDefault(x => x.CollectorId.Equals(collectorId, StringComparison.OrdinalIgnoreCase) && x.Enabled);
            if (dataRowConfig == null)
            {
                LoggerManager.GetLogger().LogEvent("DataSetConfigurationManager", LoggerLevel.Error, string.Format("datarow {0} does not exists.", collectorId));
                return null;
            }

            return dataRowConfig;
        }
    }
}
