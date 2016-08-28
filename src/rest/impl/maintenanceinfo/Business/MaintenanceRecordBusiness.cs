using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Repository;
using Petecat.IoC.Attributes;
using Petecat.Extension;

namespace Dade.Dms.Rest.Impl.Business
{
    [AutoResolvable(typeof(IMaintenanceRecordBusiness))]
    public class MaintenanceRecordBusiness : IMaintenanceRecordBusiness
    {
        private IMaintenanceRecordRepository _MaintenanceRecordRepository;

        public MaintenanceRecordBusiness(IMaintenanceRecordRepository maintenanceRecordRepository)
        {
            _MaintenanceRecordRepository = maintenanceRecordRepository;
        }

        public void AddRecord(RestServiceRequest<MaintenanceRecord> request, RestServiceResponse<MaintenanceRecord> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _MaintenanceRecordRepository.AddRecord(request.Body);
            if (retVal < 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
                    case -2: throw new RestException("", string.Format("maintenance plan '{0}' does not exist.", request.Body.MaintenancePlan.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }

            request.Body = new MaintenanceRecord() { Id = retVal };
        }

        public void EditRecord(RestServiceRequest<MaintenanceRecord> request, RestServiceResponse<MaintenanceRecord> response)
        {
            if (request.Body == null
                || request.Body.DeviceInfo == null
                || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            {
                throw new RestException("", "device number cannot be empty.");
            }

            var retVal = _MaintenanceRecordRepository.EditRecord(request.Body);
            if (retVal != 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("maintenance record '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void DeleteRecord(RestServiceRequest<MaintenanceRecord> request, RestServiceResponse<MaintenanceRecord> response)
        {
            var retVal = _MaintenanceRecordRepository.DeleteRecord(request.Body);
            if (retVal != 0)
            {
                switch (retVal)
                {
                    case -1: throw new RestException("", string.Format("maintenance record '{0}' does not exist.", request.Body.Id));
                    default: throw new RestException("", "undefined error.");
                }
            }
        }

        public void QueryRecordsByConditions(RestServiceRequest request, RestServiceResponse<MaintenanceRecord[]> response)
        {
            response.Paging = request.Paging;

            response.Body = _MaintenanceRecordRepository.QueryRecordsByConditions(request.Paging,
                request.GetValue("Id", 0),
                request.GetValue("MaintenancePlanId", 0),
                request.GetValue("DeviceNumber"),
                request.GetValue<string>("Statuses", null).SplitByChar(','),
                request.GetValue<string>("StartTime", null),
                request.GetValue<string>("EndTime", null));
        }
    }
}
