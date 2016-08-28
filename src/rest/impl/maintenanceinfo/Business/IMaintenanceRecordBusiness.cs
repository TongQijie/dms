using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Business
{
    public interface IMaintenanceRecordBusiness
    {
        void AddRecord(RestServiceRequest<MaintenanceRecord> request, RestServiceResponse<MaintenanceRecord> response);

        void EditRecord(RestServiceRequest<MaintenanceRecord> request, RestServiceResponse<MaintenanceRecord> response);

        void DeleteRecord(RestServiceRequest<MaintenanceRecord> request, RestServiceResponse<MaintenanceRecord> response);

        void QueryRecordsByConditions(RestServiceRequest request, RestServiceResponse<MaintenanceRecord[]> response);
    }
}
