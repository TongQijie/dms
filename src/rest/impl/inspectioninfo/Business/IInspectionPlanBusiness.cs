using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Business
{
    public interface IInspectionPlanBusiness
    {
        void AddPlan(RestServiceRequest<InspectionPlan> request, RestServiceResponse<InspectionPlan> response);

        void EditPlan(RestServiceRequest<InspectionPlan> request, RestServiceResponse<InspectionPlan> response);

        void DeletePlan(RestServiceRequest<InspectionPlan> request, RestServiceResponse<InspectionPlan> response);

        void QueryPlansByConditions(RestServiceRequest request, RestServiceResponse<InspectionPlan[]> response);
    }
}
