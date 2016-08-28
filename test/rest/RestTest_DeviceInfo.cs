using Dade.Dms.Rest.ServiceModel;

using System;

using Petecat.Service.Client;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public RestTest()
        {
            DeviceNumber = new Random(Environment.TickCount).Next(100000, 999999).ToString();
        }

        public RestTest(string deviceNumber)
        {
            DeviceNumber = deviceNumber;
        }

        public string DeviceNumber { get; private set; }

        public RestServiceResponse AddDevice()
        {
            var response = new ServiceClientBase("operate-device-info").Call<RestServiceResponse<DeviceInfo>>(new RestServiceRequest<DeviceInfo>()
            {
                Body = new DeviceInfo()
                {
                    DeviceNumber = DeviceNumber,
                    DeviceName = "hey",
                    DateOfManufacture = "2016-08-06",
                    Category = "cccccc",
                },
                ActionName = "Add",
            });

            if (!response.HasError)
            {
                Console.WriteLine("Device Number: " + response.Body.DeviceNumber);
            }

            return response;
        }

        public RestServiceResponse EditDevice()
        {
            var response = new ServiceClientBase("operate-device-info").Call<RestServiceResponse<DeviceInfo>>(new RestServiceRequest<DeviceInfo>()
            {
                Body = new DeviceInfo()
                {
                    DeviceNumber = DeviceNumber,
                    DeviceName = "edited device name",
                    DateOfManufacture = "2016-07-06",
                    Category = "last edited by me",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteDevice()
        {
            var response = new ServiceClientBase("operate-device-info").Call<RestServiceResponse<DeviceInfo>>(new RestServiceRequest<DeviceInfo>()
            {
                Body = new DeviceInfo()
                {
                    DeviceNumber = DeviceNumber,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryDevicesByConditions()
        {
            var response = new ServiceClientBase("get-device-info-list").Call<RestServiceResponse<DeviceInfo[]>>(new RestServiceRequest()
            {
                //KeyValues = new KeyValuePair[]
                //{
                //    new KeyValuePair("DeviceNumber", "102815"),
                //},
                Paging = new Paging() { PageNumber = 1, PageSize = 10 },
                ActionName = "ByConditions",
            });

            if (!response.HasError)
            {
                foreach (var deviceInfo in response.Body)
                {
                    Console.WriteLine("Device Number: " + deviceInfo.DeviceNumber);
                }

                Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
