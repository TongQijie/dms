using Dade.Dms.Dev.Data;

using Petecat.Data.Access;

using System;
using System.Data.Common;
using System.Globalization;

namespace Dade.Dms.Dev.Repository
{
    internal class DeviceDataRepository
    {
        public static bool Write(DeviceData[] deviceDataCollection)
        {
            var success = false;

            var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("WriteDeviceOperationData");
            dataCommandObject.DatabaseObject.ExecuteTransaction((db) =>
            {
                foreach(var deviceData in deviceDataCollection)
                {
                    if (string.IsNullOrWhiteSpace(deviceData.DeviceNumber) || string.IsNullOrWhiteSpace(deviceData.CollectorId)
                        || deviceData.Values == null || deviceData.Values.Length == 0)
                    {
                        return false;
                    }

                    var dataRowConfig = DataSetConfigurationManager.Instance.GetDataRowConfig(deviceData.CollectorId);
                    if (dataRowConfig == null || dataRowConfig.Fields == null || dataRowConfig.Fields.Length == 0)
                    {
                        return false;
                    }

                    foreach (DbParameter parameter in dataCommandObject.GetDbCommand().Parameters)
                    {
                        parameter.Value = DBNull.Value;
                    }

                    dataCommandObject.SetParameterValue("@DeviceNumber", deviceData.DeviceNumber);
                    dataCommandObject.SetParameterValue("@CollectorId", deviceData.CollectorId);
                    dataCommandObject.SetParameterValue("@Source", deviceData.Key);

                    foreach (var fieldConfig in dataRowConfig.Fields)
                    {
                        if (fieldConfig.Index >= deviceData.Values.Length)
                        {
                            continue;
                        }

                        var value = deviceData.Values[fieldConfig.Index];
                        if (fieldConfig.DataType.Equals("string", StringComparison.OrdinalIgnoreCase))
                        {
                            if (string.IsNullOrEmpty(value))
                            {
                                dataCommandObject.SetParameterValue("@" + fieldConfig.DbRef, fieldConfig.DefaultValue);
                            }
                            else
                            {
                                dataCommandObject.SetParameterValue("@" + fieldConfig.DbRef, value);
                            }
                        }
                        else if (fieldConfig.DataType.Equals("number", StringComparison.OrdinalIgnoreCase))
                        {
                            if (string.IsNullOrEmpty(value))
                            {
                                dataCommandObject.SetParameterValue("@" + fieldConfig.DbRef, decimal.Parse(fieldConfig.DefaultValue));
                            }
                            else
                            {
                                dataCommandObject.SetParameterValue("@" + fieldConfig.DbRef, decimal.Parse(value));
                            }
                        }
                        else if(fieldConfig.DataType.Equals("date", StringComparison.OrdinalIgnoreCase))
                        {
                            if (string.IsNullOrEmpty(value))
                            {
                                dataCommandObject.SetParameterValue("@" + fieldConfig.DbRef, DateTime.ParseExact(fieldConfig.DefaultValue, fieldConfig.Format, CultureInfo.InvariantCulture));
                            }
                            else
                            {
                                dataCommandObject.SetParameterValue("@" + fieldConfig.DbRef, DateTime.ParseExact(value, fieldConfig.Format, CultureInfo.InvariantCulture));
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    db.ExecuteNonQuery(dataCommandObject);
                }

                success = true;
                return true;
            });

            return success;
        }
    }
}
