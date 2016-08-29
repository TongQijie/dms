using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
namespace Dade.Dms.Rest.Impl.Business
{
    public interface IDeviceCheckpointBusiness
    {
        void AddCheckpoint(RestServiceRequest<DeviceCheckpoint> request, RestServiceResponse<DeviceCheckpoint> response);

        void EditCheckpoint(RestServiceRequest<DeviceCheckpoint> request, RestServiceResponse<DeviceCheckpoint> response);

        void DeleteCheckpoint(RestServiceRequest<DeviceCheckpoint> request, RestServiceResponse<DeviceCheckpoint> response);

        void QueryDeviceCheckpoints(RestServiceRequest request, RestServiceResponse<DeviceCheckpoint[]> response);
    }
}
