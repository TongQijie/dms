using Dade.Dms.Rest.ServiceModel.Enums;

namespace Dade.Dms.Rest.ServiceModel
{
    public class DeviceInfo : FoundationInfo
    {
        public string DeviceNumber { get; set; }

        public string DeviceName { get; set; }

        public DeviceInfoStatus Status { get; set; }

        public string Manufactory { get; set; }

        public string DateOfManufacture { get; set; }

        public string Model { get; set; }

        public string Category { get; set; }

        public string DeviceIP { get; set; }

        public string DevicePort { get; set; }

        public string DeviceSIM { get; set; }

        public string PeriodOfMaintenance { get; set; }

        public string ProductionAbility { get; set; }

        public string MaintenanceMaunal { get; set; }

        public DeviceCheckpoint[] DeviceCheckpoints { get; set; }

        public DeviceSparePart[] DeviceSpareParts { get; set; }
    }
}
