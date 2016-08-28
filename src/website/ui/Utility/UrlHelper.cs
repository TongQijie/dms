using System;
using System.Text.RegularExpressions;

namespace Dade.Dms.Website
{
    public static class UrlHelper
    {
        public static string ToUrl(this string url)
        {
            return WrapToLower(url);
        }

        public static string WrapToLower(string url)
        {
            return url.ToLower();
        }

        public static bool IsIpHost(string host)
        {
            return Regex.IsMatch(host, @"^\d{1,3}\x2E\d{1,3}\x2E\d{1,3}\x2E\d{1,3}(?:\x3A\d{1,5})?$");
        }
    }
}

