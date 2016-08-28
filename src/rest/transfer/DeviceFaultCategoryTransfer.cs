using Dade.Dms.Repo.RepoModel;
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
    }
}
