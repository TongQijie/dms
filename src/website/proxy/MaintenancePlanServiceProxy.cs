using Dade.Dms.Rest.ServiceModel;
using Petecat.Extension;
using Petecat.Service.Client;

namespace Dade.Dms.Website.RestProxy
{
    public static class MaintenancePlanServiceProxy
    {
        public static RestServiceResponse Add(MaintenancePlan maintenancePlan)
        {
            return new ServiceClientBase("operate-maintenance-plan").Call<RestServiceResponse<MaintenancePlan>>(new RestServiceRequest<MaintenancePlan>()
            {
                Body = maintenancePlan,
                ActionName = "Add",
            });
        }

        public static RestServiceResponse Edit(MaintenancePlan maintenancePlan)
        {
            return new ServiceClientBase("operate-maintenance-plan").Call<RestServiceResponse<MaintenancePlan>>(new RestServiceRequest<MaintenancePlan>()
            {
                Body = maintenancePlan,
                ActionName = "Edit",
            });
        }

        public static RestServiceResponse Delete(int id)
        {
            return new ServiceClientBase("operate-maintenance-plan").Call<RestServiceResponse<MaintenancePlan>>(new RestServiceRequest<MaintenancePlan>()
            {
                Body = new MaintenancePlan()
                {
                    Id = id,
                },
                ActionName = "Delete",
            });
        }

        public static RestServiceResponse<MaintenancePlan[]> Query(Paging paging, int id = 0, string deviceNumber = null, string deviceName = null)
        {
            var keyValues = new KeyValuePair[0];
            if (id > 0)
            {
                keyValues = keyValues.Append(new KeyValuePair("Id", id.ToString()));
            }
            if (!string.IsNullOrWhiteSpace(deviceNumber))
            {
                keyValues = keyValues.Append(new KeyValuePair("DeviceNumber", deviceNumber.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(deviceName))
            {
                keyValues = keyValues.Append(new KeyValuePair("DeviceName", deviceName.Trim()));
            }

            return new ServiceClientBase("get-maintenance-plan-list").Call<RestServiceResponse<MaintenancePlan[]>>(new RestServiceRequest()
            {
                KeyValues = keyValues,
                Paging = paging,
            });
        }
    }
}
