using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Petecat.Logging;
using Petecat.Network.Ftp;
using Petecat.Extension;
using Petecat.Caching;

namespace Dade.Dms.Dev.Brother
{
    public class FtpDeviceDataSourceBase : AbstractDeviceDataSource
    {
        public FtpDeviceDataSourceBase(string deviceNumber, string collectorId, string ftpPath, string cacheFilePath)
        {
            DeviceNumber = deviceNumber;
            CollectorId = collectorId;
            FtpPath = ftpPath;
            CacheFilePath = cacheFilePath;

            _WritableCacheObject = CacheObjectManager.Instance.Add(ftpPath, 
                () =>
                {
                    if (!File.Exists(CacheFilePath.FullPath()))
                    {
                        File.Create(CacheFilePath.FullPath()).Close();
                    }

                    var values = new List<string>();
                    using (var streamReader = new StreamReader(CacheFilePath.FullPath(), Encoding.Default))
                    {
                        string line = null;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            values.Add(line);
                        }
                    }
                    return values;
                }, 
                (value) =>
                {
                    using (var streamWriter = new StreamWriter(CacheFilePath.FullPath(), false, Encoding.Default))
                    {
                        (value as List<string>).ForEach(x => streamWriter.WriteLine(x));
                    }
                }) as IWritableCacheObject;
        }

        protected string FtpPath { get; set; }

        #region Cache

        public string CacheFilePath { get; private set; }

        protected IWritableCacheObject _WritableCacheObject = null;

        protected List<string> GetCacheObjectValue()
        {
            try
            {
                return _WritableCacheObject.GetValue() as List<string>;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("cache object '{0}' value cannot be reach.", CacheFilePath), e);
            }
        }

        #endregion

        protected List<Data.DeviceData> UploadDeviceData = new List<Data.DeviceData>();

        public override void Execute()
        {
            try
            {
                BeforeDownload();

                var request = new FtpClientRequest(FtpVerb.DownloadFile, FtpPath);
                using (var response = request.GetResponse())
                {
                    using (var streamReader = new StreamReader(response.Response.GetResponseStream()))
                    {
                        string lineText = null;
                        while ((lineText = streamReader.ReadLine()) != null)
                        {
                            if (!string.IsNullOrWhiteSpace(lineText))
                            {
                                ParseLine(lineText);
                            }
                        }
                    }
                }

                AfterDownload();
            }
            catch (Exception e)
            {
                LoggerManager.GetLogger().LogEvent("FtpDeviceDataSourceBase", LoggerLevel.Error, string.Format("'{0}' fails to download. ", FtpPath), e);
            }
            finally
            {
                Finally();
            }
        }

        protected virtual void BeforeDownload() { }

        protected virtual void ParseLine(string lineText) { }

        protected virtual void AfterDownload()
        {
            if (Write(UploadDeviceData.ToArray()))
            {
                var cacheObjectValue = GetCacheObjectValue();
                if (cacheObjectValue != null)
                {
                    foreach (var deviceData in UploadDeviceData)
                    {
                        cacheObjectValue.Add(deviceData.Key);
                    }

                    _WritableCacheObject.Flush();
                }
            }
        }

        protected virtual void Finally()
        {
            UploadDeviceData.Clear();
        }
    }
}
