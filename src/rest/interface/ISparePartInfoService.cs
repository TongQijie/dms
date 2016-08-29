using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;

namespace Dade.Dms.Rest.ServiceInterface
{
    [ServiceInterface(ServiceName = "spare-part-info")]
    public interface ISparePartInfoService
    {
        [ServiceMethod(MethodName = "hi", IsDefaultMethod = true)]
        string Hi();

        [ServiceMethod(MethodName = "operate-spare-part")]
        RestServiceResponse<DeviceSparePart> OperateDeviceSparePart(RestServiceRequest<DeviceSparePart> request);

        [ServiceMethod(MethodName = "get-spart-part-list")]
        RestServiceResponse<DeviceSparePart[]> GetDeviceSparePartList(RestServiceRequest request);
    }
}
