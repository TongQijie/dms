using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Client;
using System;

namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public int InspectionPlanId { get; private set; }

        public RestServiceResponse AddInpsectionPlan()
        {
            var response = new ServiceClientBase("operate-inspection-plan").Call<RestServiceResponse<InspectionPlan>>(new RestServiceRequest<InspectionPlan>()
            {
                Body = new InspectionPlan()
                {
                    DeviceInfo = new DeviceInfo() { DeviceNumber = DeviceNumber },
                    ScheduleType = InspectionPlanScheduleType.Weekly,
                    ScheduleValue = "Sunday",
                    Content = "cccccccc",
                },
                ActionName = "Add"
            });

            if (!response.HasError)
            {
                InspectionPlanId = response.Body.Id;
            }

            return response;
        }

        public RestServiceResponse EditInpsectionPlan()
        {
            var response = new ServiceClientBase("operate-inspection-plan").Call<RestServiceResponse<InspectionPlan>>(new RestServiceRequest<InspectionPlan>()
            {
                Body = new InspectionPlan()
                {
                    Id = InspectionPlanId,
                    DeviceInfo = new DeviceInfo() { DeviceNumber = DeviceNumber },
                    ScheduleType = InspectionPlanScheduleType.Yearly,
                    ScheduleValue = "03-10",
                    Content = "aaaa",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteInspectionPlan()
        {
            var response = new ServiceClientBase("operate-inspection-plan").Call<RestServiceResponse<InspectionPlan>>(new RestServiceRequest<InspectionPlan>()
            {
                Body = new InspectionPlan()
                {
                    Id = InspectionPlanId,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryInspectionPlans()
        {
            var response = new ServiceClientBase("get-inspection-plan-list").Call<RestServiceResponse<InspectionPlan[]>>(new RestServiceRequest()
            {
                Paging = new Paging(1, 10),
                KeyValues = new KeyValuePair[]
                {
                    new KeyValuePair("DeviceNumber", "554403"),
                },
            });

            if (!response.HasError)
            {
                foreach (var inspectionPlan in response.Body)
                {
                    Console.WriteLine("inspection plan id: " + inspectionPlan.Id);
                }

                Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
