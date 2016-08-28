using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Client;
using System;

namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public int RepairRecordId { get; private set; }

        public RestServiceResponse AddRepairRecord()
        {
            var response = new ServiceClientBase("operate-repair-record").Call<RestServiceResponse<DeviceRepairRecord>>(new RestServiceRequest<DeviceRepairRecord>()
            {
                Body = new DeviceRepairRecord()
                {
                    DeviceInfo = new DeviceInfo() { DeviceNumber = DeviceNumber },
                    FaultTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Description = "something is wrong.",
                    Status = DeviceRepairRecordStatus.Ongoing,
                },
                ActionName = "Add"
            });

            if (!response.HasError)
            {
                RepairRecordId = response.Body.Id;
            }

            return response;
        }

        public RestServiceResponse EditRepairRecord()
        {
            var response = new ServiceClientBase("operate-repair-record").Call<RestServiceResponse<DeviceRepairRecord>>(new RestServiceRequest<DeviceRepairRecord>()
            {
                Body = new DeviceRepairRecord()
                {
                    Id = RepairRecordId,
                    FaultTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Description = "something is wrong.",
                    Status = DeviceRepairRecordStatus.Done,
                    RepairBeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Content = "fix some parts.",
                    Persons = "bufferfly",
                    Remark = "good job.",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteRepairRecord()
        {
            var response = new ServiceClientBase("operate-repair-record").Call<RestServiceResponse<DeviceRepairRecord>>(new RestServiceRequest<DeviceRepairRecord>()
            {
                Body = new DeviceRepairRecord()
                {
                    Id = RepairRecordId,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryRepairRecords()
        {
            var response = new ServiceClientBase("get-repair-record-list").Call<RestServiceResponse<DeviceRepairRecord[]>>(new RestServiceRequest()
            {
                Paging = new Paging(1, 10),
                KeyValues = new KeyValuePair[]
                {
                    new KeyValuePair("Statuses", "P,O,D"),
                },
            });

            if (!response.HasError)
            {
                foreach (var repairRecord in response.Body)
                {
                    Console.WriteLine("repair record id: " + repairRecord.Id);
                }

                Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
