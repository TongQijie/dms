namespace Dade.Dms.Dev
{
    public interface IDeviceDataSource
    {
        string DeviceNumber { get; }

        string CollectorId { get; }

        void Execute();
    }
}
