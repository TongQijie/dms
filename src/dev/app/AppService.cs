using Petecat.IoC;
using Petecat.Threading.Tasks;
using Petecat.Extension;
using Petecat.Logging;

using System.ServiceProcess;
using System;

namespace Dade.Dms.Dev.App
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
                _TaskContainer.Initialize(AppDomainContainer.Instance, "./Configuration/DeamonObjects.config".FullPath(), "./Configuration/TaskSwitches.config".FullPath());
            }
            catch (Exception e)
            {
                LoggerManager.GetLogger().LogEvent("Windows Service", LoggerLevel.Info, "failed to initialize task container.", e);
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
