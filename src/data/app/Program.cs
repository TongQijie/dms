using Petecat.IoC;
using Petecat.Logging;
using Petecat.Extension;
using Petecat.Data.Access;
using Petecat.Logging.Loggers;

using System;
using System.ServiceProcess;

namespace Dade.Dms.Data.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            LoggerManager.SetLogger(new FileLogger(LoggerManager.AppDomainLoggerName, "./log".FullPath()));
            LoggerManager.GetLogger().LogEvent("Windows Service", LoggerLevel.Info, "app service started...");

            try
            {
                AppDomainContainer.Initialize();
                DatabaseObjectManager.Instance.Initialize("./Configuration/DatabaseObjects.config".FullPath());
                DataCommandObjectManager.Instance.Initialize("./Configuration/DataCommandObjects.config".FullPath());
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
