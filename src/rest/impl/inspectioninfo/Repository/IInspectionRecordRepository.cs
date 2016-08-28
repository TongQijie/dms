using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Repository
{
    public interface IInspectionRecordRepository
    {
        int AddRecord(InspectionRecord inspectionRecord);

        int EditRecord(InspectionRecord inspectionRecord);

        int DeleteRecord(InspectionRecord inspectionRecord);

        InspectionRecord[] QueryRecordsByConditions(Paging paging, int id, int inspectionPlanId, string deviceNumber, string[] statuses, string startTime, string endTime);
    }
}
