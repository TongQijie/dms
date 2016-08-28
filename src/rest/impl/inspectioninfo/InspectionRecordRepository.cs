

using Dade.Dms.Rest.ServiceModel;
using Petecat.Data.Access;

namespace Dade.Dms.Rest.Impl
{
    internal class InspectionRecordRepository
    {
        //public static int AddRecord(InspectionRecord inspectionRecord)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_AddRecord");
        //    dataCommandObject.SetParameterValue("@DeviceNumber", inspectionRecord.DeviceInfo.DeviceNumber);
        //    dataCommandObject.SetParameterValue("@InspectionPlanId", inspectionRecord.InspectionTime == null ? 0 : inspectionRecord.InspectionPlan.Id);
        //    dataCommandObject.SetParameterValue("@Status", inspectionRecord.Status);
        //    dataCommandObject.SetParameterValue("@InspectionTime", inspectionRecord.InspectionTime);
        //    dataCommandObject.SetParameterValue("@Persons", inspectionRecord.Persons);
        //    dataCommandObject.SetParameterValue("@Content", inspectionRecord.Content);
        //    dataCommandObject.SetParameterValue("@Remark", inspectionRecord.Remark);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int EditRecord(InspectionRecord inspectionRecord)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_EditRecord");
        //    dataCommandObject.SetParameterValue("@Id", inspectionRecord.Id);
        //    dataCommandObject.SetParameterValue("@Status", inspectionRecord.Status);
        //    dataCommandObject.SetParameterValue("@InspectionTime", inspectionRecord.InspectionTime);
        //    dataCommandObject.SetParameterValue("@Persons", inspectionRecord.Persons);
        //    dataCommandObject.SetParameterValue("@Content", inspectionRecord.Content);
        //    dataCommandObject.SetParameterValue("@Remark", inspectionRecord.Remark);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int DeleteRecord(int recordId)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_DeleteRecord");
        //    dataCommandObject.SetParameterValue("@Id", recordId);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static InspectionRecord[] QueryRecords(int id, string deviceNumber, int planId, string persons, string[] statuses, string startTime, string endTime, Paging paging)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_QueryInspectionRecordsByConditions");
        //    dataCommandObject.SetParameterValue("@Id", id);
        //    dataCommandObject.SetParameterValue("@DeviceNumber", deviceNumber);
        //    dataCommandObject.SetParameterValue("@InspectionPlanId", planId);
        //    dataCommandObject.SetParameterValues("@Status", statuses ?? new string[] { "P", "O", "D" });
        //    dataCommandObject.SetParameterValue("@Persons", persons);
        //    dataCommandObject.SetParameterValue("@StartTime", startTime);
        //    dataCommandObject.SetParameterValue("@EndTime", endTime);
        //    dataCommandObject.SetParameterValue("@PageNumber", paging.PageNumber <= 0 ? 1 : paging.PageNumber);
        //    dataCommandObject.SetParameterValue("@PageSize", paging.PageSize <= 0 ? 10 : paging.PageSize);
        //    var result = dataCommandObject.QueryEntities<InspectionRecord>().ToArray();
        //    paging.TotalPages = (int)dataCommandObject.GetParameterValue("@TotalPages");
        //    paging.PageNumber = paging.PageNumber > paging.TotalPages ? 1 : paging.PageNumber;
        //    return result;
        //}
    }
}
