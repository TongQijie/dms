using Dade.Dms.Rest.Impl.Business;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Errors;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(DeviceSparePartImpl))]
    public class DeviceSparePartImpl
    {
        private IDeviceSparePartBusiness _DeviceSparePartBusiness;

        public DeviceSparePartImpl(IDeviceSparePartBusiness deviceSparePartBusiness)
        {
            _DeviceSparePartBusiness = deviceSparePartBusiness;
        }

        public RestServiceResponse<DeviceSparePart> OperateDeviceSparePart(RestServiceRequest<DeviceSparePart> request)
        {
            var response = new RestServiceResponse<DeviceSparePart>();

            switch (request.ActionName)
            {
                case "Add": _DeviceSparePartBusiness.AddSparePart(request, response); break;
                case "Edit": _DeviceSparePartBusiness.EditSparePart(request, response); break;
                case "Delete": _DeviceSparePartBusiness.DeleteSparePart(request, response); break;
                default: throw new ActionNotSupportedException(request.ActionName);
            }

            return response;
        }

        public RestServiceResponse<DeviceSparePart[]> GetDeviceSparePartList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<DeviceSparePart[]>();

            switch (request.ActionName)
            {
                case "Brief": _DeviceSparePartBusiness.QueryDeviceSpareParts(request, response); break;
                default: throw new ActionNotSupportedException(request.ActionName);
            }

            return response;
        }
    }
}
