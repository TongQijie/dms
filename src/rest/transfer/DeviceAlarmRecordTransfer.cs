using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;

using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceAlarmRecordTransfer
    {
        public static DeviceAlarmRecord BuildDeviceAlarmRecord(DeviceAlarmRecordSource deviceAlarmRecordSource)
        {
            if (deviceAlarmRecordSource == null)
            {
                return null;
            }

            var deviceAlarmRecord = new DeviceAlarmRecord();

            deviceAlarmRecord.AlarmTime = Utility.ConvertDateTime(deviceAlarmRecordSource.AlarmTime);
            deviceAlarmRecord.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(deviceAlarmRecordSource.DeviceInfo);
            deviceAlarmRecord.Id = deviceAlarmRecordSource.Id;
            deviceAlarmRecord.Remark = deviceAlarmRecordSource.Remark;
            deviceAlarmRecord.Severity = (DeviceAlarmRecordSeverity)typeof(DeviceAlarmRecordSeverity).GetEnumByValue(deviceAlarmRecordSource.Severity);

            return deviceAlarmRecord;
        }
    }
}
