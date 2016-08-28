using Petecat.Extension;
using Petecat.IoC.Attributes;

using System.Collections.Generic;

namespace Dade.Dms.Dev.Brother
{
    [Resolvable]
    public class AlarmDataSource : FtpDeviceDataSourceBase
    {
        public AlarmDataSource(string deviceNumber, string collectorId, string ftpPath, string cacheFilePath) 
            : base(deviceNumber, collectorId, ftpPath, cacheFilePath)
        {
        }

        protected override void ParseLine(string lineText)
        {
            var fields = lineText.SplitByChar(',');

            var deviceData = new Data.DeviceData()
            {
                DeviceNumber = DeviceNumber,
                CollectorId = CollectorId,
                Values = fields,
            };

            var cacheObjectValue = GetCacheObjectValue();
            if (cacheObjectValue != null && !cacheObjectValue.Exists(x => x == deviceData.Key))
            {
                UploadDeviceData.Add(deviceData);
            }
        }
    }
}
