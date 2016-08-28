using System;

namespace Dade.Dms.Rest.ServiceModel.Services
{
    public class RestException : Exception
    {
        public RestException(string code, string message) : base(message)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
