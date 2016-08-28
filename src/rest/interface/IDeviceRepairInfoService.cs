using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;

namespace Dade.Dms.Rest.ServiceInterface
{
    [ServiceInterface(ServiceName = "repair-info")]
    public interface IDeviceRepairInfoService
    {
        [ServiceMethod(MethodName = "hi", IsDefaultMethod = true)]
        string Hi();

        [ServiceMethod(MethodName = "operate-repair-record")]
        RestServiceResponse<DeviceRepairRecord> OperateRepairRecord(RestServiceRequest<DeviceRepairRecord> request);

        [ServiceMethod(MethodName = "get-repair-record-list")]
        RestServiceResponse<DeviceRepairRecord[]> GetRepairRecordList(RestServiceRequest request);
    }
}
