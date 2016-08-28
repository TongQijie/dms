using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Enums;
using Petecat.Extension;
using System.Collections.Generic;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceInfoTransfer
    {
        public static DeviceInfo[] BuildDeviceInfos(IEnumerable<DeviceInfoSource> deviceInfoSources)
        {
            if (deviceInfoSources == null)
            {
                return null;
            }

            var deviceInfos = new DeviceInfo[0];

            foreach (var deviceInfoSource in deviceInfoSources)
            {
                deviceInfos = deviceInfos.Append(BuildDeviceInfo(deviceInfoSource));
            }

            return deviceInfos;
        }

        public static DeviceInfo BuildDeviceInfo(DeviceInfoSource deviceInfoSource)
        {
            if (deviceInfoSource == null)
            {
                return null;
            }

            var deviceInfo = new DeviceInfo();

            deviceInfo.Category = deviceInfoSource.Category;
            deviceInfo.CreationDate = Utility.ConvertDateTime(deviceInfoSource.CreationDate);
            deviceInfo.DateOfManufacture = Utility.ConvertDateTime(deviceInfoSource.DateOfManufacture);
            deviceInfo.DeviceIP = deviceInfoSource.DeviceIP;
            deviceInfo.DeviceName = deviceInfoSource.DeviceName;
            deviceInfo.DeviceNumber = deviceInfoSource.DeviceNumber;
            deviceInfo.DevicePort = deviceInfoSource.DevicePort;
            deviceInfo.DeviceSIM = deviceInfoSource.DeviceSIM;
            deviceInfo.MaintenanceMaunal = deviceInfoSource.MaintenanceMaunal;
            deviceInfo.Manufactory = deviceInfoSource.Manufactory;
            deviceInfo.Model = deviceInfoSource.Model;
            deviceInfo.ModifiedDate = Utility.ConvertDateTime(deviceInfoSource.ModifiedDate);
            deviceInfo.PeriodOfMaintenance = deviceInfoSource.PeriodOfMaintenance;
            deviceInfo.ProductionAbility = deviceInfoSource.ProductionAbility;
            deviceInfo.Status = (DeviceInfoStatus)typeof(DeviceInfoStatus).GetEnumByValue(deviceInfoSource.Status);

            return deviceInfo;
        }

        public static DeviceInfoSource BuildDeviceInfoSource(DeviceInfo deviceInfo)
        {
            var deviceInfoSource = new DeviceInfoSource();

            deviceInfoSource.Category = deviceInfo.Category;
            deviceInfoSource.DateOfManufacture = Utility.ConvertDateTime(deviceInfo.DateOfManufacture);
            deviceInfoSource.DeviceIP = deviceInfo.DeviceIP;
            deviceInfoSource.DeviceName = deviceInfo.DeviceName;
            deviceInfoSource.DeviceNumber = deviceInfo.DeviceNumber;
            deviceInfoSource.DevicePort = deviceInfo.DevicePort;
            deviceInfoSource.DeviceSIM = deviceInfo.DeviceSIM;
            deviceInfoSource.MaintenanceMaunal = deviceInfo.MaintenanceMaunal;
            deviceInfoSource.Manufactory = deviceInfo.Manufactory;
            deviceInfoSource.Model = deviceInfo.Model;
            deviceInfoSource.PeriodOfMaintenance = deviceInfo.PeriodOfMaintenance;
            deviceInfoSource.ProductionAbility = deviceInfo.ProductionAbility;
            deviceInfoSource.Status = typeof(DeviceInfoStatus).GetValueByEnum(deviceInfo.Status);

            return deviceInfoSource;
        }
    }
}
