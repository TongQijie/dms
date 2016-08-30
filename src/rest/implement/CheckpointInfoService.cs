using Dade.Dms.Rest.Impl;
using Dade.Dms.Rest.ServiceInterface;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;
namespace Dade.Dms.Rest.ServiceImplement
{
    [AutoService(typeof(ICheckpointInfoService))]
    public class CheckpointInfoService : AnyServiceBase, ICheckpointInfoService
    {
        private DeviceCheckpointImpl _DeviceCheckpointImpl;

        public CheckpointInfoService(DeviceCheckpointImpl deviceCheckpointImpl)
        {
            _DeviceCheckpointImpl = deviceCheckpointImpl;
        }

        public string Hi()
        {
            return "Welcome to access checkpoint info service.";
        }

        public RestServiceResponse<DeviceCheckpoint> OperateDeviceCheckpoint(RestServiceRequest<DeviceCheckpoint> request)
        {
            return Sandbox(request, _DeviceCheckpointImpl.OperateDeviceCheckpoint);
        }

        public RestServiceResponse<DeviceCheckpoint[]> GetDeviceCheckpointList(RestServiceRequest request)
        {
            return Sandbox(request, _DeviceCheckpointImpl.GetDeviceCheckpointList);
        }
    }
}
