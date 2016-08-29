using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel;
using Petecat.Extension;
namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceSparePartDeviceInfoMappingTransfer
    {
        public static DeviceSparePartDeviceInfoMapping[] BuildDeviceSparePartDeviceInfoMappings(DeviceSparePartDeviceInfoMappingSource[] deviceSparePartDeviceInfoMappingSources)
        {
            if (deviceSparePartDeviceInfoMappingSources == null)
            {
                return null;
            }

            var deviceSparePartDeviceInfoMappings = new DeviceSparePartDeviceInfoMapping[0];

            foreach (var deviceSparePartDeviceInfoMappingSource in deviceSparePartDeviceInfoMappingSources)
            {
                deviceSparePartDeviceInfoMappings = deviceSparePartDeviceInfoMappings.Append(BuildDeviceSparePartDeviceInfoMapping(deviceSparePartDeviceInfoMappingSource));
            }

            return deviceSparePartDeviceInfoMappings;
        }

        public static DeviceSparePartDeviceInfoMapping BuildDeviceSparePartDeviceInfoMapping(DeviceSparePartDeviceInfoMappingSource deviceSparePartDeviceInfoMappingSource)
        {
            if (deviceSparePartDeviceInfoMappingSource == null)
            {
                return null;
            }

            var deviceSparePartDeviceInfoMapping = new DeviceSparePartDeviceInfoMapping();

            deviceSparePartDeviceInfoMapping.DeviceInfo = DeviceInfoTransfer.BuildDeviceInfo(deviceSparePartDeviceInfoMappingSource.DeviceInfo);
            deviceSparePartDeviceInfoMapping.DeviceSparePart = DeviceSparePartTransfer.BuildDeviceSparePart(deviceSparePartDeviceInfoMappingSource.DeviceSparePart);

            return deviceSparePartDeviceInfoMapping;
        }
    }
}
