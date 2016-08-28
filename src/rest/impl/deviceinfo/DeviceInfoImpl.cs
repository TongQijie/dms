using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Repository;
using Dade.Dms.Rest.Impl.Business;
using Dade.Dms.Rest.ServiceModel;

using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(DeviceInfoImpl))]
    public class DeviceInfoImpl
    {
        private IDeviceInfoBusiness _DeviceInfoBusiness;

        public DeviceInfoImpl(IDeviceInfoRepository deviceInfoRepository,
            IDeviceInfoBusiness deviceInfoBusiness)
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
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }

        public RestServiceResponse<DeviceInfo[]> GetDeviceInfoList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<DeviceInfo[]>();

            switch (request.ActionName)
            {
                case "ByConditions": _DeviceInfoBusiness.QueryDevicesByConditions(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }
    }
}
