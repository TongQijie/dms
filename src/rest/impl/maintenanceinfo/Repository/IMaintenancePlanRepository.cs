using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Repository
{
    public interface IMaintenancePlanRepository
    {
        int AddPlan(MaintenancePlanSource maintenancePlanSource, MaintenanceRecordSource[] maintenanceRecordSources, 
            DeviceCheckpointSource[] deviceCheckpointSources, DeviceSparePartSource[] deviceSparePartSources);

        int EditPlan(MaintenancePlanSource maintenancePlanSource, MaintenanceRecordSource[] maintenanceRecordSources,
            DeviceCheckpointSource[] deviceCheckpointSources, DeviceSparePartSource[] deviceSparePartSources);

        int DeletePlan(MaintenancePlanSource maintenancePlanSource);

        MaintenancePlanSource[] QueryMaintenancePlans(Paging paging, int id, string deviceNumber);

    }
}
