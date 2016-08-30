using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
using Dade.Dms.Rest.ModelTransfer;
using Petecat.Extension;
using Dade.Dms.Rest.ServiceModel.Errors;
using Dade.Dms.Rest.Repository;

using System.Linq;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IDeviceInfoBusiness))]
    public class DeviceInfoBusiness : IDeviceInfoBusiness
    {
        private IDeviceInfoRepository _DeviceInfoRepository;

        private IDeviceSparePartRepository _DeviceSparePartRepository;

        private IDeviceCheckpointRepository _DeviceCheckpointRepository;

        public DeviceInfoBusiness(IDeviceInfoRepository deviceInfoRepository,
            IDeviceSparePartRepository deviceSparePartRepository,
            IDeviceCheckpointRepository deviceCheckpointRepository)
        {
            _DeviceInfoRepository = deviceInfoRepository;
            _DeviceSparePartRepository = deviceSparePartRepository;
            _DeviceCheckpointRepository = deviceCheckpointRepository;
        }

        public void AddDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response)
        {
            if (request.Body == null 
                || !request.Body.DeviceNumber.HasValue() 
                || !request.Body.DeviceName.HasValue())
            {
                throw new RequestDataInvalidException("DeviceNumber", "DeviceName");
            }

            var retVal = _DeviceInfoRepository.AddDevice(DeviceInfoTransfer.BuildDeviceInfoSource(request.Body),
                DeviceSparePartTransfer.BuildDeviceSparePartSources(request.Body.DeviceSpareParts),
                DeviceCheckpointTransfer.BuildDeviceCheckpointSources(request.Body.DeviceCheckpoints));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new DeviceAlreadyExistedException(request.Body.DeviceNumber);
                    default: throw new UndefinedException(retVal);
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
                throw new RequestDataInvalidException("DeviceNumber", "DeviceName");
            }

            var retVal = _DeviceInfoRepository.EditDevice(DeviceInfoTransfer.BuildDeviceInfoSource(request.Body),
                DeviceSparePartTransfer.BuildDeviceSparePartSources(request.Body.DeviceSpareParts),
                DeviceCheckpointTransfer.BuildDeviceCheckpointSources(request.Body.DeviceCheckpoints));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new DeviceNotFoundException(request.Body.DeviceNumber);
                    default: throw new UndefinedException(retVal);
                }
            }
        }

        public void DeleteDevice(RestServiceRequest<DeviceInfo> request, RestServiceResponse<DeviceInfo> response)
        {
            if (!request.Body.DeviceNumber.HasValue())
            {
                throw new RequestDataInvalidException("DeviceNumber");
            }

            var retVal = _DeviceInfoRepository.DeleteDevice(DeviceInfoTransfer.BuildDeviceInfoSource(request.Body));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new DeviceNotFoundException(request.Body.DeviceNumber);
                    default: throw new UndefinedException(retVal);
                }
            }
        }

        public void QueryBriefDevices(RestServiceRequest request, RestServiceResponse<DeviceInfo[]> response)
        {
            response.Paging = request.Paging;

            response.Body = DeviceInfoTransfer.BuildDeviceInfos(_DeviceInfoRepository.QueryDeviceInfos(
                request.Paging, 
                request.GetValue("DeviceNumber"),
                request.GetValue("DeviceName")));
        }


        public void QueryDetailDevices(RestServiceRequest request, RestServiceResponse<DeviceInfo[]> response)
        {
            response.Paging = request.Paging;

            var deviceInfos = DeviceInfoTransfer.BuildDeviceInfos(_DeviceInfoRepository.QueryDeviceInfos(
                request.Paging,
                request.GetValue("DeviceNumber"),
                request.GetValue("DeviceName")));

            var deviceCheckpoints = DeviceCheckpointTransfer.BuildDeviceCheckpoints(
                _DeviceCheckpointRepository.QueryDeviceCheckpoints(deviceInfos.Select(x => x.DeviceNumber).ToArray()));

            var deviceSparePartDeviceInfoMappings = DeviceSparePartDeviceInfoMappingTransfer.BuildDeviceSparePartDeviceInfoMappings(
                _DeviceSparePartRepository.QueryDeviceSpareParts(deviceInfos.Select(x => x.DeviceNumber).ToArray()));

            foreach (var deviceInfo in deviceInfos)
            {
                deviceInfo.DeviceCheckpoints = deviceCheckpoints.Where(x => x.DeviceInfo != null && x.DeviceInfo.DeviceNumber == deviceInfo.DeviceNumber).ToArray();
                deviceInfo.DeviceSpareParts = deviceSparePartDeviceInfoMappings.Where(x => x.DeviceInfo != null && x.DeviceInfo.DeviceNumber == deviceInfo.DeviceNumber)
                    .Select(x => x.DeviceSparePart).ToArray();
            }

            response.Body = deviceInfos;
        }
    }
}
