using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Client;
namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public int DeviceSparePartNumber { get; private set; }

        public RestServiceResponse AddSparePart()
        {
            var response = new ServiceClientBase("operate-checkpoint").Call<RestServiceResponse<DeviceSparePart>>(new RestServiceRequest<DeviceSparePart>()
            {
                Body = new DeviceSparePart()
                {
                    //DeviceInfo = new DeviceInfo() { DeviceNumber = "111111" },
                    //Description = "this is a checkpoint description.",
                    //Flag = DeviceCheckpointFlag.Boolean,
                    //Remark = "pls check it.",
                },
                ActionName = "Add",
            });

            if (!response.HasError && response.Body != null)
            {
                //DeviceCheckpointId = response.Body.Id;
            }

            return response;
        }

        public RestServiceResponse EditSparePart()
        {
            var response = new ServiceClientBase("operate-checkpoint").Call<RestServiceResponse<DeviceSparePart>>(new RestServiceRequest<DeviceSparePart>()
            {
                Body = new DeviceSparePart()
                {
                    //Id = DeviceCheckpointId,
                    //Description = "this is a edited checkpoint description.",
                    //Remark = "pls check it.",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteSparePart()
        {
            var response = new ServiceClientBase("operate-checkpoint").Call<RestServiceResponse<DeviceSparePart>>(new RestServiceRequest<DeviceSparePart>()
            {
                Body = new DeviceSparePart()
                {
                    //Id = DeviceCheckpointId,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryBriefSpareParts()
        {
            var response = new ServiceClientBase("get-checkpoint-list").Call<RestServiceResponse<DeviceSparePart[]>>(new RestServiceRequest()
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
                   // Console.WriteLine("checkpoint: " + deviceCheckpoint.Description);
                }

                //Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
