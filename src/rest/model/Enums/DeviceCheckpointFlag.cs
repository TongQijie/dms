using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum DeviceCheckpointFlag
    {
        [EnumValue("S")]
        Boolean,

        [EnumValue("R")]
        Range,
    }
}
