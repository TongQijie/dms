using Dade.Dms.Rest.ServiceModel;

using Petecat.Data.Access;

namespace Dade.Dms.Rest.Impl
{
    internal class InspectionPlanRepository
    {
        //public static int AddPlan(InspectionPlan inspectionPlan)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_AddPlan");
        //    dataCommandObject.SetParameterValue("@DeviceNumber", inspectionPlan.DeviceInfo == null ? null : inspectionPlan.DeviceInfo.DeviceNumber);
        //    dataCommandObject.SetParameterValue("@DeviceName", inspectionPlan.DeviceInfo == null ? null : inspectionPlan.DeviceInfo.DeviceName);
        //    dataCommandObject.SetParameterValue("@Flag", (int)inspectionPlan.Flag);
        //    dataCommandObject.SetParameterValue("@PlanValue", inspectionPlan.PlanValue);
        //    dataCommandObject.SetParameterValue("@Content", inspectionPlan.Content);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int EditPlan(InspectionPlan inspectionPlan)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_EditPlan");
        //    dataCommandObject.SetParameterValue("@Id", inspectionPlan.Id);
        //    dataCommandObject.SetParameterValue("@DeviceNumber", inspectionPlan.DeviceInfo == null ? null : inspectionPlan.DeviceInfo.DeviceNumber);
        //    dataCommandObject.SetParameterValue("@DeviceName", inspectionPlan.DeviceInfo == null ? null : inspectionPlan.DeviceInfo.DeviceName);
        //    dataCommandObject.SetParameterValue("@Flag", (int)inspectionPlan.Flag);
        //    dataCommandObject.SetParameterValue("@PlanValue", inspectionPlan.PlanValue);
        //    dataCommandObject.SetParameterValue("@Content", inspectionPlan.Content);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static int DeletePlan(int planId)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_DeletePlan");
        //    dataCommandObject.SetParameterValue("@Id", planId);
        //    dataCommandObject.ExecuteNonQuery();
        //    return (int)dataCommandObject.GetParameterValue("@RetVal");
        //}

        //public static InspectionPlan[] QueryPlansByConditions(int id, string deviceNumber, string deviceName, Paging paging)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("InspectionInfo_QueryInspectionPlansByConditions");
        //    dataCommandObject.SetParameterValue("@Id", id);
        //    dataCommandObject.SetParameterValue("@DeviceNumber", deviceNumber);
        //    dataCommandObject.SetParameterValue("@DeviceName", deviceName);
        //    dataCommandObject.SetParameterValue("@PageNumber", paging.PageNumber <= 0 ? 1 : paging.PageNumber);
        //    dataCommandObject.SetParameterValue("@PageSize", paging.PageSize <= 0 ? 10 : paging.PageSize);
        //    var result = dataCommandObject.QueryEntities<InspectionPlan>().ToArray();
        //    paging.TotalPages = (int)dataCommandObject.GetParameterValue("@TotalPages");
        //    paging.PageNumber = paging.PageNumber > paging.TotalPages ? 1 : paging.PageNumber;
        //    return result;
        //}
    }
}
