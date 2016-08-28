using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Attributes;

namespace Dade.Dms.Rest.ServiceInterface
{
    [ServiceInterface(ServiceName = "inspection-info")]
    public interface IInspectionInfoService
    {
        [ServiceMethod(MethodName = "hi", IsDefaultMethod = true)]
        string Hi();

        [ServiceMethod(MethodName = "operate-inspection-plan")]
        RestServiceResponse<InspectionPlan> OperateInspectionPlan(RestServiceRequest<InspectionPlan> request);

        [ServiceMethod(MethodName = "get-inspection-plan-list")]
        RestServiceResponse<InspectionPlan[]> GetInspectionPlanList(RestServiceRequest<InspectionPlan> request);

        [ServiceMethod(MethodName = "operate-inspection-record")]
        RestServiceResponse<InspectionRecord> OperateInspectionRecord(RestServiceRequest<InspectionRecord> request);

        [ServiceMethod(MethodName = "get-inspection-record-list")]
        RestServiceResponse<InspectionRecord[]> GetInspectionRecordList(RestServiceRequest request);
    }
}
