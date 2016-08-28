using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class InspectionRecordTransfer
    {
        public static InspectionRecord BuildInspectionRecord(InspectionRecordSource inspectionRecordSource)
        {
            if (inspectionRecordSource == null)
            {
                return null;
            }

            var inspectionRecord = new InspectionRecord();

            inspectionRecord.Content = inspectionRecordSource.Content;
            inspectionRecord.CreationDate = Utility.ConvertDateTime(inspectionRecordSource.CreationDate);
            inspectionRecord.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(inspectionRecordSource.DeviceInfo);
            inspectionRecord.Id = inspectionRecordSource.Id;
            inspectionRecord.InspectionPlan = InspectionPlanTransfer.BuildInspectionPlan(inspectionRecordSource.InspectionPlan);
            inspectionRecord.MaintainBeginTime = Utility.ConvertDateTime(inspectionRecordSource.MaintainBeginTime);
            inspectionRecord.MaintainEndTime = Utility.ConvertDateTime(inspectionRecordSource.MaintainEndTime);
            inspectionRecord.ModifiedDate = Utility.ConvertDateTime(inspectionRecordSource.ModifiedDate);
            inspectionRecord.Persons = inspectionRecordSource.Persons;
            inspectionRecord.Remark = inspectionRecordSource.Remark;
            inspectionRecord.ScheduleTime = Utility.ConvertDateTime(inspectionRecordSource.ScheduleTime);
            inspectionRecord.Status = (InspectionRecordStatus)typeof(InspectionRecordStatus).GetEnumByValue(inspectionRecordSource.Status);

            return inspectionRecord;
        }
    }
}
