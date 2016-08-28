using Petecat.Extension;
using Petecat.Utility;
using System;

namespace Dade.Dms.Rest.ModelTransfer
{
    public static class Utility
    {
        public static string ConvertDateTime(string dateTimeString)
        {
            if (dateTimeString.HasValue())
            {
                DateTime dateTime;
                if (Converter.TryBeAssignable<DateTime>(dateTimeString, out dateTime))
                {
                    return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

            return null;
        }
    }
}
