using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
using Dade.Dms.Rest.Impl.Repository;
using Petecat.Extension;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IDeviceInfoBusiness))]
    public class DeviceInfoBusiness : IDeviceInfoBusiness
    {
        private IDeviceInfoRepository _DeviceInfoRepository;

        public DeviceInfoBusiness(IDeviceInfoRepository deviceInfoRepository)
        {
            _DeviceInfoRepository = deviceInfoRepository;
        }

        public void AddDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response)
        {
            if (request.Body == null 
                || !request.Body.DeviceNumber.HasValue() 
                || !request.Body.DeviceName.HasValue())
            {
                throw new RestException("", "device number and device name cannot be empty.");
            }

            var retVal = _DeviceInfoRepository.AddDevice(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' already exists.", request.Body.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }

            response.Body = new DeviceInfo() { DeviceNumber = request.Body.DeviceNumber };
        }

        public void EditDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response)
        {
            if (request.Body == null
                || !request.Body.DeviceNumber.HasValue()
                || !request.Body.DeviceName.HasValue())
            {
                throw new RestException("", "device number and device name cannot be empty.");
            }

            var retVal = _DeviceInfoRepository.EditDevice(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' dones not exist.", request.Body.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void DeleteDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response)
        {
            if (!request.Body.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _DeviceInfoRepository.DeleteDevice(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void QueryDevicesByConditions(RestServiceRequest request, RestServiceResponse<DeviceInfo[]> response)
        {
            response.Paging = request.Paging;

            response.Body = _DeviceInfoRepository.QueryDevicesByConditions(
                request.Paging, 
                request.GetValue("DeviceNumber"),
                request.GetValue("DeviceName"));
        }
    }
}
