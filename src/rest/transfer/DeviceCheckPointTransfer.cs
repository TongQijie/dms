using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;

using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceCheckPointTransfer
    {
        public static DeviceCheckpoint[] BuildDeviceCheckpoints(DeviceCheckpointSource[] deviceCheckpointSources)
        {
            if (deviceCheckpointSources == null)
            {
                return null;
            }

            var deviceCheckpoints = new DeviceCheckpoint[0];

            foreach (var deviceCheckpointSource in deviceCheckpointSources)
            {
                deviceCheckpoints = deviceCheckpoints.Append(BuildDeviceCheckpoint(deviceCheckpointSource));
            }

            return deviceCheckpoints;
        }

        public static DeviceCheckpoint BuildDeviceCheckpoint(DeviceCheckpointSource deviceCheckpointSource)
        {
            if (deviceCheckpointSource == null)
            {
                return null;
            }

            var deviceCheckpoint = new DeviceCheckpoint();

            deviceCheckpoint.CreationDate = Utility.ConvertDateTime(deviceCheckpointSource.CreationDate);
            deviceCheckpoint.Description = deviceCheckpointSource.Description;
            deviceCheckpoint.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(deviceCheckpointSource.DeviceInfo);
            deviceCheckpoint.Flag = (DeviceCheckpointFlag)typeof(DeviceCheckpointFlag).GetEnumByValue(deviceCheckpointSource.Flag);
            deviceCheckpoint.Id = deviceCheckpointSource.Id;
            deviceCheckpoint.LowerLimit = deviceCheckpointSource.LowerLimit;
            deviceCheckpoint.Remark = deviceCheckpointSource.Remark;
            deviceCheckpoint.UpperLimit = deviceCheckpointSource.UpperLimit;
            deviceCheckpoint.ModifiedDate = Utility.ConvertDateTime(deviceCheckpointSource.ModifiedDate);

            return deviceCheckpoint;
        }

        public static DeviceCheckpointSource[] BuildDeviceCheckpointSources(DeviceCheckpoint[] deviceCheckpoints)
        {
            if (deviceCheckpoints == null)
            {
                return null;
            }

            var deviceCheckpointSources = new DeviceCheckpointSource[0];

            foreach (var deviceCheckpoint in deviceCheckpoints)
            {
                deviceCheckpointSources = deviceCheckpointSources.Append(BuildDeviceCheckpointSource(deviceCheckpoint));
            }

            return deviceCheckpointSources;
        }

        public static DeviceCheckpointSource BuildDeviceCheckpointSource(DeviceCheckpoint deviceCheckpoint)
        {
            if (deviceCheckpoint == null)
            {
                return null;
            }

            var deviceCheckpointSource = new DeviceCheckpointSource();

            deviceCheckpointSource.Description = deviceCheckpoint.Description;
            deviceCheckpointSource.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfoSource(deviceCheckpoint.DeviceInfo);
            deviceCheckpointSource.Flag = typeof(DeviceCheckpointFlag).GetValueByEnum(deviceCheckpoint.Flag);
            deviceCheckpointSource.Id = deviceCheckpoint.Id;
            deviceCheckpointSource.LowerLimit = deviceCheckpoint.LowerLimit;
            deviceCheckpointSource.Remark = deviceCheckpoint.Remark;
            deviceCheckpointSource.UpperLimit = deviceCheckpoint.UpperLimit;

            return deviceCheckpointSource;
        }
    }
}
