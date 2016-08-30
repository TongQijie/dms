using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
using Petecat.Extension;
using Dade.Dms.Rest.ServiceModel.Errors;
using Dade.Dms.Rest.ModelTransfer;
using Dade.Dms.Rest.Repository;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IDeviceSparePartBusiness))]
    public class DeviceSparePartBusiness : IDeviceSparePartBusiness
    {
        private IDeviceSparePartRepository _DeviceSparePartRepository;

        public DeviceSparePartBusiness(IDeviceSparePartRepository deviceSparePartRepository)
        {
            _DeviceSparePartRepository = deviceSparePartRepository;
        }

        public void AddSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response)
        {
            if (request.Body == null
                || !request.Body.SparePartNumber.HasValue()
                || !request.Body.SparePartName.HasValue())
            {
                throw new RequestDataInvalidException("SparePartNumber", "SparePartName");
            }

            var retVal = _DeviceSparePartRepository.AddSparePart(DeviceSparePartTransfer.BuildDeviceSparePartSource(request.Body));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    default: throw new UndefinedException(retVal);
                }
            }
        }

        public void EditSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response)
        {
            if (request.Body == null
                || !request.Body.SparePartNumber.HasValue()
                || !request.Body.SparePartName.HasValue())
            {
                throw new RequestDataInvalidException("SparePartNumber", "SparePartName");
            }

            var retVal = _DeviceSparePartRepository.EditSparePart(DeviceSparePartTransfer.BuildDeviceSparePartSource(request.Body));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    default: throw new UndefinedException(retVal);
                }
            }
        }

        public void DeleteSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response)
        {
            if (request.Body == null
                || !request.Body.SparePartNumber.HasValue())
            {
                throw new RequestDataInvalidException("SparePartNumber");
            }

            var retVal = _DeviceSparePartRepository.DeleteSparePart(DeviceSparePartTransfer.BuildDeviceSparePartSource(request.Body));
            if (retVal < 0)
            {
                switch (retVal)
                {
                    default: throw new UndefinedException(retVal);
                }
            }
        }

        public void QueryDeviceSpareParts(RestServiceRequest request, RestServiceResponse<DeviceSparePart[]> response)
        {
            response.Paging = request.Paging;

            response.Body = DeviceSparePartTransfer.BuildDeviceSpareParts(_DeviceSparePartRepository.QueryDeviceSpareParts(
                request.Paging,
                request.GetValue("SparePartNumber"),
                request.GetValue("DeviceNumber")));
        }
    }
}
