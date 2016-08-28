using Dade.Dms.Rest.ServiceModel.Enums;

namespace Dade.Dms.Rest.ServiceModel
{
    public class DeviceAlarmRecord
    {
        public int Id { get; set; }

        public DeviceInfo DeviceInfo { get; set; }

        public DeviceAlarmRecordSeverity Severity { get; set; }

        public string AlarmTime { get; set; }

        public string Remark { get; set; }
    }
}
