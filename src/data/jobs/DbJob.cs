using Petecat.Data.Access;
using Petecat.Extension;
using Petecat.IoC;
using Petecat.IoC.Attributes;
using Petecat.Logging;
using Petecat.Threading;
using Petecat.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Dade.Dms.Data.Jobs
{
    [Resolvable]
    public class DbJob : TaskObjectBase
    {
        public DbJob(string name, string description, int interval, string parameters)
            : base(name, description)
        {
            Interval = interval;

            foreach(var parameter in parameters.SplitByChar(';'))
            {
                var kv = parameter.SplitByChar(':');
                if (kv.Length == 3)
                {
                    Parameters.Add(new DbParameter()
                    {
                        Name = kv[0],
                        Type = kv[1],
                        Value = kv[2],
                    });
                }
            }

            Implement = (t) =>
            {
                while (true)
                {
                    var startTime = DateTime.Now;

                    ThreadBridging.Retry(3, () =>
                    {
                        try
                        {
                            AppDomainContainer.Instance.Resolve<IJob>(Name).Execute();
                        }
                        catch (Exception e)
                        {
                            LoggerManager.GetLogger().LogEvent("DbJob", LoggerLevel.Error, string.Format("job {0} failed to execute.", Name), e);
                            return false;
                        }

                        return true;
                    });

                    LoggerManager.GetLogger().LogEvent("DbJob", LoggerLevel.Info, string.Format("job {0} finish to execute. cost: {1}", Name, (DateTime.Now - startTime).TotalSeconds));

                    if (CheckTransitionalStatus() == TaskObjectStatus.Sleep)
                    {
                        break;
                    }

                    ThreadBridging.Sleep(interval);
                }

                return true;
            };
        }

        public int Interval { get; private set; }

        private List<DbParameter> Parameters = new List<DbParameter>();

        public override void Execute()
        {
            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject(Name);
            foreach(var parameter in Parameters)
            {
                if (parameter.Type.Equals("int", StringComparison.OrdinalIgnoreCase))
                {
                    dataCommandObject.SetParameterValue(parameter.Name, int.Parse(parameter.Value));
                }
                else
                {
                    dataCommandObject.SetParameterValue(parameter.Name, parameter.Value);
                }
            }
            dataCommandObject.ExecuteNonQuery();
        }

        class DbParameter
        {
            public string Name { get; set; }

            public string Type { get; set; }

            public string Value { get; set; }
        }
    }
}
