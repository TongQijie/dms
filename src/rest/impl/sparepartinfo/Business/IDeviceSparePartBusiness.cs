using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Business
{
    public interface IDeviceSparePartBusiness
    {
        void AddSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response);

        void EditSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response);

        void DeleteSparePart(RestServiceRequest<DeviceSparePart> request, RestServiceResponse<DeviceSparePart> response);

        void QueryDeviceSpareParts(RestServiceRequest request, RestServiceResponse<DeviceSparePart[]> response);
    }
}
