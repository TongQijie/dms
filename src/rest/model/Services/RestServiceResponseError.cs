namespace Dade.Dms.Rest.ServiceModel.Services
{
    public class RestServiceResponseError
    {
        public RestServiceResponseError()
        {
        }

        public RestServiceResponseError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
