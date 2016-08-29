using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl.Repository
{
    [AutoResolvable(typeof(IDeviceSparePartRepository))]
    public class DeviceSparePartRepository : IDeviceSparePartRepository
    {
        public int AddSparePart(DeviceSparePartSource deviceSparePartSource)
        {
            throw new System.NotImplementedException();
        }

        public int EditSparePart(DeviceSparePartSource deviceSparePartSource)
        {
            throw new System.NotImplementedException();
        }

        public int DeleteSparePart(DeviceSparePartSource deviceSparePartSource)
        {
            throw new System.NotImplementedException();
        }

        public DeviceSparePartSource[] QueryDeviceSpareParts(Paging paging, string deviceSparePartNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
