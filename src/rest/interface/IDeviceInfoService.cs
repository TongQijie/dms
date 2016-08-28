using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;

namespace Dade.Dms.Rest.ServiceInterface
{
    [ServiceInterface(ServiceName = "device-info")]
    public interface IDeviceInfoService
    {
        [ServiceMethod(MethodName = "hi", IsDefaultMethod = true)]
        string Hi();

        [ServiceMethod(MethodName = "operate-device-info")]
        RestServiceResponse<DeviceInfo> OperateDeviceInfo(RestServiceRequest<DeviceInfo> request);

        [ServiceMethod(MethodName = "get-device-info-list")]
        RestServiceResponse<DeviceInfo[]> GetDeviceInfoList(RestServiceRequest request);
    }
}
