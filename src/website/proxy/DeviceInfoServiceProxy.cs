using Dade.Dms.Rest.ServiceModel;

using Petecat.Extension;
using Petecat.Service.Client;

namespace Dade.Dms.Website.RestProxy
{
    public static class DeviceInfoServiceProxy
    {
        public static RestServiceResponse Add(DeviceInfoBase deviceInfoBase)
        {
            return new ServiceClientBase("operate-device-info").Call<RestServiceResponse<DeviceInfoBase>>(new RestServiceRequest<DeviceInfoBase>()
            {
                Body = deviceInfoBase,
                ActionName = "Add",
            });
        }

        public static RestServiceResponse Edit(DeviceInfoBase deviceInfoBase)
        {
            return new ServiceClientBase("operate-device-info").Call<RestServiceResponse<DeviceInfoBase>>(new RestServiceRequest<DeviceInfoBase>()
            {
                Body = deviceInfoBase,
                ActionName = "Edit",
            });
        }

        public static RestServiceResponse Delete(string deviceNumber)
        {
            return new ServiceClientBase("operate-device-info").Call<RestServiceResponse<DeviceInfoBase>>(new RestServiceRequest<DeviceInfoBase>()
            {
                Body = new DeviceInfoBase() { DeviceNumber = deviceNumber },
                ActionName = "Delete",
            });
        }

        public static RestServiceResponse<DeviceInfoBase[]> Query(Paging paging, string deviceNumber = null, string deviceName = null)
        {
            var keyValues = new KeyValuePair[0];
            if (!string.IsNullOrWhiteSpace(deviceNumber))
            {
                keyValues = keyValues.Append(new KeyValuePair("DeviceNumber", deviceNumber.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(deviceName))
            {
                keyValues = keyValues.Append(new KeyValuePair("DeviceName", deviceName.Trim()));
            }

            return new ServiceClientBase("get-device-info-list").Call<RestServiceResponse<DeviceInfoBase[]>>(new RestServiceRequest()
            {
                KeyValues = keyValues,
                Paging = paging,
                ActionName = "ByConditions",
            });
        }
    }
}
