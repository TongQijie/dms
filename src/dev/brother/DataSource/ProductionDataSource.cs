using Petecat.Extension;
using Petecat.IoC.Attributes;

using System.Linq;

namespace Dade.Dms.Dev.Brother
{
    [Resolvable]
    public class ProductionDataSource : FtpDeviceDataSourceBase
    {
        public ProductionDataSource(string deviceNumber, string collectorId, string ftpPath, string cacheFilePath) 
            : base(deviceNumber, collectorId, ftpPath, cacheFilePath)
        {
        }

        protected override void ParseLine(string lineText)
        {
            var fields = lineText.SplitByChar(',');
            if (fields.Length >= 6 && (fields[0] == "C01" || fields[0].StartsWith("B")))
            {
                var deviceData = new Data.DeviceData()
                {
                    DeviceNumber = DeviceNumber,
                    CollectorId = CollectorId,
                    Values = fields.Skip(1).ToArray(),
                };

                var cacheObjectValue = GetCacheObjectValue();
                if (cacheObjectValue != null && !cacheObjectValue.Exists(x => x == deviceData.Key))
                {
                    UploadDeviceData.Add(deviceData);
                }
            }
        }

        protected override void AfterDownload()
        {
            base.AfterDownload();

            // TODO: write device running state to db 
        }
    }
}
