using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Rest.ServiceModel.Services;
using Petecat.Console;
using Petecat.Threading;
using System;

namespace Dade.Test.Rest
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new RestTest();
            test.ScheduleHandlerTest();
            RunTest(test);
            Clean(test);
        }

        static void Container(RestServiceResponse response)
        {
            if (response.HasError)
            {
                foreach (var error in response.Errors)
                {
                    ConsoleBridging.WriteLine("Error: " + error.ErrorMessage);
                }
            }
            else
            {
                ConsoleBridging.WriteLine("done.");
            }

            ConsoleBridging.ReadAnyKey();
        }

        static void AddDevices(int count)
        {
            var startTime = DateTime.Now;

            var i = 0;
            for (; i < count; i++)
            {
                var response = new RestTest().AddDevice();
                if (response.HasError)
                {
                    foreach (var error in response.Errors)
                    {
                        ConsoleBridging.WriteLine("Error: " + error.ErrorMessage);
                    }
                }

                ThreadBridging.Sleep(20);
            }

            ConsoleBridging.WriteLine("count: " + i + "; cost: " + (DateTime.Now - startTime).TotalSeconds + "s");
            ConsoleBridging.ReadAnyKey();
        }

        static int RunTest(RestTest test)
        {
            var step = 0;

            if ((step = test.AddDevice().HasError ? 1 : 0) != 0
                || (step = test.EditDevice().HasError ? 2 : 0) != 0
                || (step = test.QueryDevicesByConditions().HasError ? 3 : 0) != 0)
            {
                ConsoleBridging.WriteLine("error exists. step: " + step);
                ConsoleBridging.ReadAnyKey();
                return step;
            }

            if ((step = test.AddMaintenancePlan().HasError ? 11 : 0) != 0
                || (step = test.EditMaintenancePlan().HasError ? 12 : 0) != 0
                || (step = test.QueryMaintenancePlans().HasError ? 13 : 0) != 0)
            {
                ConsoleBridging.WriteLine("error exists. step: " + step);
                ConsoleBridging.ReadAnyKey();
                return step;
            }

            if ((step = test.AddMaintenanceRecord().HasError ? 21 : 0) != 0
                || (step = test.EditMaintenanceRecord().HasError ? 22 : 0) != 0
                || (step = test.QueryMaintenanceRecords().HasError ? 23 : 0) != 0)
            {
                ConsoleBridging.WriteLine("error exists. step: " + step);
                ConsoleBridging.ReadAnyKey();
                return step;
            }

            if ((step = test.AddInpsectionPlan().HasError ? 31 : 0) != 0
                || (step = test.EditInpsectionPlan().HasError ? 32 : 0) != 0
                || (step = test.QueryInspectionPlans().HasError ? 33 : 0) != 0)
            {
                ConsoleBridging.WriteLine("error exists. step: " + step);
                ConsoleBridging.ReadAnyKey();
                return step;
            }

            if ((step = test.AddInspectionRecord().HasError ? 41 : 0) != 0
                || (step = test.EditInspectionRecord().HasError ? 42 : 0) != 0
                || (step = test.QueryInspectionRecords().HasError ? 43 : 0) != 0)
            {
                ConsoleBridging.WriteLine("error exists. step: " + step);
                ConsoleBridging.ReadAnyKey();
                return step;
            }

            if ((step = test.AddRepairRecord().HasError ? 51 : 0) != 0
               || (step = test.EditRepairRecord().HasError ? 52 : 0) != 0
               || (step = test.QueryRepairRecords().HasError ? 53 : 0) != 0)
            {
                ConsoleBridging.WriteLine("error exists. step: " + step);
                ConsoleBridging.ReadAnyKey();
                return step;
            }

            return step;
        }

        static int Clean(RestTest test)
        {
            var step = 0;

            ConsoleBridging.WriteLine("hit any key to delete data...");
            ConsoleBridging.ReadAnyKey();

            if ((step = test.DeleteRepairRecord().HasError ? 106 : 0) != 0
                ||(step = test.DeleteInspectionRecord().HasError ? 105 : 0) != 0
                || (step = test.DeleteInspectionPlan().HasError ? 104 : 0) != 0
                || (step = test.DeleteMaintenanceRecord().HasError ? 103 : 0) != 0
                || (step = test.DeleteMaintenancePlan().HasError ? 102 : 0) != 0
                || (step = test.DeleteDevice().HasError ? 101 : 0) != 0)
            {
                ConsoleBridging.WriteLine("error exists. step: " + step);
                ConsoleBridging.ReadAnyKey();
                return step;
            }

            ConsoleBridging.WriteLine("done. hit any key to exit...");
            ConsoleBridging.ReadAnyKey();

            return step;
        }
    }
}
