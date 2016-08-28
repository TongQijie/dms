using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Data.Formatters;
using Petecat.Extension;
using Petecat.IoC.Attributes;
using Petecat.Logging;

using System;
using System.Collections.Generic;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(DeviceStateInfoImpl))]
    public class DeviceStateInfoImpl
    {
        //public RestServiceResponse<DeviceStateInfo[]> GetDevicePointStates(RestServiceRequest request)
        //{
        //    var response = new RestServiceResponse<DeviceStateInfo[]>();

        //    try
        //    {
        //        var deviceNumber = request.GetValue<string>("DeviceNumber", null);
        //        if (deviceNumber == null)
        //        {
        //            throw new RestException("", "device number cannot be empty.");
        //        }

        //        var collectorId = request.GetValue<string>("CollectorId", null);
        //        if (collectorId == null)
        //        {
        //            throw new RestException("", "collector id cannot be empty.");
        //        }

        //        var startTime = request.GetValue<string>("StartTime", null);
        //        var endTime = request.GetValue<string>("EndTime", null);
        //        if (!startTime.HasValue() || !endTime.HasValue())
        //        {
        //            throw new RestException("", "start time or end time cannot be empty.");
        //        }

        //        var deviceOperationDatas = DeviceStateInfoRepository.QueryDevicePointStatesByConditions(deviceNumber, collectorId, startTime, endTime);

        //        var deviceStateInfos = new List<DeviceStateInfo>();
        //        foreach (var deviceOperationData in deviceOperationDatas)
        //        {
        //            var deviceStateInfo = DeviceOperationDataConverter.ConvertDeviceStateInfo(deviceOperationData);
        //            if (deviceStateInfo != null)
        //            {
        //                deviceStateInfos.Add(deviceStateInfo);
        //            }
        //        }

        //        response.Body = deviceStateInfos.ToArray();
        //    }
        //    catch (RestException e)
        //    {
        //        response.Errors = new RestServiceResponseError[] { new RestServiceResponseError() { ErrorCode = e.Code, ErrorMessage = e.Message } };
        //    }
        //    catch (Exception e)
        //    {
        //        LoggerManager.GetLogger().LogEvent("DeviceStateInfoImpl", LoggerLevel.Error, "unknown error.", new DataContractJsonFormatter().WriteString(request), e);
        //        response.Errors = new RestServiceResponseError[] { new RestServiceResponseError() { ErrorCode = "", ErrorMessage = "Unknown Error." } };
        //    }

        //    return response;
        //}

        //public RestServiceResponse<DeviceStateInfo[]> GetDevicePeriodStates(RestServiceRequest request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
