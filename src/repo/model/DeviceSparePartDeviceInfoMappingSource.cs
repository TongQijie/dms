using Petecat.Data.Attributes;

namespace Dade.Dms.Repo.DataModel
{
    public class DeviceSparePartDeviceInfoMappingSource
    {
        [CompositeDataMapping(typeof(DeviceSparePartSource), Prefix = "DSPS_")]
        public DeviceSparePartSource DeviceSparePart { get; set; }

        [CompositeDataMapping(typeof(DeviceInfoSource), Prefix = "DIS_")]
        public DeviceInfoSource DeviceInfo { get; set; }
    }
}
