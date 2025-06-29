using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static bool AreSimilarWords(string word1, string word2, bool isPortuguese)
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
            double similarityThreshold = isPortuguese ? Constants.WORDS_SIMILARITY_THRESHOLD_PT : Constants.WORDS_SIMILARITY_THRESHOLD_ZH;
            return threshold1 >  similarityThreshold || threshold2 > similarityThreshold;
        }

        public static bool ShowNumberInputDialog(Form parent, string correctCode, Action onSuccess)
        {
            using (var form = new Form())
            {
                form.Text = "数字验证";
                form.Width = 300;
                form.Height = 180;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;

                var lbl = new Label { Text = "请输入验证码：", Left = 20, Top = 20, Width = 260 };
                var txt = new TextBox { Left = 20, Top = 50, Width = 240 };
                txt.PasswordChar = '*';
                txt.KeyPress += (s, e) => {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') // 只允许数字和退格
                        e.Handled = true;
                };

                var btnOK = new Button { Text = "验证", Left = 120, Top = 100, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "取消", Left = 200, Top = 100, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { lbl, txt, btnOK, btnCancel });
                form.AcceptButton = btnOK;
                form.CancelButton = btnCancel;

                if (form.ShowDialog(parent) == DialogResult.OK)
                {
                    if (txt.Text == correctCode)
                    {
                        onSuccess?.Invoke();
                        return true;
                    }
                    MessageBox.Show("验证码错误！");
                }
                return false;
            }
        }

        internal static string GenerateBatchNumber()
        {
             return DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        }

        internal static DateTime ConvertUtcStringToDateTime(string utcDateTimeString)
        {
            // 定义输入字符串的格式
            string format = "yyyyMMddHHmmss";
            // 使用DateTime.ParseExact方法进行转换，并假设输入是UTC时间
            // 注意：ParseExact本身不处理时区，它只是解析字符串为DateTime
            // DateTimeKind.Utc用于标记解析后的时间为UTC
            DateTime utcDateTime = DateTime.SpecifyKind(
                DateTime.ParseExact(utcDateTimeString, format, CultureInfo.InvariantCulture),
                DateTimeKind.Utc
            );
            return utcDateTime;
        }

        internal static int StrToInt(string v)
        {
            return int.TryParse(v, out int result) ? result : 0;
        }

        internal static string CalcShortDate(DateTime startDate)
        {
            // 返回：几月几日，e.g.: 0923 这样的格式
            return startDate.ToString("MM/dd");
        }

        internal static string EliminatePathSeperator(string line)
        {
            return line.Replace("/", " , ");
        }

        public static async Task RunPythonScriptAsync()
        {
            string scriptPath = @"C:\Penn\05Work\Audio2TextAI\main.py";

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/K python \"{scriptPath}\"", // /K 保持窗口打开
                UseShellExecute = true,  // 必须为 true 才能显示窗口
                CreateNoWindow = false   // 显示窗口
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                await Task.Run(() => process.WaitForExit()); // 异步等待进程结束
            }
        }

        public static async Task<bool> CheckServerConnectionAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(3); // 设置超时时间
                    var response = await client.GetAsync(Constants.SERVER_URL);
                    return response.IsSuccessStatusCode; // 返回 true 表示可连接
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"连接失败: {ex.Message}");
                return false;
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"请求超时: {ex.Message}");
                return false;
            }
        }

    }
}
