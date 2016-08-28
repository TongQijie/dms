using Dade.Dms.Rest.ServiceModel;
using Petecat.Extension;
using Petecat.Service.Client;

namespace Dade.Dms.Website.RestProxy
{
    public static class RepairRecordServiceProxy
    {
        public static RestServiceResponse Add(RepairRecord repairRecord)
        {
            return new ServiceClientBase("operate-repair-record").Call<RestServiceResponse<RepairRecord>>(new RestServiceRequest<RepairRecord>()
            {
                Body = repairRecord,
                ActionName = "Add"
            });
        }

        public static RestServiceResponse Edit(RepairRecord repairRecord)
        {
            return new ServiceClientBase("operate-repair-record").Call<RestServiceResponse<RepairRecord>>(new RestServiceRequest<RepairRecord>()
            {
                Body = repairRecord,
                ActionName = "Edit",
            });
        }

        public static RestServiceResponse Delete(int recordId)
        {
            return new ServiceClientBase("operate-repair-record").Call<RestServiceResponse<RepairRecord>>(new RestServiceRequest<RepairRecord>()
            {
                Body = new RepairRecord()
                {
                    Id = recordId,
                },
                ActionName = "Delete",
            });
        }

        public static RestServiceResponse<RepairRecord[]> Query(Paging paging, int id = 0, string deviceNumber = null, string persons = null, string[] statuses = null, string startTime = null, string endTime = null)
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

            return new ServiceClientBase("get-repair-record-list").Call<RestServiceResponse<RepairRecord[]>>(new RestServiceRequest()
            {
                Paging = paging,
                KeyValues = keyValues,
            });
        }
    }
}
