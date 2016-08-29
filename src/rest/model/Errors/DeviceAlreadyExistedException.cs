using Dade.Dms.Rest.ServiceModel.Services;
namespace Dade.Dms.Rest.ServiceModel.Errors
{
    public class DeviceAlreadyExistedException : RestException
    {
        public DeviceAlreadyExistedException(string deviceNumber)
            : base(ErrorCodes.DeviceAlreadyExistedException, string.Format("device number '{0}' already exists.", deviceNumber))
        {
        }
    }
}
