using Dade.Dms.Rest.ServiceModel.Services;
namespace Dade.Dms.Rest.ServiceModel.Errors
{
    public class DeviceNotFoundException : RestException
    {
        public DeviceNotFoundException(string deviceNumber)
            : base(ErrorCodes.DeviceNotFoundException, string.Format("device '{0}' does not exist.", deviceNumber))
        {
        }
    }
}
