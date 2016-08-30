using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Business;
using Dade.Dms.Rest.ServiceModel;

using Petecat.IoC.Attributes;
using Dade.Dms.Rest.ServiceModel.Errors;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(DeviceInfoImpl))]
    public class DeviceInfoImpl
    {
        private IDeviceInfoBusiness _DeviceInfoBusiness;

        public DeviceInfoImpl(IDeviceInfoBusiness deviceInfoBusiness)
        {
            _DeviceInfoBusiness = deviceInfoBusiness;
        }

        public RestServiceResponse<DeviceInfo> OperateDeviceInfo(RestServiceRequest<DeviceInfo> request)
        {
            var response = new RestServiceResponse<DeviceInfo>();

            switch (request.ActionName)
            {
                case "Add": _DeviceInfoBusiness.AddDevice(request, response); break;
                case "Edit": _DeviceInfoBusiness.EditDevice(request, response); break;
                case "Delete": _DeviceInfoBusiness.DeleteDevice(request, response); break;
                default: throw new ActionNotSupportedException(request.ActionName);
            }

            return response;
        }

        public RestServiceResponse<DeviceInfo[]> GetDeviceInfoList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<DeviceInfo[]>();

            switch (request.ActionName)
            {
                case "Brief": _DeviceInfoBusiness.QueryBriefDevices(request, response); break;
                case "Detail": _DeviceInfoBusiness.QueryDetailDevices(request, response); break;
                default: throw new ActionNotSupportedException(request.ActionName);
            }

            return response;
        }
    }
}
