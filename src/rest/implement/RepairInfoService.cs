using Dade.Dms.Rest.ServiceInterface;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.Imp;

using Petecat.Service.Attributes;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.ServiceImplement
{
    [AutoService(typeof(IDeviceRepairInfoService))]
    public class DeviceRepairInfoService : AnyServiceBase, IDeviceRepairInfoService
    {
        private DeviceRepairRecordImpl _RepairRecordImpl;

        public DeviceRepairInfoService(DeviceRepairRecordImpl repairRecordImpl)
        {
            _RepairRecordImpl = repairRecordImpl;
        }

        public string Hi()
        {
            return "Welcome to access repair info service.";
        }

        public RestServiceResponse<DeviceRepairRecord> OperateRepairRecord(RestServiceRequest<DeviceRepairRecord> request)
        {
            return _RepairRecordImpl.OperateRepairRecord(request);
        }

        public RestServiceResponse<DeviceRepairRecord[]> GetRepairRecordList(RestServiceRequest request)
        {
            return _RepairRecordImpl.GetMaintenanceRecordList(request);
        }
    }
}
