namespace Dade.Dms.Rest.ServiceModel.Services
{
    public class RestServiceResponse
    {
        public RestServiceResponseError[] Errors { get; set; }

        public Paging Paging { get; set; }

        public bool HasError
        {
            get { return Errors != null && Errors.Length > 0; }
        }
    }
}
