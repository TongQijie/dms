using System;

using Petecat.IoC;
using Petecat.Logging;
using Petecat.IoC.Attributes;
using Petecat.Threading;
using Petecat.Threading.Tasks;

namespace Dade.Dms.Dev
{
    [Resolvable]
    public class Deamon : TaskObjectBase
    {
        public Deamon(string name, string description, int interval) 
            : base(name, description)
        {
            StatusChangedTo += Deamon_StatusChangedTo;

            Implement = (t) =>
            {
                while (true)
                {
                    var startTime = DateTime.Now;

                    ThreadBridging.Retry(3, () =>
                    {
                        try
                        {

                            AppDomainContainer.Instance.Resolve<IDeviceDataSource>(Name).Execute();
                        }
                        catch (Exception e)
                        {
                            LoggerManager.GetLogger().LogEvent("Deamon", LoggerLevel.Error, string.Format("deamon {0} failed to execute.", Name), e);
                            return false;
                        }

                        return true;
                    });

                    LoggerManager.GetLogger().LogEvent("Deamon", LoggerLevel.Info, string.Format("deamon {0} finish to execute. cost: {1}", Name, (DateTime.Now - startTime).TotalSeconds));

                    if (CheckTransitionalStatus() == TaskObjectStatus.Sleep)
                    {
                        break;
                    }

                    ThreadBridging.Sleep(interval);
                }

                return true;
            };
        }

        private void Deamon_StatusChangedTo(ITaskObject taskObject, TaskObjectStatus status)
        {
            LoggerManager.GetLogger().LogEvent("Deamon", LoggerLevel.Info, string.Format("deamon {0} changes status to {1}.", Name, status));
        }
    }
}
