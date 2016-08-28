using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Service.Client;
using System;

namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public int InspectionRecordId { get; private set; }

        public RestServiceResponse AddInspectionRecord()
        {
            var response = new ServiceClientBase("operate-inspection-record").Call<RestServiceResponse<InspectionRecord>>(new RestServiceRequest<InspectionRecord>()
            {
                Body = new InspectionRecord()
                {
                    DeviceInfo = new DeviceInfo() { DeviceNumber = DeviceNumber },
                    Content = "inspection content",
                    Status = InspectionRecordStatus.Pending,
                    InspectionPlan = new InspectionPlan() { Id = InspectionPlanId },
                },
                ActionName = "Add"
            });

            if (!response.HasError)
            {
                InspectionRecordId = response.Body.Id;
            }

            return response;
        }

        public RestServiceResponse EditInspectionRecord()
        {
            var response = new ServiceClientBase("operate-inspection-record").Call<RestServiceResponse<InspectionRecord>>(new RestServiceRequest<InspectionRecord>()
            {
                Body = new InspectionRecord()
                {
                    Id = InspectionRecordId,
                    Status = InspectionRecordStatus.Done,
                    Persons = "bufferfly",
                    ScheduleTime = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss"),
                    MaintainBeginTime = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss"),
                    MaintainEndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Remark = "good job.",
                },
                ActionName = "Edit",
            });

            return response;
        }

        public RestServiceResponse DeleteInspectionRecord()
        {
            var response = new ServiceClientBase("operate-inspection-record").Call<RestServiceResponse<InspectionRecord>>(new RestServiceRequest<InspectionRecord>()
            {
                Body = new InspectionRecord()
                {
                    Id = InspectionRecordId,
                },
                ActionName = "Delete",
            });

            return response;
        }

        public RestServiceResponse QueryInspectionRecords()
        {
            var response = new ServiceClientBase("get-inspection-record-list").Call<RestServiceResponse<InspectionRecord[]>>(new RestServiceRequest()
            {
                Paging = new Paging(1, 10),
                KeyValues = new KeyValuePair[]
                {
                    new KeyValuePair("Statuses", "P,O,D"),
                },
            });

            if (!response.HasError)
            {
                foreach (var inspectionRecord in response.Body)
                {
                    Console.WriteLine("inspection record id: " + inspectionRecord.Id);
                }

                Console.WriteLine("current: " + response.Paging.PageNumber + ";" + "total: " + response.Paging.TotalPages);
            }

            return response;
        }
    }
}
