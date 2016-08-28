using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl.Repository
{
    [AutoResolvable(typeof(IInspectionRecordRepository))]
    public class InspectionRecordRepository : IInspectionRecordRepository
    {
        public int AddRecord(InspectionRecord inspectionRecord)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecord(InspectionRecord inspectionRecord)
        {
            throw new NotImplementedException();
        }

        public int EditRecord(InspectionRecord inspectionRecord)
        {
            throw new NotImplementedException();
        }

        public InspectionRecord[] QueryRecordsByConditions(Paging paging, int id, int inspectionPlanId, string deviceNumber, string[] statuses, string startTime, string endTime)
        {
            throw new NotImplementedException();
        }
    }
}
