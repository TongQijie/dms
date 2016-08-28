using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Repository;
using Petecat.IoC.Attributes;
using Petecat.Extension;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IInspectionPlanBusiness))]
    public class InspectionPlanBusiness : IInspectionPlanBusiness
    {
        private IInspectionPlanRepository _InspectionPlanRepository;

        public InspectionPlanBusiness(IInspectionPlanRepository inspectionPlanRepository)
        {
            _InspectionPlanRepository = inspectionPlanRepository;
        }

        public void AddPlan(RestServiceRequest<InspectionPlan> request, RestServiceResponse<InspectionPlan> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _InspectionPlanRepository.AddPlan(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }

            response.Body = new InspectionPlan() { Id = retVal };
        }

        public void EditPlan(RestServiceRequest<InspectionPlan> request, RestServiceResponse<InspectionPlan> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _InspectionPlanRepository.EditPlan(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("inspection plan '{0}' does not exist.", request.Body.Id));
                    case -2: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void DeletePlan(RestServiceRequest<InspectionPlan> request, RestServiceResponse<InspectionPlan> response)
        {
            var retVal = _InspectionPlanRepository.DeletePlan(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("inspection plan '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void QueryPlansByConditions(RestServiceRequest request, RestServiceResponse<InspectionPlan[]> response)
        {
            response.Paging = request.Paging;

            response.Body = _InspectionPlanRepository.QueryPlansByConditions(request.Paging,
                request.GetValue("Id", 0), 
                request.GetValue("DeviceNumber"));
        }
    }
}
