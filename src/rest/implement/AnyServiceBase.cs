using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Data.Access;
using Petecat.Data.Formatters;
using Petecat.Extension;
using Petecat.Logging;
using System;

namespace Dade.Dms.Rest.ServiceImplement
{
    public class AnyServiceBase
    {
        static AnyServiceBase()
        {
            DatabaseObjectManager.Instance.Initialize("./Configuration/Data/DatabaseObjects.config".FullPath());
            DataCommandObjectManager.Instance.Initialize("./Configuration/Data/DataCommandObjects.config".FullPath());
        }

        public virtual TResponse Sandbox<TRequest, TResponse>(TRequest request, Func<TRequest, TResponse> handler) 
            where TRequest : RestServiceRequest
            where TResponse : RestServiceResponse
        {
            var response = Activator.CreateInstance<TResponse>();

            try
            {
                return handler(request);
            }
            catch (RestException e)
            {
                if (response.Errors == null)
                {
                    response.Errors = new RestServiceResponseError[0];
                }
                response.Errors = response.Errors.Append(new RestServiceResponseError(e.Code, e.Message));
            }
            catch (Exception e)
            {
                LoggerManager.GetLogger().LogEvent(handler.Method.Name, LoggerLevel.Error, "unknown error.", new DataContractJsonFormatter().WriteString(request), e);
                if (response.Errors == null)
                {
                    response.Errors = new RestServiceResponseError[0];
                }
                response.Errors = response.Errors.Append(new RestServiceResponseError("999999", "Unknown Error."));
            }

            return response;
        }
    }
}
