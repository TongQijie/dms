using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Business
{
    public interface IMaintenancePlanBusiness
    {
        void AddPlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response);

        void EditPlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response);

        void DeletePlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response);

        void QueryPlansByConditions(RestServiceRequest request, RestServiceResponse<MaintenancePlan[]> response);
    }
}
