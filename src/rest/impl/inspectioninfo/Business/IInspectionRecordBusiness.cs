using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Business
{
    public interface IInspectionRecordBusiness
    {
        void AddRecord(RestServiceRequest<InspectionRecord> request, RestServiceResponse<InspectionRecord> response);

        void EditRecord(RestServiceRequest<InspectionRecord> request, RestServiceResponse<InspectionRecord> response);

        void DeleteRecord(RestServiceRequest<InspectionRecord> request, RestServiceResponse<InspectionRecord> response);

        void QueryRecordsByConditions(RestServiceRequest request, RestServiceResponse<InspectionRecord[]> response);
    }
}
