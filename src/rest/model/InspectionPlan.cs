using Dade.Dms.Rest.ServiceModel.Enums;

namespace Dade.Dms.Rest.ServiceModel
{
    public class InspectionPlan : FoundationInfo
    {
        public int Id { get; set; }

        public DeviceInfo DeviceInfo { get; set; }

        public InspectionRecordStatus Status { get; set; }

        public string PeriodFrom { get; set; }

        public string PeriodTo { get; set; }

        public InspectionPlanScheduleType ScheduleType { get; set; }

        public string ScheduleValue { get; set; }

        public string Content { get; set; }

        public string Remark { get; set; }

        public DeviceCheckpoint[] DeviceCheckpoints { get; set; }

        public DeviceSparePart[] DeviceSpareParts { get; set; }
    }
}
