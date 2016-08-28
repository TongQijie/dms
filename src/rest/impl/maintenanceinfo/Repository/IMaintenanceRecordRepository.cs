using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Repository
{
    public interface IMaintenanceRecordRepository
    {
        int AddRecord(MaintenanceRecord maintenanceRecord);

        int EditRecord(MaintenanceRecord maintenanceRecord);

        int DeleteRecord(MaintenanceRecord maintenaceRecord);

        MaintenanceRecord[] QueryRecordsByConditions(Paging paging, int id, int maintenancePlanId, string deviceNumber, string[] statuses, string startTime, string endTime);
    }
}
