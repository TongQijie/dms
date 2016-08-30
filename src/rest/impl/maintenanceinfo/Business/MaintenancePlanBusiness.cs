using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Dade.Dms.Rest.Impl.Repository;
using Petecat.IoC.Attributes;
using Petecat.Extension;
using Dade.Dms.Rest.ServiceModel.Errors;
using Dade.Dms.Rest.ModelTransfer;
using Dade.Dms.Repo.DataModel;

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
            //if (request.Body.DeviceInfo == null
            //    || !request.Body.DeviceInfo.DeviceNumber.HasValue()
            //    || !request.Body.PeriodFrom.IsDateTime()
            //    || !request.Body.PeriodTo.IsDateTime())
            //{
            //    throw new RequestDataInvalidException("DeviceNumber", "PeriodFrom", "PeriodTo");
            //}

            //var deviceNumber = request.Body.DeviceInfo.DeviceNumber;
            //var periodFrom = DateTime.Parse(request.Body.PeriodFrom);
            //var periodTo = DateTime.Parse(request.Body.PeriodTo);

            //if (periodFrom > periodTo)
            //{
            //    throw new RequestDataInvalidException("PeriodFrom", "PeriodTo");
            //}

            //var scheduleTimes = ScheduleHandler.GenerateDateTime((ScheduleType)Enum.Parse(typeof(ScheduleType), request.Body.ScheduleType.ToString()),
            //    request.Body.ScheduleValue, periodFrom, periodTo);
            //if (scheduleTimes == null)
            //{
            //    throw new RequestDataInvalidException("ScheduleType", "ScheduleValue");
            //}

            //var maintenanceRecordSources = new MaintenanceRecordSource[0];
            //foreach (var scheduleTime in scheduleTimes)
            //{
            //    maintenanceRecordSources = maintenanceRecordSources.Append(new MaintenanceRecordSource()
            //    {
            //        Content = request.Body.Content,
            //        DeviceInfo = new DeviceInfoSource() { DeviceNumber = request.Body.DeviceInfo.DeviceNumber },
            //        ScheduleTime = scheduleTime.ToString("yyyy-MM-dd HH:mm:ss"),
            //    });
            //}

            //var retVal = _MaintenancePlanRepository.AddPlan(MaintenancePlanTransfer.BuildMaintenancePlanSource(request.Body), maintenanceRecordSources);
            //if (retVal < 0)
            //{
            //    switch (retVal)
            //    {
            //        case -1: throw new DeviceNotFoundException(request.Body.DeviceInfo.DeviceNumber);
            //        default: throw new UndefinedException(retVal);
            //    }
            //}

            //response.Body = new MaintenancePlan() { Id = retVal };
        }

        public void EditPlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response)
        {
            //if (request.Body.DeviceInfo == null
            //    || !request.Body.DeviceInfo.DeviceNumber.HasValue())
            //{
            //    throw new RestException("", "device number cannot be empty.");
            //}

            //var retVal = _MaintenancePlanRepository.EditPlan(request.Body);
            //if (retVal < 0)
            //{
            //    switch (retVal)
            //    {
            //        case -1: throw new RestException("", string.Format("maintenance plan '{0}' does not exist.", request.Body.Id));
            //        case -2: throw new RestException("", string.Format("device number '{0}' does not exist.", request.Body.DeviceInfo.DeviceNumber));
            //        default: throw new RestException("", "undefined error.");
            //    }
            //}
        }

        public void DeletePlan(RestServiceRequest<MaintenancePlan> request, RestServiceResponse<MaintenancePlan> response)
        {
            //var retVal = _MaintenancePlanRepository.DeletePlan(request.Body);
            //if (retVal < 0)
            //{
            //    switch (retVal)
            //    {
            //        case -1: throw new RestException("", string.Format("maintenance plan '{0}' does not exist.", request.Body.Id));
            //        default: throw new RestException("", "undefined error.");
            //    }
            //}
        }

        public void QueryPlansByConditions(RestServiceRequest request, RestServiceResponse<MaintenancePlan[]> response)
        {
            //response.Paging = request.Paging;

            //response.Body = _MaintenancePlanRepository.QueryPlansByConditions(request.Paging,
            //    request.GetValue("Id", 0),
            //    request.GetValue("DeviceNumber"));
        }
    }
}
