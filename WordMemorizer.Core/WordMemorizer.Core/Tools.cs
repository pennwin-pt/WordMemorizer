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

        public static bool AreSimilarWords(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
                return false;

            // 去重并转换为小写（可选：是否区分大小写）
            var distinctChars1 = word1.ToLower().Distinct().ToList();
            var distinctChars2 = word2.ToLower().Distinct().ToList();

            // 计算共同字符数
            int commonChars = distinctChars1.Count(c => distinctChars2.Contains(c));

            // 判断是否超过50%
            double threshold1 = (double)commonChars / distinctChars1.Count;
            double threshold2 = (double)commonChars / distinctChars2.Count;

            return threshold1 > Constants.WORDS_SIMILARITY_THRESHOLD || threshold2 > Constants.WORDS_SIMILARITY_THRESHOLD;
        }
    }
}
