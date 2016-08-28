namespace Dade.Dms.Rest.ServiceModel.Services
{
    public class RestServiceResponse<T> : RestServiceResponse where T : class
    {
        public T Body { get; set; }
    }
}