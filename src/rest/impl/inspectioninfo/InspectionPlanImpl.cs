using Dade.Dms.Rest.Impl.Business;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Data.Formatters;
using Petecat.IoC.Attributes;
using Petecat.Logging;

using System;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(InspectionPlanImpl))]
    public class InspectionPlanImpl
    {
        private IInspectionPlanBusiness _InspectionPlanBusiness;

        public InspectionPlanImpl(IInspectionPlanBusiness inspectionPlanBusiness)
        {
            _InspectionPlanBusiness = inspectionPlanBusiness;
        }

        public RestServiceResponse<InspectionPlan> OperateInspectionPlan(RestServiceRequest<InspectionPlan> request)
        {
            var response = new RestServiceResponse<InspectionPlan>();

            switch (request.ActionName)
            {
                case "Add": _InspectionPlanBusiness.AddPlan(request, response); break;
                case "Edit": _InspectionPlanBusiness.EditPlan(request, response); break;
                case "Delete": _InspectionPlanBusiness.DeletePlan(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }

        public RestServiceResponse<InspectionPlan[]> GetInspectionPlanList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<InspectionPlan[]>();

            switch (request.ActionName)
            {
                case "ByConditions": _InspectionPlanBusiness.QueryPlansByConditions(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }
    }
}
