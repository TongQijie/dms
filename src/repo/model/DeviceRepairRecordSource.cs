using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.RepoModel
{
    public class DeviceRepairRecordSource : FoundationInfoSource
    {
        [PlainDataMapping]
        public int Id { get; set; }

        [CompositeDataMapping(typeof(DeviceInfoSource), Prefix = "DIS_")]
        public DeviceInfoSource DeviceInfo { get; set; }

        [PlainDataMapping]
        public string Status { get; set; }

        [PlainDataMapping]
        public string Source { get; set; }

        [CompositeDataMapping(typeof(DeviceAlarmRecordSource), Prefix = "DARS_")]
        public DeviceAlarmRecordSource DeviceAlarmRecord { get; set; }

        [PlainDataMapping]
        public string FaultTime { get; set; }

        [PlainDataMapping]
        public string Description { get; set; }

        [PlainDataMapping]
        public string Severity { get; set; }

        [PlainDataMapping]
        public string RepairBeginTime { get; set; }

        [PlainDataMapping]
        public string RepairEndTime { get; set; }

        [PlainDataMapping]
        public string Persons { get; set; }

        [PlainDataMapping]
        public string Content { get; set; }

        [PlainDataMapping]
        public string Remark { get; set; }
    }
}
