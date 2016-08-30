using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
using Petecat.Extension;
using Dade.Dms.Rest.ServiceModel.Errors;
using Dade.Dms.Rest.ModelTransfer;
using Dade.Dms.Rest.Repository;
namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IDeviceCheckpointBusiness))]
    public class DeviceCheckpointBusiness : IDeviceCheckpointBusiness
    {
        private IDeviceCheckpointRepository _DeviceCheckpointRepository;

        public DeviceCheckpointBusiness(IDeviceCheckpointRepository deviceCheckpointRepository)
        {
            _DeviceCheckpointRepository = deviceCheckpointRepository;
        }

        public void AddCheckpoint(RestServiceRequest<DeviceCheckpoint> request, RestServiceResponse<DeviceCheckpoint> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue()
                || !request.Body.Description.HasValue())
            {
                throw new RequestDataInvalidException("DeviceNumber", "Description");
            }

            var retVal = _DeviceCheckpointRepository.AddCheckpoint(DeviceCheckpointTransfer.BuildDeviceCheckpointSource(request.Body));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    default: throw new UndefinedException(retVal);
                }
            }

            response.Body = new DeviceCheckpoint() { Id = retVal };
        }

        public void EditCheckpoint(RestServiceRequest<DeviceCheckpoint> request, RestServiceResponse<DeviceCheckpoint> response)
        {
            if (request.Body == null
                || request.Body.Id <= 0
                || !request.Body.Description.HasValue())
            {
                throw new RequestDataInvalidException("Id", "Description");
            }

            var retVal = _DeviceCheckpointRepository.EditCheckpoint(DeviceCheckpointTransfer.BuildDeviceCheckpointSource(request.Body));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    default: throw new UndefinedException(retVal);
                }
            }
        }

        public void DeleteCheckpoint(RestServiceRequest<DeviceCheckpoint> request, RestServiceResponse<DeviceCheckpoint> response)
        {
            if (request.Body == null
                || request.Body.Id <= 0)
            {
                throw new RequestDataInvalidException("DeviceNumber");
            }

            var retVal = _DeviceCheckpointRepository.DeleteCheckpoint(DeviceCheckpointTransfer.BuildDeviceCheckpointSource(request.Body));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    default: throw new UndefinedException(retVal);
                }
            }
        }

        public void QueryDeviceCheckpoints(RestServiceRequest request, RestServiceResponse<DeviceCheckpoint[]> response)
        {
            response.Paging = request.Paging;

            response.Body = DeviceCheckpointTransfer.BuildDeviceCheckpoints(_DeviceCheckpointRepository.QueryDeviceCheckpoints(
                request.Paging,
                request.GetValue<int>("DeviceCheckpointId", 0),
                request.GetValue("DeviceNumber")));
        }
    }
}
