using Dade.Dms.Rest.Impl;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceInterface;

using Petecat.Service.Attributes;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.ServiceImplement
{
    [AutoService(typeof(IDeviceInfoService))]
    public class DeviceInfoService : AnyServiceBase, IDeviceInfoService
    {
        private DeviceInfoImpl _DeviceInfoImpl;

        public DeviceInfoService(DeviceInfoImpl deviceInfoImpl)
        {
            _DeviceInfoImpl = deviceInfoImpl;
        }

        public string Hi()
        {
            return "Welcome to access device info service.";
        }

        public RestServiceResponse<DeviceInfo> OperateDeviceInfo(RestServiceRequest<DeviceInfo> request)
        {
            return Sandbox(request, _DeviceInfoImpl.OperateDeviceInfo);
        }

        public RestServiceResponse<DeviceInfo[]> GetDeviceInfoList(RestServiceRequest request)
        {
            return _DeviceInfoImpl.GetDeviceInfoList(request);
        }
    }
}
