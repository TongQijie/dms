using Dade.Dms.Rest.ServiceModel;
using Petecat.Data.Access;

namespace Dade.Dms.Rest.Impl
{
    internal class DeviceStateInfoRepository
    {
        //public static DeviceOperationData[] QueryDevicePointStatesByConditions(string deviceNumber, string collectorId, string startTime, string endTime)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("DeviceStateInfo_QueryDevicePointStatesByConditions");
        //    dataCommandObject.SetParameterValues("@DeviceNumber", deviceNumber);
        //    dataCommandObject.SetParameterValues("@CollectorId", collectorId);
        //    dataCommandObject.SetParameterValue("@StartTime", startTime);
        //    dataCommandObject.SetParameterValue("@EndTime", endTime);
        //    return dataCommandObject.QueryEntities<DeviceOperationData>().ToArray();
        //}

        //public static DeviceOperationData[] QueryDevicePeriodStatesByConditions(string deviceNumber, string collectorId, string startTime, string endTime)
        //{
        //    var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("DeviceStateInfo_QueryDevicePeriodStatesByConditions");
        //    dataCommandObject.SetParameterValues("@DeviceNumber", deviceNumber);
        //    dataCommandObject.SetParameterValues("@CollectorId", collectorId);
        //    dataCommandObject.SetParameterValue("@StartTime", startTime);
        //    dataCommandObject.SetParameterValue("@EndTime", endTime);
        //    return dataCommandObject.QueryEntities<DeviceOperationData>().ToArray();
        //}
    }
}
