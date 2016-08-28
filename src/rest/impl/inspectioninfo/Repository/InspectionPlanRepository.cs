using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl.Repository
{
    [AutoResolvable(typeof(IInspectionPlanRepository))]
    public class InspectionPlanRepository : IInspectionPlanRepository
    {
        public int AddPlan(InspectionPlan inspectionPlan)
        {
            throw new NotImplementedException();
        }

        public int DeletePlan(InspectionPlan inspectionPlan)
        {
            throw new NotImplementedException();
        }

        public int EditPlan(InspectionPlan inspectionPlan)
        {
            throw new NotImplementedException();
        }

        public InspectionPlan[] QueryPlansByConditions(Paging paging, int id, string deviceNumber)
        {
            throw new NotImplementedException();
        }
    }
}
