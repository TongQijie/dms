using Dade.Dms.Rest.ServiceModel.Enums;

namespace Dade.Dms.Rest.ServiceModel
{
    public class DeviceCheckpoint : FoundationInfo
    {
        public int Id { get; set; }

        public DeviceInfo DeviceInfo { get; set; }

        public string Description { get; set; }

        public DeviceCheckpointFlag Flag { get; set; }

        public decimal UpperLimit { get; set; }

        public decimal LowerLimit { get; set; }

        public string Remark { get; set; }
    }
}
