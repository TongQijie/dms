using Dade.Dms.Rest.ServiceInterface;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;
namespace Dade.Dms.Rest.ServiceImplement
{
    [AutoService(typeof(ICheckpointInfoService))]
    public class CheckpointInfoService : AnyServiceBase, ICheckpointInfoService
    {
        public string Hi()
        {
            return "Welcome to access checkpoint info service.";
        }

        public RestServiceResponse<DeviceCheckpoint> OperateDeviceCheckpoint(RestServiceRequest<DeviceCheckpoint> request)
        {
            throw new System.NotImplementedException();
        }

        public RestServiceResponse<DeviceCheckpoint[]> GetDeviceCheckpointList(RestServiceRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
