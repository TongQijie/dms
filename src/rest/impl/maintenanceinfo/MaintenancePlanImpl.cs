
using Dade.Dms.Rest.ServiceModel;
using Petecat.IoC.Attributes;
using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Business;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(MaintenancePlanImpl))]
    public class MaintenancePlanImpl
    {
        private IMaintenancePlanBusiness _MaintenancePlanBusiness;

        public MaintenancePlanImpl(IMaintenancePlanBusiness maintenancePlanBusiness)
        {
            _MaintenancePlanBusiness = maintenancePlanBusiness;
        }

        public RestServiceResponse<MaintenancePlan> OperateMaintenancePlan(RestServiceRequest<MaintenancePlan> request)
        {
            var response = new RestServiceResponse<MaintenancePlan>();

            switch (request.ActionName)
            {
                case "Add": _MaintenancePlanBusiness.AddPlan(request, response); break;
                case "Edit": _MaintenancePlanBusiness.EditPlan(request, response); break;
                case "Delete": _MaintenancePlanBusiness.DeletePlan(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }

        public RestServiceResponse<MaintenancePlan[]> GetMaintenancePlanList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<MaintenancePlan[]>();

            switch (request.ActionName)
            {
                case "ByConditions": _MaintenancePlanBusiness.QueryPlansByConditions(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }
    }
}
