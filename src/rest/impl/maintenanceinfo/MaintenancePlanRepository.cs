using Dade.Dms.Rest.ServiceModel;
using Petecat.Data.Access;

namespace Dade.Dms.Rest.Impl
{
    internal class MaintenancePlanRepository
    {
        //public static int AddPlan(MaintenancePlan maintenancePlan)
        //{
        //    var retVal = 0;

        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_AddPlan");
        //    dataCommandObject.DatabaseObject.ExecuteTransaction((db) =>
        //    {
        //        dataCommandObject.SetParameterValue("@DeviceNumber", maintenancePlan.DeviceInfo.DeviceNumber);
        //        dataCommandObject.SetParameterValue("@DeviceName", maintenancePlan.DeviceInfo == null ? null : maintenancePlan.DeviceInfo.DeviceName);
        //        dataCommandObject.SetParameterValue("@Flag", (int)maintenancePlan.Flag);
        //        dataCommandObject.SetParameterValue("@PlanValue", maintenancePlan.PlanValue);
        //        dataCommandObject.SetParameterValue("@Content", maintenancePlan.Content);
        //        db.ExecuteNonQuery(dataCommandObject);
        //        if((retVal = (int)dataCommandObject.GetParameterValue("@RetVal")) < 0)
        //        {
        //            return false;
        //        }

        //        dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_AddRecord");
        //        dataCommandObject.SetParameterValue("@DeviceNumber", maintenancePlan.DeviceInfo.DeviceNumber);
        //        dataCommandObject.SetParameterValue("@MaintenancePlanId", retVal);
        //        dataCommandObject.SetParameterValue("@Status", "P");
        //        dataCommandObject.SetParameterValue("@MaintenanceTime", null);
        //        dataCommandObject.SetParameterValue("@Persons", null);
        //        dataCommandObject.SetParameterValue("@Content", null);
        //        dataCommandObject.SetParameterValue("@Remark", null);
        //        db.ExecuteNonQuery(dataCommandObject);
        //        if((retVal = (int)dataCommandObject.GetParameterValue("@RetVal")) < 0)
        //        {
        //            return false;
        //        }

        //        return true;
        //    });

        //    return retVal;
        //}

        //public static int EditPlan(MaintenancePlan maintenancePlan)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_EditPlan");
        //    dataCommandObject.SetParameterValue("@Id", maintenancePlan.Id);
        //    dataCommandObject.SetParameterValue("@DeviceNumber", maintenancePlan.DeviceInfo == null ? null : maintenancePlan.DeviceInfo.DeviceNumber);
        //    dataCommandObject.SetParameterValue("@DeviceName", maintenancePlan.DeviceInfo == null ? null : maintenancePlan.DeviceInfo.DeviceName);
        //    dataCommandObject.SetParameterValue("@Flag", (int)maintenancePlan.Flag);
        //    dataCommandObject.SetParameterValue("@PlanValue", maintenancePlan.PlanValue);
        //    dataCommandObject.SetParameterValue("@Content", maintenancePlan.Content);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int DeletePlan(int planId)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_DeletePlan");
        //    dataCommandObject.SetParameterValue("@Id", planId);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static MaintenancePlan[] QueryPlansByConditions(int id, string deviceNumber, string deviceName, Paging paging)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("MaintenanceInfo_QueryMaintenancePlansByConditions");
        //    dataCommandObject.SetParameterValue("@Id", id);
        //    dataCommandObject.SetParameterValue("@DeviceNumber", deviceNumber);
        //    dataCommandObject.SetParameterValue("@DeviceName", deviceName);
        //    dataCommandObject.SetParameterValue("@PageNumber", paging.PageNumber <= 0 ? 1 : paging.PageNumber);
        //    dataCommandObject.SetParameterValue("@PageSize", paging.PageSize <= 0 ? 10 : paging.PageSize);
        //    var result = dataCommandObject.QueryEntities<MaintenancePlan>().ToArray();
        //    paging.TotalPages = (int)dataCommandObject.GetParameterValue("@TotalPages");
        //    paging.PageNumber = paging.PageNumber > paging.TotalPages ? 1 : paging.PageNumber;
        //    return result;
        //}
    }
}
