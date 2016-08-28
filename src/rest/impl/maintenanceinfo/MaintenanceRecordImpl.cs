using Dade.Dms.Rest.Impl.Business;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(MaintenanceRecordImpl))]
    public class MaintenanceRecordImpl
    {
        private IMaintenanceRecordBusiness _MaintenanceRecordBusiness;

        public MaintenanceRecordImpl(IMaintenanceRecordBusiness maintenanceRecordBusiness)
        {
            _MaintenanceRecordBusiness = maintenanceRecordBusiness;
        }

        public RestServiceResponse<MaintenanceRecord> OperateMaintenanceRecord(RestServiceRequest<MaintenanceRecord> request)
        {
            var response = new RestServiceResponse<MaintenanceRecord>();

            switch (request.ActionName)
            {
                case "Add": _MaintenanceRecordBusiness.AddRecord(request, response); break;
                case "Edit": _MaintenanceRecordBusiness.EditRecord(request, response); break;
                case "Delete": _MaintenanceRecordBusiness.DeleteRecord(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }

        public RestServiceResponse<MaintenanceRecord[]> GetMaintenanceRecordList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<MaintenanceRecord[]>();

            switch (request.ActionName)
            {
                case "ByConditions": _MaintenanceRecordBusiness.QueryRecordsByConditions(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }
    }
}
