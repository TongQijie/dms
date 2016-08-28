using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.RepoModel
{
    public class InspectionRecordSource : FoundationInfoSource
    {
        [PlainDataMapping]
        public int Id { get; set; }

        [PlainDataMapping]
        public DeviceInfoSource DeviceInfo { get; set; }

        [PlainDataMapping]
        public string Status { get; set; }

        [CompositeDataMapping(typeof(InspectionPlanSource), Prefix = "IPS_")]
        public InspectionPlanSource InspectionPlan { get; set; }

        [PlainDataMapping]
        public string ScheduleTime { get; set; }

        [PlainDataMapping]
        public string MaintainBeginTime { get; set; }

        [PlainDataMapping]
        public string MaintainEndTime { get; set; }

        [PlainDataMapping]
        public string Persons { get; set; }

        [PlainDataMapping]
        public string Content { get; set; }

        [PlainDataMapping]
        public string Remark { get; set; }
    }
}
