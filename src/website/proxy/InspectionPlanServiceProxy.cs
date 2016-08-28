using Dade.Dms.Rest.ServiceModel;

using Petecat.Extension;
using Petecat.Service.Client;

namespace Dade.Dms.Website.RestProxy
{
    public static class InspectionPlanServiceProxy
    {
        public static RestServiceResponse Add(InspectionPlan inspectionPlan)
        {
            return new ServiceClientBase("operate-inspection-plan").Call<RestServiceResponse<InspectionPlan>>(new RestServiceRequest<InspectionPlan>()
            {
                Body = inspectionPlan,
                ActionName = "Add"
            });
        }

        public static RestServiceResponse Edit(InspectionPlan inspectionPlan)
        {
            return new ServiceClientBase("operate-inspection-plan").Call<RestServiceResponse<InspectionPlan>>(new RestServiceRequest<InspectionPlan>()
            {
                Body = inspectionPlan,
                ActionName = "Edit",
            });
        }

        public static RestServiceResponse Delete(int inspectionPlanId)
        {
            return new ServiceClientBase("operate-inspection-plan").Call<RestServiceResponse<InspectionPlan>>(new RestServiceRequest<InspectionPlan>()
            {
                Body = new InspectionPlan()
                {
                    Id = inspectionPlanId,
                },
                ActionName = "Delete",
            });
        }

        public static RestServiceResponse Query(Paging paging, int id = 0, string deviceNumber = null, string deviceName = null)
        {
            var keyValues = new KeyValuePair[0];
            if (id > 0)
            {
                keyValues = keyValues.Append(new KeyValuePair("Id", id.ToString()));
            }
            if (!string.IsNullOrWhiteSpace(deviceNumber))
            {
                keyValues = keyValues.Append(new KeyValuePair("DeviceNumber", deviceNumber.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(deviceName))
            {
                keyValues = keyValues.Append(new KeyValuePair("DeviceName", deviceName.Trim()));
            }

            return new ServiceClientBase("get-inspection-plan-list").Call<RestServiceResponse<InspectionPlan[]>>(new RestServiceRequest()
            {
                KeyValues = keyValues,
                Paging = paging,
            });
        }
    }
}
