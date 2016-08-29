using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Repository
{
    public interface IMaintenancePlanRepository
    {
        int AddPlan(MaintenancePlanSource maintenancePlan, MaintenanceRecordSource[] maintenanceRecords);

        int EditPlan(MaintenancePlan maintenancePlan);

        int DeletePlan(MaintenancePlan maintenancePlan);

        MaintenancePlan[] QueryPlansByConditions(Paging paging, int id, string deviceNumber);
    }
}
