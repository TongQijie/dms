using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl.Repository
{
    [AutoResolvable(typeof(IMaintenanceRecordRepository))]
    public class MaintenanceRecordRepository : IMaintenanceRecordRepository
    {
        public int AddRecord(MaintenanceRecord maintenanceRecord)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecord(MaintenanceRecord maintenaceRecord)
        {
            throw new NotImplementedException();
        }

        public int EditRecord(MaintenanceRecord maintenanceRecord)
        {
            throw new NotImplementedException();
        }

        public MaintenanceRecord[] QueryRecordsByConditions(Paging paging, int id, int maintenancePlanId, string deviceNumber, string[] statuses, string startTime, string endTime)
        {
            throw new NotImplementedException();
        }
    }
}
