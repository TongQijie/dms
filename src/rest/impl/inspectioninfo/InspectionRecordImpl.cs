using Dade.Dms.Rest.Impl.Business;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Data.Formatters;
using Petecat.Extension;
using Petecat.IoC.Attributes;
using Petecat.Logging;
using System;

namespace Dade.Dms.Rest.Impl
{
    [AutoResolvable(typeof(InspectionRecordImpl))]
    public class InspectionRecordImpl
    {
        private IInspectionRecordBusiness _InspectionRecordBusiness;

        public InspectionRecordImpl(IInspectionRecordBusiness inspectionRecordBusiness)
        {
            _InspectionRecordBusiness = inspectionRecordBusiness;
        }

        public RestServiceResponse<InspectionRecord> OperateInspectionRecord(RestServiceRequest<InspectionRecord> request)
        {
            var response = new RestServiceResponse<InspectionRecord>();

            switch (request.ActionName)
            {
                case "Add": _InspectionRecordBusiness.AddRecord(request, response); break;
                case "Edit": _InspectionRecordBusiness.EditRecord(request, response); break;
                case "Delete": _InspectionRecordBusiness.DeleteRecord(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }

        public RestServiceResponse<InspectionRecord[]> GetInspectionRecordList(RestServiceRequest request)
        {
            var response = new RestServiceResponse<InspectionRecord[]>();

            switch (request.ActionName)
            {
                case "ByConditions": _InspectionRecordBusiness.QueryRecordsByConditions(request, response); break;
                default: throw new RestException("", string.Format("it does not support action '{0}'.", request.ActionName));
            }

            return response;
        }
    }
}
