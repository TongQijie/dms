using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IDeviceSparePartBusiness))]
    public class DeviceSparePartBusiness : IDeviceSparePartBusiness
    {
        public void AddSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response)
        {
            throw new System.NotImplementedException();
        }

        public void EditSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response)
        {
            throw new System.NotImplementedException();
        }

        public void QueryDeviceSpareParts(RestServiceRequest request, RestServiceResponse<DeviceSparePart[]> response)
        {
            throw new System.NotImplementedException();
        }
    }
}
