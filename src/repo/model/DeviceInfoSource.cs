using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.RepoModel
{
    public class DeviceInfoSource : FoundationInfoSource
    {
        [PlainDataMapping]
        public string DeviceNumber { get; set; }

        [PlainDataMapping]
        public string DeviceName { get; set; }

        [PlainDataMapping]
        public string Status { get; set; }

        [PlainDataMapping]
        public string Manufactory { get; set; }

        [PlainDataMapping]
        public string DateOfManufacture { get; set; }

        [PlainDataMapping]
        public string Model { get; set; }

        [PlainDataMapping]
        public string Category { get; set; }

        [PlainDataMapping]
        public string DeviceIP { get; set; }

        [PlainDataMapping]
        public string DevicePort { get; set; }

        [PlainDataMapping]
        public string DeviceSIM { get; set; }

        [PlainDataMapping]
        public string PeriodOfMaintenance { get; set; }

        [PlainDataMapping]
        public string ProductionAbility { get; set; }

        [PlainDataMapping]
        public string MaintenanceMaunal { get; set; }
    }
}
