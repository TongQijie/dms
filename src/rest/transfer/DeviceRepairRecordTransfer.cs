using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;

using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceRepairRecordTransfer
    {
        public static DeviceRepairRecord BuildDeviceRepairRecord(DeviceRepairRecordSource deviceRepairRecordSource)
        {
            if (deviceRepairRecordSource == null)
            {
                return null;
            }

            var deviceRepairRecord = new DeviceRepairRecord();

            deviceRepairRecord.Content = deviceRepairRecordSource.Content;
            deviceRepairRecord.CreationDate = Utility.ConvertDateTime(deviceRepairRecordSource.CreationDate);
            deviceRepairRecord.Description = deviceRepairRecordSource.Description;
            deviceRepairRecord.DeviceAlarmRecord = DeviceAlarmRecordTransfer.BuildDeviceAlarmRecord(deviceRepairRecordSource.DeviceAlarmRecord);
            deviceRepairRecord.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(deviceRepairRecordSource.DeviceInfo);
            deviceRepairRecord.FaultTime = Utility.ConvertDateTime(deviceRepairRecordSource.FaultTime);
            deviceRepairRecord.Id = deviceRepairRecordSource.Id;
            deviceRepairRecord.ModifiedDate = Utility.ConvertDateTime(deviceRepairRecordSource.ModifiedDate);
            deviceRepairRecord.Persons = deviceRepairRecordSource.Persons;
            deviceRepairRecord.Remark = deviceRepairRecordSource.Remark;
            deviceRepairRecord.RepairBeginTime = Utility.ConvertDateTime(deviceRepairRecordSource.RepairBeginTime);
            deviceRepairRecord.RepairEndTime = Utility.ConvertDateTime(deviceRepairRecordSource.RepairEndTime);
            deviceRepairRecord.Severity = (DeviceRepairRecordSeverity)typeof(DeviceRepairRecordSeverity).GetEnumByValue(deviceRepairRecordSource.Severity);
            deviceRepairRecord.Source = (DeviceRepairRecordSourceType)typeof(DeviceRepairRecordSourceType).GetEnumByValue(deviceRepairRecordSource.Source);
            deviceRepairRecord.Status = (DeviceRepairRecordStatus)typeof(DeviceRepairRecordStatus).GetEnumByValue(deviceRepairRecordSource.Status);

            return deviceRepairRecord;
        }
    }
}
