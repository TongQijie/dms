using Petecat.Data.Attributes;

namespace Dade.Dms.Rest.ServiceModel
{
    public class DeviceOperationData
    {
        [PlainDataMapping]
        public string DeviceNumber { get; set; }

        [PlainDataMapping]
        public string CollectorId { get; set; }

        [PlainDataMapping]
        public string CharValue01 { get; set; }

        [PlainDataMapping]
        public string DateValue01 { get; set; }

        [PlainDataMapping]
        public string StringValue01 { get; set; }

        [PlainDataMapping]
        public string StringValue02 { get; set; }

        [PlainDataMapping]
        public string StringValue03 { get; set; }

        [PlainDataMapping]
        public decimal NumberValue01 { get; set; }

        [PlainDataMapping]
        public decimal NumberValue02 { get; set; }

        [PlainDataMapping]
        public string Remark { get; set; }

        [PlainDataMapping]
        public string CreationDate { get; set; }
    }
}
