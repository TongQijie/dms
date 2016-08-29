using Dade.Dms.Rest.ServiceModel.Services;
namespace Dade.Dms.Rest.ServiceModel.Errors
{
    public class UndefinedException : RestException
    {
        public UndefinedException(object anything)
            : base(ErrorCodes.UndefinedException, string.Format("undefined error with message '{0}'", anything))
        {
        }
    }
}
