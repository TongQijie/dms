using Dade.Dms.Rest.Impl;
using Dade.Dms.Rest.ServiceInterface;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;

namespace Dade.Dms.Rest.ServiceImplement
{
    [AutoService(typeof(IMaintenanceInfoService))]
    public class MaintenanceInfoService : AnyServiceBase, IMaintenanceInfoService
    {
        private MaintenancePlanImpl _PlanImpl = null;

        private MaintenanceRecordImpl _RecordImpl = null;

        public MaintenanceInfoService(MaintenancePlanImpl planImpl, MaintenanceRecordImpl recordImpl)
        {
            _PlanImpl = planImpl;
            _RecordImpl = recordImpl;
        }

        public string Hi()
        {
            return "Welcome to access maintenance info service.";
        }

        public RestServiceResponse<MaintenancePlan> OperateMaintenancePlan(RestServiceRequest<MaintenancePlan> request)
        {
            return Sandbox(request, _PlanImpl.OperateMaintenancePlan);
        }

        public RestServiceResponse<MaintenancePlan[]> GetMaintenancePlanList(RestServiceRequest request)
        {
            return Sandbox(request, _PlanImpl.GetMaintenancePlanList);
        }

        public RestServiceResponse<MaintenanceRecord> OperateMaintenanceRecord(RestServiceRequest<MaintenanceRecord> request)
        {
            return Sandbox(request, _RecordImpl.OperateMaintenanceRecord);
        }

        public RestServiceResponse<MaintenanceRecord[]> GetMaintenanceRecordList(RestServiceRequest request)
        {
            return Sandbox(request, _RecordImpl.GetMaintenanceRecordList);
        }
    }
}
