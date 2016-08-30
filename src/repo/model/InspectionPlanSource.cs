using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.DataModel
{
    public class InspectionPlanSource : FoundationInfoSource
    {
        [PlainDataMapping]
        public int Id { get; set; }

        [CompositeDataMapping(typeof(DeviceInfoSource), Prefix = "Dev_")]
        public DeviceInfoSource DeviceInfo { get; set; }

        [PlainDataMapping]
        public string Status { get; set; }

        [PlainDataMapping]
        public string PeriodFrom { get; set; }

        [PlainDataMapping]
        public string PeriodTo { get; set; }

        [PlainDataMapping]
        public string ScheduleType { get; set; }

        [PlainDataMapping]
        public string ScheduleValue { get; set; }

        [PlainDataMapping]
        public string Content { get; set; }

        [PlainDataMapping]
        public string Remark { get; set; }
    }
}
