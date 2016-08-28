using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;

namespace Dade.Dms.Rest.Imp.Repository
{
    public class DeviceRepairRecordRepository : IDeviceRepairRecordRepository
    {
        public int AddRecord(DeviceRepairRecord deviceRepairRecord)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecord(DeviceRepairRecord deviceRepairRecord)
        {
            throw new NotImplementedException();
        }

        public int EditRecord(DeviceRepairRecord deviceRepairRecord)
        {
            throw new NotImplementedException();
        }

        public DeviceRepairRecord[] QueryRecordsByConditions(Paging paging, int id, string deviceNumber, string[] statuses, string startTime, string endTime)
        {
            throw new NotImplementedException();
        }
    }
}
