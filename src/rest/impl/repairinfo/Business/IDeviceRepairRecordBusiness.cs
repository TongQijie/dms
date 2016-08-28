using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Imp.Business
{
    public interface IDeviceRepairRecordBusiness
    {
        void AddRecord(RestServiceRequest<DeviceRepairRecord> request, RestServiceResponse<DeviceRepairRecord> response);

        void EditRecord(RestServiceRequest<DeviceRepairRecord> request, RestServiceResponse<DeviceRepairRecord> response);

        void DeleteRecord(RestServiceRequest<DeviceRepairRecord> request, RestServiceResponse<DeviceRepairRecord> response);

        void QueryRecordsByConditions(RestServiceRequest request, RestServiceResponse<DeviceRepairRecord[]> response);
    }
}
