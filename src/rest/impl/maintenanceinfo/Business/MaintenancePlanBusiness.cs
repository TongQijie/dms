using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Repository;
using Petecat.IoC.Attributes;
using Petecat.Extension;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IMaintenancePlanBusiness))]
    public class MaintenancePlanBusiness : IMaintenancePlanBusiness
    {
        private IMaintenancePlanRepository _MaintenancePlanRepository;

        public MaintenancePlanBusiness(IMaintenancePlanRepository maintenancePlanRepository)
        {
            _MaintenancePlanRepository = maintenancePlanRepository;
        }

        public void AddPlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response)
        {
            if (request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _MaintenancePlanRepository.AddPlan(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }

            response.Body = new MaintenancePlan() { Id = retVal };
        }

        public void EditPlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response)
        {
            if (request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _MaintenancePlanRepository.EditPlan(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("maintenance plan '{0}' does not exist.", request.Body.Id));
                    case -2: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void DeletePlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response)
        {
            var retVal = _MaintenancePlanRepository.DeletePlan(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("maintenance plan '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void QueryPlansByConditions(RestServiceRequest request, RestServiceResponse<MaintenancePlan[]> response)
        {
            response.Paging = request.Paging;

            response.Body = _MaintenancePlanRepository.QueryPlansByConditions(request.Paging,
                request.GetValue("Id", 0),
                request.GetValue("DeviceNumber"));
        }
    }
}
