using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;

using Petecat.Extension;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceCheckPointTransfer
    {
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
            deviceCheckpoint.Flag = (DeviceCheckpointFlag)typeof(DeviceCheckpoint).GetEnumByValue(deviceCheckpointSource.Flag);
            deviceCheckpoint.Id = deviceCheckpointSource.Id;
            deviceCheckpoint.LowerLimit = deviceCheckpointSource.LowerLimit;
            deviceCheckpoint.Remark = deviceCheckpointSource.Remark;
            deviceCheckpoint.UpperLimit = deviceCheckpointSource.UpperLimit;
            deviceCheckpoint.ModifiedDate = Utility.ConvertDateTime(deviceCheckpointSource.ModifiedDate);

            return deviceCheckpoint;
        }
    }
}
