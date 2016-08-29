using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;

namespace Dade.Dms.Rest.ServiceInterface
{
    [ServiceInterface(ServiceName = "checkpoint-info")]
    public interface ICheckpointInfoService
    {
        [ServiceMethod(MethodName = "hi", IsDefaultMethod = true)]
        string Hi();

        [ServiceMethod(MethodName = "operate-checkpoint")]
        RestServiceResponse<DeviceCheckpoint> OperateDeviceCheckpoint(RestServiceRequest<DeviceCheckpoint> request);

        [ServiceMethod(MethodName = "get-checkpoint-list")]
        RestServiceResponse<DeviceCheckpoint[]> GetDeviceCheckpointList(RestServiceRequest request);
    }
}
