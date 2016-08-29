using Dade.Dms.Rest.Impl.Business;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Errors;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(DeviceCheckpointImpl))]
    public class DeviceCheckpointImpl
    {
        private IDeviceCheckpointBusiness _DeviceCheckpointBusiness;

        public DeviceCheckpointImpl(IDeviceCheckpointBusiness deviceCheckpointBusiness)
        {
            _DeviceCheckpointBusiness = deviceCheckpointBusiness;
        }

        public RestServiceResponse<DeviceCheckpoint> OperateDeviceSparePart(RestServiceRequest<DeviceCheckpoint> request)
        {
            var response = new RestServiceResponse<DeviceCheckpoint>();

            switch (request.ActionName)
            {
                case "Add": _DeviceCheckpointBusiness.AddCheckpoint(request, response); break;
                case "Edit": _DeviceCheckpointBusiness.EditCheckpoint(request, response); break;
                case "Delete": _DeviceCheckpointBusiness.DeleteCheckpoint(request, response); break;
                default: throw new ActionNotSupportedException(request.ActionName);
            }

            return response;
        }

        public RestServiceResponse<DeviceCheckpoint[]> GetDeviceSparePartList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<DeviceCheckpoint[]>();

            switch (request.ActionName)
            {
                case "Brief": _DeviceCheckpointBusiness.QueryDeviceCheckpoints(request, response); break;
                default: throw new ActionNotSupportedException(request.ActionName);
            }

            return response;
        }
    }
}
