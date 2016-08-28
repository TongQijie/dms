using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class InspectionPlanTransfer
    {
        public static InspectionPlan BuildInspectionPlan(InspectionPlanSource inspectionPlanSource)
        {
            if (inspectionPlanSource == null)
            {
                return null;
            }

            var inspectionPlan = new InspectionPlan();

            inspectionPlan.Content = inspectionPlanSource.Content;
            inspectionPlan.CreationDate = Utility.ConvertDateTime(inspectionPlanSource.CreationDate);
            inspectionPlan.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(inspectionPlanSource.DeviceInfo);
            inspectionPlan.Id = inspectionPlanSource.Id;
            inspectionPlan.ModifiedDate = Utility.ConvertDateTime(inspectionPlanSource.ModifiedDate);
            inspectionPlan.PeriodFrom = Utility.ConvertDateTime(inspectionPlanSource.PeriodFrom);
            inspectionPlan.PeriodTo = Utility.ConvertDateTime(inspectionPlanSource.PeriodTo);
            inspectionPlan.Remark = inspectionPlanSource.Remark;
            inspectionPlan.ScheduleType = (InspectionPlanScheduleType)typeof(InspectionPlanScheduleType).GetEnumByValue(inspectionPlanSource.ScheduleType);
            inspectionPlan.ScheduleValue = inspectionPlanSource.ScheduleValue;
            inspectionPlan.Status = (InspectionRecordStatus)typeof(InspectionRecordStatus).GetEnumByValue(inspectionPlanSource.Status);

            return inspectionPlan;
        }
    }
}
