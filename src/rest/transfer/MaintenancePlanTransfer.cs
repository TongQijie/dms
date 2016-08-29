using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class MaintenancePlanTransfer
    {
        public static MaintenancePlan BuildMaintenancePlan(MaintenancePlanSource maintenancePlanSource)
        {
            if (maintenancePlanSource == null)
            {
                return null;
            }

            var maintenancePlan = new MaintenancePlan();

            maintenancePlan.Content = maintenancePlanSource.Content;
            maintenancePlan.CreationDate = Utility.ConvertDateTime(maintenancePlanSource.CreationDate);
            maintenancePlan.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(maintenancePlanSource.DeviceInfo);
            maintenancePlan.Id = maintenancePlanSource.Id;
            maintenancePlan.ModifiedDate = Utility.ConvertDateTime(maintenancePlanSource.ModifiedDate);
            maintenancePlan.Remark = maintenancePlanSource.Remark;
            maintenancePlan.ScheduleType = (MaintenancePlanScheduleType)typeof(MaintenancePlanScheduleType).GetEnumByValue(maintenancePlanSource.ScheduleType);
            maintenancePlan.ScheduleValue = maintenancePlanSource.ScheduleValue;
            maintenancePlan.Status = (MaintenancePlanStatus)typeof(MaintenancePlanStatus).GetEnumByValue(maintenancePlanSource.Status);

            return maintenancePlan;
        }

        public static MaintenancePlanSource BuildMaintenancePlanSource(MaintenancePlan maintenancePlan)
        {
            if (maintenancePlan == null)
            {
                return null;
            }

            var maintenancePlanSource = new MaintenancePlanSource();

            maintenancePlanSource.Content = maintenancePlan.Content;
            maintenancePlanSource.CreationDate = Utility.ConvertDateTime(maintenancePlan.CreationDate);
            maintenancePlanSource.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfoSource(maintenancePlan.DeviceInfo);
            maintenancePlanSource.Id = maintenancePlan.Id;
            maintenancePlanSource.ModifiedDate = Utility.ConvertDateTime(maintenancePlan.ModifiedDate);
            maintenancePlanSource.Remark = maintenancePlan.Remark;
            maintenancePlanSource.ScheduleType = typeof(MaintenancePlanScheduleType).GetValueByEnum(maintenancePlan.ScheduleType);
            maintenancePlanSource.ScheduleValue = maintenancePlan.ScheduleValue;
            maintenancePlanSource.Status = typeof(MaintenancePlanStatus).GetValueByEnum(maintenancePlan.Status);

            return maintenancePlanSource;
        }
    }
}
