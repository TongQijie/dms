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
            return _InspectionPlanImpl.OperateInspectionPlan(request);
        }

        public RestServiceResponse<InspectionPlan[]> GetInspectionPlanList(RestServiceRequest<InspectionPlan> request)
        {
            return _InspectionPlanImpl.GetInspectionPlanList(request);
        }

        public RestServiceResponse<InspectionRecord> OperateInspectionRecord(RestServiceRequest<InspectionRecord> request)
        {
            return _InspectionRecordImpl.OperateInspectionRecord(request);
        }

        public RestServiceResponse<InspectionRecord[]> GetInspectionRecordList(RestServiceRequest request)
        {
            return _InspectionRecordImpl.GetInspectionRecordList(request);
        }
    }
}
