using Dade.Dms.Rest.ServiceModel.Services;
namespace Dade.Dms.Rest.ServiceModel.Errors
{
    public class ActionNotSupportedException : RestException
    {
        public ActionNotSupportedException(string actionName)
            : base(ErrorCodes.ActionNotSupportedException, string.Format("it does not support action '{0}'", actionName))
        {
        }
    }
}
