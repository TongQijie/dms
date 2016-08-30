using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Client;
using System;
namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public int DeviceCheckpointId { get; private set; }

        public RestServiceResponse AddCheckpoint()
        {
            var response = new ServiceClientBase("operate-checkpoint").Call<RestServiceResponse<DeviceCheckpoint>>(new RestServiceRequest<DeviceCheckpoint>()
            {
                Body = new DeviceCheckpoint()
                {
                    DeviceInfo = new DeviceInfo() { DeviceNumber = "111111" },
                    Description = "this is a checkpoint description.",
                    Flag = DeviceCheckpointFlag.Boolean,
                    Remark = "pls check it.",
                },
                ActionName = "Add",
            });

            if (!response.HasError && response.Body != null)
            {
                DeviceCheckpointId = response.Body.Id;
            }

            return response;
        }

        public RestServiceResponse EditCheckpoint()
        {
            var response = new ServiceClientBase("operate-checkpoint").Call<RestServiceResponse<DeviceCheckpoint>>(new RestServiceRequest<DeviceCheckpoint>()
            {
                Body = new DeviceCheckpoint()
                {
                    Id = DeviceCheckpointId,
                    Description = "this is a edited checkpoint description.",
                    Remark = "pls check it.",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteCheckpoint()
        {
            var response = new ServiceClientBase("operate-checkpoint").Call<RestServiceResponse<DeviceCheckpoint>>(new RestServiceRequest<DeviceCheckpoint>()
            {
                Body = new DeviceCheckpoint()
                {
                    Id = DeviceCheckpointId,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryBriefCheckpoints()
        {
            var response = new ServiceClientBase("get-checkpoint-list").Call<RestServiceResponse<DeviceCheckpoint[]>>(new RestServiceRequest()
            {
                KeyValues = new KeyValuePair[]
                {
                    //new KeyValuePair("DeviceNumber", "102815"),
                },
                Paging = new Paging() { PageNumber = 1, PageSize = 10 },
                ActionName = "Brief",
            });

            if (!response.HasError)
            {
                foreach (var deviceCheckpoint in response.Body)
                {
                    Console.WriteLine("checkpoint: " + deviceCheckpoint.Description);
                }

                Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
