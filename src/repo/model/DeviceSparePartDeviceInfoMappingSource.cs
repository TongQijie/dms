using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.DataModel
{
    public class DeviceSparePartDeviceInfoMappingSource
    {
        [CompositeDataMapping(typeof(DeviceSparePartSource), Prefix = "Spa_")]
        public DeviceSparePartSource DeviceSparePart { get; set; }

        [CompositeDataMapping(typeof(DeviceInfoSource), Prefix = "Dev_")]
        public DeviceInfoSource DeviceInfo { get; set; }
    }
}
