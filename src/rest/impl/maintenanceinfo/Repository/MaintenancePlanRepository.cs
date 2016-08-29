using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
using Petecat.Data.Access;
using Petecat.Extension;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Repo.DataModel;

namespace Dade.Dms.Rest.Impl.Repository
{
    [AutoResolvable(typeof(IMaintenancePlanRepository))]
    public class MaintenancePlanRepository : IMaintenancePlanRepository
    {
        public int AddPlan(MaintenancePlanSource maintenancePlanSource, MaintenanceRecordSource[] maintenanceRecordSources)
        {
            var retVal = 0;

            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_AddPlan");
            dataCommandObject.DatabaseObject.ExecuteTransaction((db) =>
            {
                dataCommandObject.SetParameterValue("@DeviceNumber", maintenancePlanSource.DeviceInfo.DeviceNumber);
                dataCommandObject.SetParameterValue("@PeriodFrom", maintenancePlanSource.PeriodFrom);
                dataCommandObject.SetParameterValue("@PeriodTo", maintenancePlanSource.PeriodTo);
                dataCommandObject.SetParameterValue("@ScheduleType", maintenancePlanSource.ScheduleType);
                dataCommandObject.SetParameterValue("@ScheduleValue", maintenancePlanSource.ScheduleValue);
                dataCommandObject.SetParameterValue("@Content", maintenancePlanSource.Content);
                dataCommandObject.SetParameterValue("@Remark", maintenancePlanSource.Remark);
                db.ExecuteNonQuery(dataCommandObject);
                if ((retVal = (int)dataCommandObject.GetParameterValue("@RetVal")) < 0)
                {
                    return false;
                }

                foreach (var maintenanceRecordSource in maintenanceRecordSources)
                {
                    dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_AddRecord");
                    dataCommandObject.SetParameterValue("@DeviceNumber", maintenancePlanSource.DeviceInfo.DeviceNumber);
                    dataCommandObject.SetParameterValue("@MaintenancePlanId", retVal);
                    dataCommandObject.SetParameterValue("@ScheduleTime", maintenanceRecordSource.ScheduleTime);
                    dataCommandObject.SetParameterValue("@MaintainBeginTime", maintenanceRecordSource.MaintainBeginTime);
                    dataCommandObject.SetParameterValue("@MaintainEndTime", maintenanceRecordSource.MaintainEndTime);
                    dataCommandObject.SetParameterValue("@Persons", maintenanceRecordSource.Persons);
                    dataCommandObject.SetParameterValue("@Content", maintenanceRecordSource.Content);
                    dataCommandObject.SetParameterValue("@Remark", maintenanceRecordSource.Remark);
                    db.ExecuteNonQuery(dataCommandObject);
                    if ((retVal = (int)dataCommandObject.GetParameterValue("@RetVal")) < 0)
                    {
                        return false;
                    }
                }

                return true;
            });

            return retVal;
        }

        public int DeletePlan(MaintenancePlan maintenancePlan)
        {
            throw new NotImplementedException();
        }

        public int EditPlan(MaintenancePlan maintenancePlan)
        {
            throw new NotImplementedException();
        }

        public MaintenancePlan[] QueryPlansByConditions(Paging paging, int id, string deviceNumber)
        {
            throw new NotImplementedException();
        }
    }
}
