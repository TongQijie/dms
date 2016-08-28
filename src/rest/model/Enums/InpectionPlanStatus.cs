using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum InpectionPlanStatus
    {
        [EnumValue("A")]
        Available,

        [EnumValue("S")]
        Suspend,

        [EnumValue("N")]
        Closed,
    }
}
