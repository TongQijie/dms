using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Repository
{
    public interface IInspectionPlanRepository
    {
        int AddPlan(InspectionPlan inspectionPlan);

        int EditPlan(InspectionPlan inspectionPlan);

        int DeletePlan(InspectionPlan inspectionPlan);

        InspectionPlan[] QueryPlansByConditions(Paging paging, int id, string deviceNumber);
    }
}
