using Petecat.IoC;
using Petecat.Logging;
using Petecat.Extension;
using Petecat.Data.Access;
using Petecat.Logging.Loggers;

using System.ServiceProcess;
using System;

namespace Dade.Dms.Dev.App
{
    static class Program
    {
        static void Main()
        {
            LoggerManager.SetLogger(new FileLogger(LoggerManager.AppDomainLoggerName, "./log".FullPath()));
            LoggerManager.GetLogger().LogEvent("Windows Service", LoggerLevel.Info, "app service started...");

            try
            {
                AppDomainContainer.Initialize();
                DatabaseObjectManager.Instance.Initialize("./Configuration/DatabaseObjects.config".FullPath());
                DataCommandObjectManager.Instance.Initialize("./Configuration/DataCommandObjects.config".FullPath());
                DataSetConfigurationManager.Instance.Initialize("./Configuration/DeviceDataSet.config".FullPath());
            }
            catch (Exception e)
            {
                LoggerManager.GetLogger().LogEvent("Windows Service", LoggerLevel.Info, "failed to initialize.", e);
            }

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new AppService(),
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
