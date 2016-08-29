using Dade.Dms.Repo.DataModel;
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

        public static MaintenanceRecordSource BuildMaintenanceRecordSource(MaintenanceRecord maintenanceRecord)
        {
            if (maintenanceRecord == null)
            {
                return null;
            }

            var maintenanceRecordSource = new MaintenanceRecordSource();

            maintenanceRecordSource.Content = maintenanceRecord.Content;
            maintenanceRecordSource.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfoSource(maintenanceRecord.DeviceInfo);
            maintenanceRecordSource.Id = maintenanceRecord.Id;
            maintenanceRecordSource.MaintainBeginTime = Utility.ConvertDateTime(maintenanceRecord.MaintainBeginTime);
            maintenanceRecordSource.MaintainEndTime = Utility.ConvertDateTime(maintenanceRecord.MaintainEndTime);
            maintenanceRecordSource.MaintenancePlan = MaintenancePlanTransfer.BuildMaintenancePlanSource(maintenanceRecord.MaintenancePlan);
            maintenanceRecordSource.Persons = maintenanceRecord.Persons;
            maintenanceRecordSource.Remark = maintenanceRecord.Remark;
            maintenanceRecordSource.ScheduleTime = Utility.ConvertDateTime(maintenanceRecord.ScheduleTime);
            maintenanceRecordSource.Status = typeof(MaintenanceRecordStatus).GetValueByEnum(maintenanceRecord.Status);

            return maintenanceRecordSource;
        }
    }
}
