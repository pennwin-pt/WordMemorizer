using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core
{
    internal class Tools
    {
        // 获取一年中的周数
        public static int GetCurrentWeekNumberOfYear()
        {
            var date = DateTime.Now;
            return System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date,
                System.Globalization.CalendarWeekRule.FirstDay,  // 第一周从1月1日开始算
                DayOfWeek.Sunday);  // 明确指定周一是一周的第一天
        }

        // 获取当前周的日期范围（周一至周日）
        public static (DateTime StartDate, DateTime EndDate) GetCurrentWeekDateRangeEx()
        {
            DateTime today = DateTime.Today;
            int daysSinceMonday = ((int)today.DayOfWeek - 1 + 7) % 7; // 0=周一, 1=周二,...,6=周日

            DateTime startDate = today.AddDays(-daysSinceMonday);
            DateTime endDate = startDate.AddDays(6); // 周一 + 6天 = 周日

            return (startDate.Date, endDate.Date);
        }

        // 获取当前周的日期范围（周日至周六）
        public static (DateTime StartDate, DateTime EndDate) GetCurrentWeekDateRange()
        {
            DateTime today = DateTime.Today;
            int daysSinceSunday = (int)today.DayOfWeek; // 0=周日, 1=周一,...,6=周六

            DateTime startDate = today.AddDays(-daysSinceSunday);
            DateTime endDate = startDate.AddDays(6); // 周日 + 6天 = 周六

            return (startDate.Date, endDate.Date);
        }

        public static string GetCurrentDayOfWeekChinese()
        {
            string[] chineseDays = { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
            int index = ((int)DateTime.Now.DayOfWeek - 1 + 7) % 7;
            return chineseDays[index];
        }
    }
}
