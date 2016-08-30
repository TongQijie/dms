using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;
using Petecat.Data.Access;
using Dade.Dms.Repo.DataModel;


namespace Dade.Dms.Rest.Impl.Repository
{
    //[AutoResolvable(typeof(IDeviceInfoRepository))]
    //public class DeviceInfoRepository : IDeviceInfoRepository
    //{
    //    public int AddDevice(DeviceInfo deviceInfo)
    //    {
    //        var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("DeviceInfo_AddDevice");
    //        dataCommandObject.SetParameterValue("@DeviceNumber", deviceInfo.DeviceNumber);
    //        dataCommandObject.SetParameterValue("@DeviceName", deviceInfo.DeviceName);
    //        dataCommandObject.SetParameterValue("@Manufactory", deviceInfo.Manufactory);
    //        dataCommandObject.SetParameterValue("@DateOfManufacture", deviceInfo.DateOfManufacture);
    //        dataCommandObject.SetParameterValue("@Model", deviceInfo.Model);
    //        dataCommandObject.SetParameterValue("@Category", deviceInfo.Category);
    //        dataCommandObject.SetParameterValue("@DeviceIP", deviceInfo.DeviceIP);
    //        dataCommandObject.SetParameterValue("@DevicePort", deviceInfo.DevicePort);
    //        dataCommandObject.SetParameterValue("@DeviceSIM", deviceInfo.DeviceSIM);
    //        dataCommandObject.SetParameterValue("@PeriodOfMAintenance", deviceInfo.PeriodOfMaintenance);
    //        dataCommandObject.SetParameterValue("@ProductionAbility", deviceInfo.ProductionAbility);
    //        dataCommandObject.SetParameterValue("@MaintenanceMaunal", deviceInfo.MaintenanceMaunal);
    //        dataCommandObject.ExecuteNonQuery();
    //        return (int)dataCommandObject.GetParameterValue("@RetVal");
    //    }

    //    public int EditDevice(DeviceInfo deviceInfo)
    //    {
    //        var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("DeviceInfo_EditDevice");
    //        dataCommandObject.SetParameterValue("@DeviceNumber", deviceInfo.DeviceNumber);
    //        dataCommandObject.SetParameterValue("@DeviceName", deviceInfo.DeviceName);
    //        dataCommandObject.SetParameterValue("@Manufactory", deviceInfo.Manufactory);
    //        dataCommandObject.SetParameterValue("@DateOfManufacture", deviceInfo.DateOfManufacture);
    //        dataCommandObject.SetParameterValue("@Model", deviceInfo.Model);
    //        dataCommandObject.SetParameterValue("@Category", deviceInfo.Category);
    //        dataCommandObject.SetParameterValue("@DeviceIP", deviceInfo.DeviceIP);
    //        dataCommandObject.SetParameterValue("@DevicePort", deviceInfo.DevicePort);
    //        dataCommandObject.SetParameterValue("@DeviceSIM", deviceInfo.DeviceSIM);
    //        dataCommandObject.SetParameterValue("@PeriodOfMAintenance", deviceInfo.PeriodOfMaintenance);
    //        dataCommandObject.SetParameterValue("@ProductionAbility", deviceInfo.ProductionAbility);
    //        dataCommandObject.SetParameterValue("@MaintenanceMaunal", deviceInfo.MaintenanceMaunal);
    //        dataCommandObject.ExecuteNonQuery();
    //        return (int)dataCommandObject.GetParameterValue("@RetVal");
    //    }

    //    public int DeleteDevice(DeviceInfo deviceInfo)
    //    {
    //        var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("DeviceInfo_DeleteDevice");
    //        dataCommandObject.SetParameterValue("@DeviceNumber", deviceInfo.DeviceNumber);
    //        dataCommandObject.ExecuteNonQuery();
    //        return (int)dataCommandObject.GetParameterValue("@RetVal");
    //    }

    //    public DeviceInfo[] QueryDevicesByConditions(Paging paging, string deviceNumber, string deviceName)
    //    {
    //        var dataCommandObject = DataCommandObjectManager.Instance.GetDataCommandObject("DeviceInfo_QueryDevicesByConditions");
    //        dataCommandObject.SetParameterValue("@PageNumber", paging.PageNumber <= 0 ? 1 : paging.PageNumber);
    //        dataCommandObject.SetParameterValue("@PageSize", paging.PageSize <= 0 ? 10 : paging.PageSize);
    //        dataCommandObject.SetParameterValue("@DeviceNumber", deviceNumber);
    //        dataCommandObject.SetParameterValue("@DeviceName", deviceName);
    //        var result = dataCommandObject.QueryEntities<DeviceInfoSource>().ToArray();
    //        paging.TotalPages = (int)dataCommandObject.GetParameterValue("@TotalPages");
    //        paging.PageNumber = paging.PageNumber > paging.TotalPages ? 1 : paging.PageNumber;
    //        return DeviceInfoTransfer.BuildDeviceInfos(result);
    //    }
    //}
}
