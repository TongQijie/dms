using Dade.Dms.Repo.DataModel;
using Dade.Dms.Rest.ServiceModel;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class DeviceFaultCategoryTransfer
    {
        public static DeviceFaultCategory BuildDeviceFaultCategory(DeviceFaultCategorySource deviceFaultCategorySource)
        {
            if (deviceFaultCategorySource == null)
            {
                return null;
            }

            var deviceFaultCategory = new DeviceFaultCategory();

            deviceFaultCategory.Description = deviceFaultCategorySource.Description;
            deviceFaultCategory.Id = deviceFaultCategorySource.Id;
            deviceFaultCategory.Title = deviceFaultCategorySource.Title;

            return deviceFaultCategory;
        }

        public static DeviceFaultCategorySource BuildDeviceFaultCategorySource(DeviceFaultCategory deviceFaultCategory)
        {
            if (deviceFaultCategory == null)
            {
                return null;
            }

            var deviceFaultCategorySource = new DeviceFaultCategorySource();

            deviceFaultCategorySource.Description = deviceFaultCategory.Description;
            deviceFaultCategorySource.Id = deviceFaultCategory.Id;
            deviceFaultCategorySource.Title = deviceFaultCategory.Title;

            return deviceFaultCategorySource;
        }
    }
}
