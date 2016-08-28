using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;

namespace Dade.Dms.Rest.ServiceInterface
{
    [ServiceInterface(ServiceName = "maintenance-info")]
    public interface IMaintenanceInfoService
    {
        [ServiceMethod(MethodName = "hi", IsDefaultMethod = true)]
        string Hi();

        [ServiceMethod(MethodName = "operate-maintenance-plan")]
        RestServiceResponse<MaintenancePlan> OperateMaintenancePlan(RestServiceRequest<MaintenancePlan> request);

        [ServiceMethod(MethodName = "get-maintenance-plan-list")]
        RestServiceResponse<MaintenancePlan[]> GetMaintenancePlanList(RestServiceRequest request);

        [ServiceMethod(MethodName = "operate-maintenance-record")]
        RestServiceResponse<MaintenanceRecord> OperateMaintenanceRecord(RestServiceRequest<MaintenanceRecord> request);

        [ServiceMethod(MethodName = "get-maintenance-record-list")]
        RestServiceResponse<MaintenanceRecord[]> GetMaintenanceRecordList(RestServiceRequest request);
    }
}
