using Dade.Dms.Repo.DataModel;
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

        public static InspectionRecordSource BuildInspectionRecordSource(InspectionRecord inspectionRecord)
        {
            if (inspectionRecord == null)
            {
                return null;
            }

            var inspectionRecordSource = new InspectionRecordSource();

            inspectionRecordSource.Content = inspectionRecord.Content;
            inspectionRecordSource.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfoSource(inspectionRecord.DeviceInfo);
            inspectionRecordSource.Id = inspectionRecord.Id;
            inspectionRecordSource.InspectionPlan = InspectionPlanTransfer.BuildInspectionPlanSource(inspectionRecord.InspectionPlan);
            inspectionRecordSource.MaintainBeginTime = Utility.ConvertDateTime(inspectionRecord.MaintainBeginTime);
            inspectionRecordSource.MaintainEndTime = Utility.ConvertDateTime(inspectionRecord.MaintainEndTime);
            inspectionRecordSource.Persons = inspectionRecord.Persons;
            inspectionRecordSource.Remark = inspectionRecord.Remark;
            inspectionRecordSource.ScheduleTime = Utility.ConvertDateTime(inspectionRecord.ScheduleTime);
            inspectionRecordSource.Status = typeof(InspectionRecordStatus).GetValueByEnum(inspectionRecord.Status);

            return inspectionRecordSource;
        }
    }
}
