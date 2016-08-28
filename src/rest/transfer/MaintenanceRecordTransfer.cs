using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class MaintenanceRecordTransfer
    {
        public static MaintenanceRecord BuildMaintenanceRecord(MaintenanceRecordSource maintenanceRecordSource)
        {
            if (maintenanceRecordSource == null)
            {
                return null;
            }

            var maintenanceRecord = new MaintenanceRecord();

            maintenanceRecord.Content = maintenanceRecordSource.Content;
            maintenanceRecord.CreationDate = Utility.ConvertDateTime(maintenanceRecordSource.CreationDate);
            maintenanceRecord.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(maintenanceRecordSource.DeviceInfo);
            maintenanceRecord.Id = maintenanceRecordSource.Id;
            maintenanceRecord.MaintainBeginTime = Utility.ConvertDateTime(maintenanceRecordSource.MaintainBeginTime);
            maintenanceRecord.MaintainEndTime = Utility.ConvertDateTime(maintenanceRecordSource.MaintainEndTime);
            maintenanceRecord.MaintenancePlan = MaintenancePlanTransfer.BuildMaintenancePlan(maintenanceRecordSource.MaintenancePlan);
            maintenanceRecord.ModifiedDate = Utility.ConvertDateTime(maintenanceRecordSource.ModifiedDate);
            maintenanceRecord.Persons = maintenanceRecordSource.Persons;
            maintenanceRecord.Remark = maintenanceRecordSource.Remark;
            maintenanceRecord.ScheduleTime = Utility.ConvertDateTime(maintenanceRecordSource.ScheduleTime);
            maintenanceRecord.Status = (MaintenanceRecordStatus)typeof(MaintenanceRecordStatus).GetEnumByValue(maintenanceRecordSource.Status);

            return maintenanceRecord;
        }
    }
}
