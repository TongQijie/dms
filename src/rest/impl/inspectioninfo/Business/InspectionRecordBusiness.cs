using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Repository;
using Petecat.IoC.Attributes;
using Petecat.Extension;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IInspectionRecordBusiness))]
    public class InspectionRecordBusiness : IInspectionRecordBusiness
    {
        private IInspectionRecordRepository _InspectionRecordRepository;

        public InspectionRecordBusiness(IInspectionRecordRepository inspectionRecordRepository)
        {
            _InspectionRecordRepository = inspectionRecordRepository;
        }

        public void AddRecord(RestServiceRequest<InspectionRecord> request, RestServiceResponse<InspectionRecord> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null 
                || !request.Body.DeviceInfo.DeviceName.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _InspectionRecordRepository.AddRecord(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
                    case -2: throw new RestException("", string.Format("inspection plan '{0}' does not exist.", request.Body.InspectionPlan.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }

            response.Body = new InspectionRecord() { Id = retVal };
        }

        public void EditRecord(RestServiceRequest<InspectionRecord> request, RestServiceResponse<InspectionRecord> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceName.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _InspectionRecordRepository.EditRecord(request.Body);
            if (retVal != 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("inspection record '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void DeleteRecord(RestServiceRequest<InspectionRecord> request, RestServiceResponse<InspectionRecord> response)
        {
            var retVal = _InspectionRecordRepository.DeleteRecord(request.Body);
            if (retVal != 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("inspection record '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void QueryRecordsByConditions(RestServiceRequest request, RestServiceResponse<InspectionRecord[]> response)
        {
            response.Paging = request.Paging;

            response.Body = _InspectionRecordRepository.QueryRecordsByConditions(request.Paging,
                request.GetValue("Id", 0),
                request.GetValue("InspectionPlanId", 0),
                request.GetValue<string>("DeviceNumber", null),
                request.GetValue<string>("Statuses", null).SplitByChar(','),
                request.GetValue<string>("StartTime", null),
                request.GetValue<string>("EndTime", null));
        }
    }
}
