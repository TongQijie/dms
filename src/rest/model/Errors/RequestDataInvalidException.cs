using Dade.Dms.Rest.ServiceModel.Services;
namespace Dade.Dms.Rest.ServiceModel.Errors
{
    public class RequestDataInvalidException : RestException
    {
        public RequestDataInvalidException(params string[] parameters)
            : base(ErrorCodes.RequestDataInvalidException, string.Format("parameters '{0}' in request exists invalid data.", string.Join(",", parameters)))
        {
        }
    }
}
