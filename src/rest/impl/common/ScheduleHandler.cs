using System;

using Petecat.Extension;
using System.Globalization;

namespace Dade.Dms.Rest.Impl
{
    public static class ScheduleHandler
    {
        /// <summary>
        /// Yearly: 01-10 10:00|07-10 10:00
        /// Monthly: 01 10:00|10 10:00|20 10:00
        /// Weekly: 1 10:00|4 10:00
        /// Daily: 10:00|22:00
        /// Custom: 2016-10-01 10:00|2017-01-10 10:00
        /// </summary>
        /// <param name="scheduleType"></param>
        /// <param name="scheduleValue"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public static DateTime[] GenerateDateTime(ScheduleType scheduleType, string scheduleValue, DateTime dateFrom, DateTime dateTo)
        {
            var datetimes = new DateTime[0];

            switch (scheduleType)
            {
                case ScheduleType.Daily:
                    {
                        var values = scheduleValue.SplitByChar('|');
                        foreach (var value in values)
                        {
                            DateTime datetime;
                            if (DateTime.TryParseExact(value, "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out datetime))
                            {
                                var date = dateFrom.Date;
                                while (date < dateTo.Date)
                                {
                                    var day = date.AddHours(datetime.Hour).AddMinutes(datetime.Minute);
                                    datetimes = datetimes.Append(day);
                                    date = date.AddDays(1);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        break;
                    }
                case ScheduleType.Weekly:
                    {
                        var values = scheduleValue.SplitByChar('|');
                        foreach (var value in values)
                        {
                            int val;
                            var parts = value.SplitByChar(' ');
                            if (parts.Length != 2 || !int.TryParse(parts[0], out val))
                            {
                                return null;
                            }

                            DayOfWeek dayOfWeek = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), val);

                            DateTime datetime;
                            if (DateTime.TryParseExact(parts[1], "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out datetime))
                            {
                                DateTime? date = FindDayOfWeek(dayOfWeek, dateFrom, dateTo);
                                while (date != null)
                                {
                                    var day = ((DateTime)date).AddHours(datetime.Hour).AddMinutes(datetime.Minute);
                                    datetimes = datetimes.Append(day);
                                    date = FindDayOfWeek(dayOfWeek, ((DateTime)date).AddDays(1), dateTo);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        break;
                    }
                case ScheduleType.Monthly:
                    {
                        var values = scheduleValue.SplitByChar('|');
                        foreach (var value in values)
                        {
                            DateTime datetime;
                            if (DateTime.TryParseExact(value, "dd HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out datetime))
                            {
                                var day = new DateTime(dateFrom.Year, dateFrom.Month, datetime.Day, datetime.Hour, datetime.Minute, 0);
                                while (day.Date < dateTo.Date)
                                {
                                    datetimes = datetimes.Append(day);
                                    day = day.AddMonths(1);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        break;
                    }
                case ScheduleType.Yearly:
                    {
                        var values = scheduleValue.SplitByChar('|');
                        foreach (var value in values)
                        {
                            DateTime datetime;
                            if (DateTime.TryParseExact(value, "MM-dd HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out datetime))
                            {
                                var day = new DateTime(dateFrom.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, 0);
                                while (day.Date < dateTo.Date)
                                {
                                    datetimes = datetimes.Append(day);
                                    day = day.AddYears(1);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        break;
                    }
                case ScheduleType.Custom:
                    {
                        var values = scheduleValue.SplitByChar('|');
                        foreach (var value in values)
                        {
                            DateTime datetime;
                            if (DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out datetime))
                            {
                                if (datetime > dateFrom && datetime < dateTo)
                                {
                                    datetimes = datetimes.Append(datetime);
                                }
                                else
                                {
                                    return null;
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        break;
                    }
                default:
                    {
                        return null;
                    }
            }

            return datetimes;
        }

        private static DateTime? FindDayOfWeek(DayOfWeek dayOfWeek, DateTime dateFrom, DateTime dateTo)
        {
            var date = dateFrom.Date;
            while (date < dateTo.Date)
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    return date;
                }
                else
                {
                    date = date.AddDays(1);
                }
            }

            return null;
        }
    }
}
