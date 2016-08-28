namespace Dade.Dms.Dev
{
    public abstract class AbstractDeviceDataSource : IDeviceDataSource
    {
        public string CollectorId { get; protected set; }

        public string DeviceNumber { get; protected set; }

        public abstract void Execute();

        public virtual bool Write(Data.DeviceData[] deviceDataCollection)
        {
            return Repository.DeviceDataRepository.Write(deviceDataCollection);
        }
    }
}
