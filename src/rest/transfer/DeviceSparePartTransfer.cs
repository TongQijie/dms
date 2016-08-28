using Dade.Dms.Repo.RepoModel;
using Dade.Dms.Rest.ServiceModel;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceSparePartTransfer
    {
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
    }
}
