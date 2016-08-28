using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum DeviceInfoStatus
    {
        [EnumValue("A")]
        Available,

        [EnumValue("N")]
        NotAvailable,
    }
}
