using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Imp.Repository;
using Petecat.Extension;

namespace Dade.Dms.Rest.Imp.Business
{
    public class DeviceRepairRecordBusiness : IDeviceRepairRecordBusiness
    {
        private IDeviceRepairRecordRepository _DeviceRepairRecordRepository;

        public DeviceRepairRecordBusiness(IDeviceRepairRecordRepository deviceRepairRecordRepository)
        {
            _DeviceRepairRecordRepository = deviceRepairRecordRepository;
        }

        public void AddRecord(RestServiceRequest<DeviceRepairRecord> request, RestServiceResponse<DeviceRepairRecord> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null 
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _DeviceRepairRecordRepository.AddRecord(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
                    default: throw new RestException("", "undefined error.");
                }
            }

            response.Body = new DeviceRepairRecord() { Id = retVal };
        }

        public void EditRecord(RestServiceRequest<DeviceRepairRecord> request, RestServiceResponse<DeviceRepairRecord> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _DeviceRepairRecordRepository.EditRecord(request.Body);
            if (retVal != 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("maintenance record '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void DeleteRecord(RestServiceRequest<DeviceRepairRecord> request, RestServiceResponse<DeviceRepairRecord> response)
        {
            var retVal = _DeviceRepairRecordRepository.DeleteRecord(request.Body);
            if (retVal != 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("maintenance record '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void QueryRecordsByConditions(RestServiceRequest request, RestServiceResponse<DeviceRepairRecord[]> response)
        {
            response.Paging = request.Paging;

            response.Body = _DeviceRepairRecordRepository.QueryRecordsByConditions(request.Paging,
                request.GetValue("Id", 0),
                request.GetValue<string>("DeviceNumber", null),
                request.GetValue<string>("Statuses", null).SplitByChar(','),
                request.GetValue<string>("StartTime", null),
                request.GetValue<string>("EndTime", null));
        }
    }
}
