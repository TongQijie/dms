using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Client;
using System;

namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public int MaintenanceRecordId { get; private set; }

        public RestServiceResponse AddMaintenanceRecord()
        {
            var response = new ServiceClientBase("operate-maintenance-record").Call<RestServiceResponse<MaintenanceRecord>>(new RestServiceRequest<MaintenanceRecord>()
            {
                Body = new MaintenanceRecord()
                {
                    DeviceInfo = new DeviceInfo() { DeviceNumber = DeviceNumber },
                    Content = "maintenance content",
                    Status = MaintenanceRecordStatus.Pending,
                    MaintenancePlan = new MaintenancePlan() { Id = MaintenancePlanId },
                },
                ActionName = "Add"
            });

            if (!response.HasError)
            {
                MaintenanceRecordId = response.Body.Id;
            }

            return response;
        }

        public RestServiceResponse EditMaintenanceRecord()
        {
            var response = new ServiceClientBase("operate-maintenance-record").Call<RestServiceResponse<MaintenanceRecord>>(new RestServiceRequest<MaintenanceRecord>()
            {
                Body = new MaintenanceRecord()
                {
                    Id = MaintenanceRecordId,
                    Status = MaintenanceRecordStatus.Done,
                    Persons = "bufferfly",
                    ScheduleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Remark = "good job.",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteMaintenanceRecord()
        {
            var response = new ServiceClientBase("operate-maintenance-record").Call<RestServiceResponse<MaintenanceRecord>>(new RestServiceRequest<MaintenanceRecord>()
            {
                Body = new MaintenanceRecord()
                {
                    Id = MaintenanceRecordId,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryMaintenanceRecords()
        {
            var response = new ServiceClientBase("get-maintenance-record-list").Call<RestServiceResponse<MaintenanceRecord[]>>(new RestServiceRequest()
            {
                Paging = new Paging(1, 10),
                KeyValues = new KeyValuePair[]
                {
                    new KeyValuePair("Statuses", "P,O,D"),
                },
            });

            if (!response.HasError)
            {
                foreach (var maintenanceRecord in response.Body)
                {
                    Console.WriteLine("maintenance record id: " + maintenanceRecord.Id);
                }

                Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
