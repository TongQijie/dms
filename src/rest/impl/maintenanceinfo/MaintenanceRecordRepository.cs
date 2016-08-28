using Dade.Dms.Rest.ServiceModel;

using Petecat.Data.Access;

namespace Dade.Dms.Rest.Impl
{
    internal class MaintenanceRecordRepository
    {
        //public static int AddRecord(MaintenanceRecord maintenanceRecord)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_AddRecord");
        //    dataCommandObject.SetParameterValue("@DeviceNumber", maintenanceRecord.DeviceInfo.DeviceNumber);
        //    dataCommandObject.SetParameterValue("@MaintenancePlanId", maintenanceRecord.MaintenancePlan == null ? 0 : maintenanceRecord.MaintenancePlan.Id);
        //    dataCommandObject.SetParameterValue("@Status", maintenanceRecord.Status);
        //    dataCommandObject.SetParameterValue("@MaintenanceTime", maintenanceRecord.MaintenanceTime);
        //    dataCommandObject.SetParameterValue("@Persons", maintenanceRecord.Persons);
        //    dataCommandObject.SetParameterValue("@Content", maintenanceRecord.Content);
        //    dataCommandObject.SetParameterValue("@Remark", maintenanceRecord.Remark);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int EditRecord(MaintenanceRecord maintenanceRecord)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_EditRecord");
        //    dataCommandObject.SetParameterValue("@Id", maintenanceRecord.Id);
        //    dataCommandObject.SetParameterValue("@Status", maintenanceRecord.Status);
        //    dataCommandObject.SetParameterValue("@MaintenanceTime", maintenanceRecord.MaintenanceTime);
        //    dataCommandObject.SetParameterValue("@Persons", maintenanceRecord.Persons);
        //    dataCommandObject.SetParameterValue("@Content", maintenanceRecord.Content);
        //    dataCommandObject.SetParameterValue("@Remark", maintenanceRecord.Remark);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int DeleteRecord(int recordId)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_DeleteRecord");
        //    dataCommandObject.SetParameterValue("@Id", recordId);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static MaintenanceRecord[] QueryRecords(int id, string deviceNumber, int planId, string persons, string[] statuses, string startTime, string endTime, Paging paging)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_QueryMaintenanceRecordsByConditions");
        //    dataCommandObject.SetParameterValue("@Id", id);
        //    dataCommandObject.SetParameterValue("@DeviceNumber", deviceNumber);
        //    dataCommandObject.SetParameterValue("@MaintenancePlanId", planId);
        //    dataCommandObject.SetParameterValues("@Status", statuses ?? new string[] { "P", "O", "D" });
        //    dataCommandObject.SetParameterValue("@Persons", persons);
        //    dataCommandObject.SetParameterValue("@StartTime", startTime);
        //    dataCommandObject.SetParameterValue("@EndTime", endTime);
        //    dataCommandObject.SetParameterValue("@PageNumber", paging.PageNumber <= 0 ? 1 : paging.PageNumber);
        //    dataCommandObject.SetParameterValue("@PageSize", paging.PageSize <= 0 ? 10 : paging.PageSize);
        //    var result = dataCommandObject.QueryEntities<MaintenanceRecord>().ToArray();
        //    paging.TotalPages = (int)dataCommandObject.GetParameterValue("@TotalPages");
        //    paging.PageNumber = paging.PageNumber > paging.TotalPages ? 1 : paging.PageNumber;
        //    return result;
        //}
    }
}
