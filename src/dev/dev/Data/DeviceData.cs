namespace Dade.Dms.Dev.Data
{
    public class DeviceData
    {
        public string DeviceNumber { get; set; }

        public string CollectorId { get; set; }

        public string[] Values { get; set; }

        public string Key
        {
            get
            {
                return string.Format("{0}|{1}|{2}", DeviceNumber, CollectorId, string.Join("|", Values));
            }
        }
    }
}
