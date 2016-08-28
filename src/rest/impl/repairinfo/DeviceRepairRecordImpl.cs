using Dade.Dms.Rest.Imp.Business;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Imp
{
    [AutoResolvable(typeof(DeviceRepairRecordImpl))]
    public class DeviceRepairRecordImpl
    {
        private IDeviceRepairRecordBusiness _DeviceRepairRecordBusiness;

        public DeviceRepairRecordImpl(IDeviceRepairRecordBusiness deviceRepairRecordBusiness)
        {
            _DeviceRepairRecordBusiness = deviceRepairRecordBusiness;
        }

        public RestServiceResponse<DeviceRepairRecord> OperateRepairRecord(RestServiceRequest<DeviceRepairRecord> request)
        {
            var response = new RestServiceResponse<DeviceRepairRecord>();

            switch (request.ActionName)
            {
                case "Add": _DeviceRepairRecordBusiness.AddRecord(request, response); break;
                case "Edit": _DeviceRepairRecordBusiness.EditRecord(request, response); break;
                case "Delete": _DeviceRepairRecordBusiness.DeleteRecord(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }

        public RestServiceResponse<DeviceRepairRecord[]> GetMaintenanceRecordList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<DeviceRepairRecord[]>();

            switch (request.ActionName)
            {
                case "ByConditions": _DeviceRepairRecordBusiness.QueryRecordsByConditions(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }
    }
}
