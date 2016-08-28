using Dade.Dms.Rest.ServiceModel;
using Petecat.Extension;
using Petecat.Service.Client;

namespace Dade.Dms.Website.RestProxy
{
    public static class MaintenanceRecordServiceProxy
    {
        public static RestServiceResponse Add(MaintenanceRecord maintenanceRecord)
        {
            return new ServiceClientBase("operate-maintenance-record").Call<RestServiceResponse<MaintenanceRecord>>(new RestServiceRequest<MaintenanceRecord>()
            {
                Body = maintenanceRecord,
                ActionName = "Add"
            });
        }

        public static RestServiceResponse Edit(MaintenanceRecord maintenanceRecord)
        {
            return new ServiceClientBase("operate-maintenance-record").Call<RestServiceResponse<MaintenanceRecord>>(new RestServiceRequest<MaintenanceRecord>()
            {
                Body = maintenanceRecord,
                ActionName = "Edit",
            });
        }

        public static RestServiceResponse Delete(int id)
        {
            return new ServiceClientBase("operate-maintenance-record").Call<RestServiceResponse<MaintenanceRecord>>(new RestServiceRequest<MaintenanceRecord>()
            {
                Body = new MaintenanceRecord()
                {
                    Id = id,
                },
                ActionName = "Delete",
            });
        }

        public static RestServiceResponse<MaintenanceRecord[]> Query(Paging paging, int id = 0, string deviceNumber = null, int maintenancePlanId = 0, string persons = null, string[] statuses = null, string startTime = null, string endTime = null)
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

            return new ServiceClientBase("get-maintenance-record-list").Call<RestServiceResponse<MaintenanceRecord[]>>(new RestServiceRequest()
            {
                KeyValues = keyValues,
                Paging = paging,
            });
        }
    }
}
