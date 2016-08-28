using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Business
{
    public interface IDeviceInfoBusiness
    {
        void AddDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response);

        void EditDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response);

        void DeleteDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response);

        void QueryDevicesByConditions(RestServiceRequest request, RestServiceResponse<DeviceInfo[]> response);
    }
}
