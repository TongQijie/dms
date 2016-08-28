using Petecat.Extension.Attributes;

namespace Dade.Dms.Rest.ServiceModel.Enums
{
    public enum InspectionRecordStatus
    {
        [EnumValue("P")]
        Pending,

        [EnumValue("O")]
        Ongoing,

        [EnumValue("D")]
        Done,

        [EnumValue("C")]
        Closed,
    }
}
