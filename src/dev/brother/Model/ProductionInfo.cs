using System;
using System.Globalization;

namespace Dade.Dms.Dev.Brother.Model
{
    public class ProductionInfo
    {
        public string TimeValue { get; set; }

        public string StatusValue { get; set; }

        public string LanguageValue { get; set; }

        public string FolderValue { get; set; }

        public DateTime Time
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(TimeValue))
                {
                    DateTime time;
                    if(DateTime.TryParseExact(TimeValue, "yyyyMMddHHmmss", CultureInfo.CurrentCulture, DateTimeStyles.None, out time))
                    {
                        return time;
                    }
                }

                return new DateTime();
            }
        }

        public string Status
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(StatusValue))
                {
                    switch (StatusValue)
                    {
                        case "1": return "电源关闭";
                        case "2": return "待机模式";
                        case "3": return "正在运行";
                        case "4": return "已停止";
                        case "5": return "错误";
                        default: return string.Empty;
                    }
                }

                return string.Empty;
            }
        }

        public string Language
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(LanguageValue))
                {
                    switch (LanguageValue)
                    {
                        case "0": return "NC";
                        case "1": return "对话";
                        default: return string.Empty;
                    }
                }

                return string.Empty;
            }
        }

        public string Folder
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(FolderValue))
                {
                    return FolderValue.Trim('\'').Trim();
                }

                return string.Empty;
            }
        }
    }
}
