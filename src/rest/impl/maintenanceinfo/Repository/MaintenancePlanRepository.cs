using System;
using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.IoC.Attributes;

namespace Dade.Dms.Rest.Impl.Repository
{
    [AutoResolvable(typeof(IMaintenancePlanRepository))]
    public class MaintenancePlanRepository : IMaintenancePlanRepository
    {
        public int AddPlan(MaintenancePlan maintenancePlan)
        {
            throw new NotImplementedException();
        }

        public int DeletePlan(MaintenancePlan maintenancePlan)
        {
            throw new NotImplementedException();
        }

        public int EditPlan(MaintenancePlan maintenancePlan)
        {
            throw new NotImplementedException();
        }

        public MaintenancePlan[] QueryPlansByConditions(Paging paging, int id, string deviceNumber)
        {
            throw new NotImplementedException();
        }
    }
}
