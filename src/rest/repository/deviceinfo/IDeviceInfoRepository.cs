using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Repository
{
    public interface IDeviceInfoRepository
    {
        int AddDevice(DeviceInfoSource deviceInfo, DeviceSparePartSource[] deviceSparePartSources, DeviceCheckpointSource[] deviceCheckpointSources);

        int EditDevice(DeviceInfoSource deviceInfo, DeviceSparePartSource[] deviceSparePartSources, DeviceCheckpointSource[] deviceCheckpointSources);

        int DeleteDevice(DeviceInfoSource deviceInfo);

        DeviceInfoSource[] QueryDeviceInfos(Paging paging, string deviceNumber, string deviceName);
    }
}
