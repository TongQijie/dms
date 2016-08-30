using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel.Services;
namespace Dade.Dms.Rest.Repository
{
    public interface IDeviceCheckpointRepository
    {
        int AddCheckpoint(DeviceCheckpointSource deviceCheckpointSource);

        int EditCheckpoint(DeviceCheckpointSource deviceCheckpointSource);

        int DeleteCheckpoint(DeviceCheckpointSource deviceCheckpointSource);

        DeviceCheckpointSource[] QueryDeviceCheckpoints(Paging paging, int id, string deviceNumber);

        DeviceCheckpointSource[] QueryDeviceCheckpoints(string[] deviceNumbers);
    }
}
