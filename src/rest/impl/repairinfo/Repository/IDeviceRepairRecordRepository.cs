using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Imp.Repository
{
    public interface IDeviceRepairRecordRepository
    {
        int AddRecord(DeviceRepairRecord deviceRepairRecord);

        int EditRecord(DeviceRepairRecord deviceRepairRecord);

        int DeleteRecord(DeviceRepairRecord deviceRepairRecord);

        DeviceRepairRecord[] QueryRecordsByConditions(Paging paging, int id, string deviceNumber, string[] statuses, string startTime, string endTime);
    }
}
