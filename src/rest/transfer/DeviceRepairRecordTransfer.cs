using Dade.Dms.Repo.DataModel;
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

        public static DeviceRepairRecordSource BuildDeviceRepairRecordSource(DeviceRepairRecord deviceRepairRecord)
        {
            if (deviceRepairRecord == null)
            {
                return null;
            }

            var deviceRepairRecordSource = new DeviceRepairRecordSource();

            deviceRepairRecordSource.Content = deviceRepairRecord.Content;
            deviceRepairRecordSource.Description = deviceRepairRecordSource.Description;
            deviceRepairRecordSource.DeviceAlarmRecord = DeviceAlarmRecordTransfer.BuildDeviceAlarmRecordSource(deviceRepairRecord.DeviceAlarmRecord);
            deviceRepairRecordSource.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfoSource(deviceRepairRecord.DeviceInfo);
            deviceRepairRecordSource.FaultTime = Utility.ConvertDateTime(deviceRepairRecord.FaultTime);
            deviceRepairRecordSource.Id = deviceRepairRecord.Id;
            deviceRepairRecordSource.Persons = deviceRepairRecord.Persons;
            deviceRepairRecordSource.Remark = deviceRepairRecord.Remark;
            deviceRepairRecordSource.RepairBeginTime = Utility.ConvertDateTime(deviceRepairRecord.RepairBeginTime);
            deviceRepairRecordSource.RepairEndTime = Utility.ConvertDateTime(deviceRepairRecord.RepairEndTime);
            deviceRepairRecordSource.Severity = typeof(DeviceRepairRecordSeverity).GetValueByEnum(deviceRepairRecord.Severity);
            deviceRepairRecordSource.Source = typeof(DeviceRepairRecordSourceType).GetValueByEnum(deviceRepairRecord.Source);
            deviceRepairRecordSource.Status = typeof(DeviceRepairRecordStatus).GetValueByEnum(deviceRepairRecord.Status);

            return deviceRepairRecordSource;
        }
    }
}
