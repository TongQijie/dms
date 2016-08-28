using Dade.Dms.Rest.ServiceModel.Enums;

namespace Dade.Dms.Rest.ServiceModel
{
    public class DeviceRepairRecord : FoundationInfo
    {
        public int Id { get; set; }

        public DeviceInfo DeviceInfo { get; set; }

        public DeviceRepairRecordStatus Status { get; set; }

        public DeviceRepairRecordSourceType Source { get; set; }

        public DeviceAlarmRecord DeviceAlarmRecord { get; set; }

        public string FaultTime { get; set; }

        public string Description { get; set; }

        public DeviceRepairRecordSeverity Severity { get; set; }

        public string RepairBeginTime { get; set; }

        public string RepairEndTime { get; set; }

        public string Persons { get; set; }

        public string Content { get; set; }

        public string Remark { get; set; }

        public DeviceFaultCategory[] DeviceFaultCategories { get; set; }
    }
}
