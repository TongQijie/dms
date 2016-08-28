 using Petecat.IoC;
using Petecat.Console;
using Petecat.Logging;
using Petecat.Extension;
using Petecat.Logging.Loggers;
using Petecat.Threading.Tasks;
using Petecat.Data.Access;
using Dade.Dms.Dev;

namespace Dade.Test.Dev
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerManager.SetLogger(new FileLogger(LoggerManager.AppDomainLoggerName, "./log".FullPath()));

            AppDomainContainer.Initialize();
            DatabaseObjectManager.Instance.Initialize("./Configuration/DatabaseObjects.config".FullPath());
            DataCommandObjectManager.Instance.Initialize("./Configuration/DataCommandObjects.config".FullPath());
            DataSetConfigurationManager.Instance.Initialize("./Configuration/DeviceDataSet.config".FullPath());

            var taskContainer = new TaskContainerBase();
            taskContainer.Initialize(AppDomainContainer.Instance, "./Configuration/DeamonObjects.config".FullPath(), "./Configuration/TaskSwitches.config".FullPath());

            ConsoleBridging.ReadAnyKey();
        }
    }
}
