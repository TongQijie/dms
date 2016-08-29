using System;

using Dade.Dms.Rest.Impl;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceInterface;

using Petecat.Service.Attributes;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.ServiceImplement
{
    [AutoService(typeof(IInspectionInfoService))]
    public class InspectionInfoService : AnyServiceBase, IInspectionInfoService
    {
        private InspectionPlanImpl _InspectionPlanImpl;

        private InspectionRecordImpl _InspectionRecordImpl;

        public InspectionInfoService(InspectionPlanImpl inspectionPlanImpl, InspectionRecordImpl inspectionRecordImpl)
        {
            _InspectionPlanImpl = inspectionPlanImpl;
            _InspectionRecordImpl = inspectionRecordImpl;
        }

        public string Hi()
        {
            return "Welcome to access inspection info service.";
        }

        public RestServiceResponse<InspectionPlan> OperateInspectionPlan(RestServiceRequest<InspectionPlan> request)
        {
            return Sandbox(request, _InspectionPlanImpl.OperateInspectionPlan);
        }

        public RestServiceResponse<InspectionPlan[]> GetInspectionPlanList(RestServiceRequest<InspectionPlan> request)
        {
            return Sandbox(request, _InspectionPlanImpl.GetInspectionPlanList);
        }

        public RestServiceResponse<InspectionRecord> OperateInspectionRecord(RestServiceRequest<InspectionRecord> request)
        {
            return Sandbox(request, _InspectionRecordImpl.OperateInspectionRecord);
        }

        public RestServiceResponse<InspectionRecord[]> GetInspectionRecordList(RestServiceRequest request)
        {
            return Sandbox(request, _InspectionRecordImpl.GetInspectionRecordList);
        }
    }
}
