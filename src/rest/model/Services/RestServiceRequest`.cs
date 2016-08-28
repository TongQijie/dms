namespace Dade.Dms.Rest.ServiceModel.Services
{
    public class RestServiceRequest<T> : RestServiceRequest where T : class
    {
        public T Body { get; set; }
    }
}
