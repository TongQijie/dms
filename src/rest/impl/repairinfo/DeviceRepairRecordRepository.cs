using Dade.Dms.Rest.ServiceModel;
using Petecat.Data.Access;

namespace Dade.Dms.Rest.Imp
{
    internal class DeviceRepairRecordRepository
    {
        //public static int AddRecord(RepairRecord repairRecord)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("RepairInfo_AddRecord");
        //    dataCommandObject.SetParameterValue("@DeviceNumber", repairRecord.DeviceInfo.DeviceNumber);
        //    dataCommandObject.SetParameterValue("@Status", repairRecord.Status);
        //    dataCommandObject.SetParameterValue("@FaultTime", repairRecord.FaultTime);
        //    dataCommandObject.SetParameterValue("@FaultDescription", repairRecord.FaultDescription);
        //    dataCommandObject.SetParameterValue("@RepairTime", repairRecord.RepairTime);
        //    dataCommandObject.SetParameterValue("@Persons", repairRecord.Persons);
        //    dataCommandObject.SetParameterValue("@Content", repairRecord.Content);
        //    dataCommandObject.SetParameterValue("@Remark", repairRecord.Remark);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int EditRecord(RepairRecord repairRecord)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("RepairInfo_EditRecord");
        //    dataCommandObject.SetParameterValue("@Id", repairRecord.Id);
        //    dataCommandObject.SetParameterValue("@Status", repairRecord.Status);
        //    dataCommandObject.SetParameterValue("@FaultTime", repairRecord.FaultTime);
        //    dataCommandObject.SetParameterValue("@FaultDescription", repairRecord.FaultDescription);
        //    dataCommandObject.SetParameterValue("@RepairTime", repairRecord.RepairTime);
        //    dataCommandObject.SetParameterValue("@Persons", repairRecord.Persons);
        //    dataCommandObject.SetParameterValue("@Content", repairRecord.Content);
        //    dataCommandObject.SetParameterValue("@Remark", repairRecord.Remark);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int DeleteRecord(int recordId)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("RepairInfo_DeleteRecord");
        //    dataCommandObject.SetParameterValue("@Id", recordId);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static RepairRecord[] QueryRecords(Paging paging, int id, string deviceNumber, string persons, string[] statuses, string startTime, string endTime)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("RepairInfo_QueryRepairRecordsByConditions");
        //    dataCommandObject.SetParameterValue("@Id", id);
        //    dataCommandObject.SetParameterValue("@DeviceNumber", deviceNumber);
        //    dataCommandObject.SetParameterValues("@Status", statuses ?? new string[] { "P", "O", "D" });
        //    dataCommandObject.SetParameterValue("@Persons", persons);
        //    dataCommandObject.SetParameterValue("@StartTime", startTime);
        //    dataCommandObject.SetParameterValue("@EndTime", endTime);
        //    dataCommandObject.SetParameterValue("@PageNumber", paging.PageNumber <= 0 ? 1 : paging.PageNumber);
        //    dataCommandObject.SetParameterValue("@PageSize", paging.PageSize <= 0 ? 10 : paging.PageSize);
        //    var result = dataCommandObject.QueryEntities<RepairRecord>().ToArray();
        //    paging.TotalPages = (int)dataCommandObject.GetParameterValue("@TotalPages");
        //    paging.PageNumber = paging.PageNumber > paging.TotalPages ? 1 : paging.PageNumber;
        //    return result;
        //}
    }
}
