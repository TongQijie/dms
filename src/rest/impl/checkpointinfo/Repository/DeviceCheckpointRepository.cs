using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
namespace Dade.Dms.Rest.Impl.Repository
{
    [AutoResolvable(typeof(IDeviceCheckpointRepository))]
    public class DeviceCheckpointRepository : IDeviceCheckpointRepository
    {
        public int AddCheckpoint(DeviceCheckpointSource deviceCheckpointSource)
        {
            throw new System.NotImplementedException();
        }

        public int EditCheckpoint(DeviceCheckpointSource deviceCheckpointSource)
        {
            throw new System.NotImplementedException();
        }

        public int DeleteCheckpoint(DeviceCheckpointSource deviceCheckpointSource)
        {
            throw new System.NotImplementedException();
        }

        public DeviceCheckpointSource[] QueryDeviceCheckpoints(Paging paging, string deviceNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
