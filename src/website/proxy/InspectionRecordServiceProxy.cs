using Dade.Dms.Rest.ServiceModel;

using Petecat.Extension;
using Petecat.Service.Client;

namespace Dade.Dms.Website.RestProxy
{
    public static class InspectionRecordServiceProxy
    {
        public static RestServiceResponse Add(InspectionRecord inspectionRecord)
        {
            return new ServiceClientBase("operate-inspection-record").Call<RestServiceResponse<InspectionRecord>>(new RestServiceRequest<InspectionRecord>()
            {
                Body = inspectionRecord,
                ActionName = "Add"
            });
        }

        public static RestServiceResponse Edit(InspectionRecord inspectionRecord)
        {
            return new ServiceClientBase("operate-inspection-record").Call<RestServiceResponse<InspectionRecord>>(new RestServiceRequest<InspectionRecord>()
            {
                Body = inspectionRecord,
                ActionName = "Edit",
            });
        }

        public static RestServiceResponse Delete(int inspectionRecordId)
        {
            return new ServiceClientBase("operate-inspection-record").Call<RestServiceResponse<InspectionRecord>>(new RestServiceRequest<InspectionRecord>()
            {
                Body = new InspectionRecord()
                {
                    Id = inspectionRecordId,
                },
                ActionName = "Delete",
            });
        }

        public static RestServiceResponse Query(Paging paging, int id = 0, string deviceNumber = null, int maintenancePlanId = 0, string persons = null, string[] statuses = null, string startTime = null, string endTime = null)
        {
            var keyValues = new KeyValuePair[0];
            if (id > 0)
            {
                keyValues = keyValues.Append(new KeyValuePair("Id", id.ToString()));
            }
            if (deviceNumber.HasValue())
            {
                keyValues = keyValues.Append(new KeyValuePair("DeviceNumber", deviceNumber.Trim()));
            }
            if (maintenancePlanId > 0)
            {
                keyValues = keyValues.Append(new KeyValuePair("MaintenancePlanId", id.ToString()));
            }
            if (persons.HasValue())
            {
                keyValues = keyValues.Append(new KeyValuePair("Persons", persons.ToString()));
            }
            if (statuses != null && statuses.Length > 0)
            {
                keyValues = keyValues.Append(new KeyValuePair("Statuses", string.Join(",", statuses)));
            }
            if (startTime.HasValue())
            {
                keyValues = keyValues.Append(new KeyValuePair("StartTime", startTime));
            }
            if (endTime.HasValue())
            {
                keyValues = keyValues.Append(new KeyValuePair("EndTime", endTime));
            }

            return new ServiceClientBase("get-inspection-record-list").Call<RestServiceResponse<InspectionRecord[]>>(new RestServiceRequest()
            {
                KeyValues = keyValues,
                Paging = paging,
            });
        }
    }
}
