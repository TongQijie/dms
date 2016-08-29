using Dade.Dms.Repo.DataModel;
using Petecat.Extension;
using Dade.Dms.Rest.ServiceModel;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceSparePartTransfer
    {
        public static DeviceSparePart[] BuildDeviceSpareParts(DeviceSparePartSource[] deviceSparePartSources)
        {
            if (deviceSparePartSources == null)
            {
                return null;
            }

            var deviceSpareParts = new DeviceSparePart[0];

            foreach (var deviceSparePartSource in deviceSparePartSources)
            {
                deviceSpareParts = deviceSpareParts.Append(BuildDeviceSparePart(deviceSparePartSource));
            }

            return deviceSpareParts;
        }

        public static DeviceSparePart BuildDeviceSparePart(DeviceSparePartSource deviceSparePartSource)
        {
            if (deviceSparePartSource == null)
            {
                return null;
            }

            var deviceSparePart = new DeviceSparePart();

            deviceSparePart.CreationDate = Utility.ConvertDateTime(deviceSparePartSource.CreationDate);
            deviceSparePart.ModifiedDate = Utility.ConvertDateTime(deviceSparePartSource.ModifiedDate);
            deviceSparePart.Remark = deviceSparePartSource.Remark;
            deviceSparePart.SparePartName = deviceSparePartSource.SparePartName;
            deviceSparePart.SparePartNumber = deviceSparePartSource.SparePartNumber;

            return deviceSparePart;
        }

        public static DeviceSparePartSource[] BuildDeviceSparePartSources(DeviceSparePart[] deviceSpareParts)
        {
            if (deviceSpareParts == null)
            {
                return null;
            }

            var deviceSparePartSources = new DeviceSparePartSource[0];

            foreach (var deviceSparePart in deviceSpareParts)
            {
                deviceSparePartSources = deviceSparePartSources.Append(BuildDeviceSparePartSource(deviceSparePart));
            }

            return deviceSparePartSources;
        }

        public static DeviceSparePartSource BuildDeviceSparePartSource(DeviceSparePart deviceSparePart)
        {
            if (deviceSparePart == null)
            {
                return null;
            }

            var deviceSparePartSource = new DeviceSparePartSource();

            deviceSparePartSource.Remark = deviceSparePart.Remark;
            deviceSparePartSource.SparePartName = deviceSparePart.SparePartName;
            deviceSparePartSource.SparePartNumber = deviceSparePart.SparePartNumber;

            return deviceSparePartSource;
        }
    }
}
