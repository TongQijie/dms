using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum DeviceRepairRecordSourceType
    {
        [EnumValue("D")]
        Device,

        [EnumValue("U")]
        User,
    }
}
