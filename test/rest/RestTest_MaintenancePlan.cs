using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Client;

using System;

namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public int MaintenancePlanId { get; private set; }

        public RestServiceResponse AddMaintenancePlan()
        {
            var response = new ServiceClientBase("operate-maintenance-plan").Call<RestServiceResponse<MaintenancePlan>>(new RestServiceRequest<MaintenancePlan>()
            {
                Body = new MaintenancePlan()
                {
                    DeviceInfo = new DeviceInfo() { DeviceNumber = DeviceNumber },
                    ScheduleType = MaintenancePlanScheduleType.Weekly,
                    ScheduleValue = "Sunday",
                    Content = "cccccccc",
                },
                ActionName = "Add"
            });

            if (!response.HasError)
            {
                MaintenancePlanId = response.Body.Id;
            }

            return response;
        }

        public RestServiceResponse EditMaintenancePlan()
        {
            var response = new ServiceClientBase("operate-maintenance-plan").Call<RestServiceResponse<MaintenancePlan>>(new RestServiceRequest<MaintenancePlan>()
            {
                Body = new MaintenancePlan()
                {
                    Id = MaintenancePlanId,
                    DeviceInfo = new DeviceInfo() { DeviceNumber = DeviceNumber },
                    ScheduleType = MaintenancePlanScheduleType.Monthly,
                    ScheduleValue = "20",
                    Content = "aaaa",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteMaintenancePlan()
        {
            var response = new ServiceClientBase("operate-maintenance-plan").Call<RestServiceResponse<MaintenancePlan>>(new RestServiceRequest<MaintenancePlan>()
            {
                Body = new MaintenancePlan()
                {
                    Id = MaintenancePlanId,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryMaintenancePlans()
        {
            var response = new ServiceClientBase("get-maintenance-plan-list").Call<RestServiceResponse<MaintenancePlan[]>>(new RestServiceRequest()
            {
                Paging = new Paging(1, 10),
                KeyValues = new KeyValuePair[]
                {
                    new KeyValuePair("DeviceNumber", "554403"),
                },
            });

            if (!response.HasError)
            {
                foreach (var maintenancePlan in response.Body)
                {
                    Console.WriteLine("maintenance plan id: " + maintenancePlan.Id);
                }

                Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
