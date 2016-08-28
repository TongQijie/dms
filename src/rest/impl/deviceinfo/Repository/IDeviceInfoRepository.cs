using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Impl.Repository
{
    public interface IDeviceInfoRepository
    {
        int AddDevice(DeviceInfo deviceInfo);

        int EditDevice(DeviceInfo deviceInfo);

        int DeleteDevice(DeviceInfo deviceInfo);

        DeviceInfo[] QueryDevicesByConditions(Paging paging, string deviceNumber, string deviceName);
    }
}
