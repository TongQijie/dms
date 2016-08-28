using Petecat.IoC;
using Petecat.Logging;
using Petecat.Extension;
using Petecat.Threading.Tasks;

using System;
using System.ServiceProcess;

namespace Dade.Dms.Data.App
{
    partial class AppService : ServiceBase
    {
        public AppService()
        {
            InitializeComponent();

            _TaskContainer = new TaskContainerBase();
        }

        private TaskContainerBase _TaskContainer = null;

        protected override void OnStart(string[] args)
        {
            try
            {
                _TaskContainer.Initialize(AppDomainContainer.Instance, "./Configuration/Jobs.config".FullPath(), "./Configuration/Switches.config".FullPath());
            }
            catch (Exception e)
            {
                LoggerManager.GetLogger().LogEvent("Windows Service: Job App", LoggerLevel.Fatal, "failed to initialize task container.", e);
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
