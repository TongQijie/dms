using Dade.Dms.Rest.Impl;
using System;
namespace Dade.Test.Rest
{
    partial class RestTest
    {
        public void ScheduleHandlerTest()
        {
            var datetimes = ScheduleHandler.GenerateDateTime(ScheduleType.Daily, "10:00|22:00", new DateTime(2016, 8, 1), new DateTime(2016, 9, 1));
            datetimes = ScheduleHandler.GenerateDateTime(ScheduleType.Weekly, "1 10:00|4 22:00", new DateTime(2016, 8, 1), new DateTime(2016, 9, 1));
            datetimes = ScheduleHandler.GenerateDateTime(ScheduleType.Monthly, "01 10:00|15 22:00", new DateTime(2016, 1, 1), new DateTime(2016, 9, 1));
            datetimes = ScheduleHandler.GenerateDateTime(ScheduleType.Yearly, "01-01 10:00|06-15 22:00", new DateTime(2000, 1, 1), new DateTime(2016, 9, 1));
            datetimes = ScheduleHandler.GenerateDateTime(ScheduleType.Custom, "2016-01-01 10:00|2016-06-15 22:00", new DateTime(2000, 1, 1), new DateTime(2016, 9, 1));
        }
    }
}
