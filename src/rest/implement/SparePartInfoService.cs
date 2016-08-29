using Dade.Dms.Rest.Impl;
using Dade.Dms.Rest.ServiceInterface;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;
namespace Dade.Dms.Rest.ServiceImplement
{
    [AutoService(typeof(ISparePartInfoService))]
    public class SparePartInfoService : AnyServiceBase, ISparePartInfoService
    {
        private DeviceSparePartImpl _DeviceSparePartImpl;

        public SparePartInfoService(DeviceSparePartImpl deviceSparePartImpl)
        {
            _DeviceSparePartImpl = deviceSparePartImpl;
        }

        public string Hi()
        {
            return "Welcome to access spare part info service.";
        }

        public RestServiceResponse<DeviceSparePart> OperateDeviceSparePart(RestServiceRequest<DeviceSparePart> request)
        {
            return Sandbox(request, _DeviceSparePartImpl.OperateDeviceSparePart);
        }

        public RestServiceResponse<DeviceSparePart[]> GetDeviceSparePartList(RestServiceRequest request)
        {
            return Sandbox(request, _DeviceSparePartImpl.GetDeviceSparePartList);
        }
    }
}
