using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemorizer.Core.DB;

namespace WordMemorizer.Core
{
    public partial class FormAddWeek : Form
    {
        private readonly WordRepository _wordRepo;
        private readonly WeeklyPlanRepository _weekRepo;
        private readonly WordImporter _wordImporter;
        public FormAddWeek()
        {
            InitializeComponent();

            // 设置TextBox多行和滚动条
            txtWordInput.Multiline = true;
            txtWordInput.ScrollBars = ScrollBars.Vertical;
            txtWordInput.AcceptsTab = true;
            txtWordInput.Font = new Font("Microsoft Sans Serif", 10);
            txtWordInput.Height = 300;

            // 初始化数据库相关对象
            _wordRepo = new WordRepository();
            _weekRepo = new WeeklyPlanRepository();
            _wordImporter = new WordImporter(_wordRepo, _weekRepo);
        }

        private async void BtnCreateWeekPlan_Click(object sender, EventArgs e)
        {
            BtnImport.Enabled = false;
            try
            {
                string inputText = txtWordInput.Text.Trim();
                if (string.IsNullOrWhiteSpace(inputText))
                {
                    MessageBox.Show("请输入要导入的内容");
                    return;
                }

                var importer = new WordImporter(new WordRepository(), new WeeklyPlanRepository());

                // 使用Task.Run避免UI冻结
                var (wordCount, planCount) = await Task.Run(() =>
                    importer.SafeImportToCurrentWeekPlan(inputText));

                MessageBox.Show($"成功导入 {wordCount} 个单词到本周计划");
                txtWordInput.Clear();
            }
            catch (InvalidOperationException ex)
            {
                // 处理计划已存在的情况
                if (MessageBox.Show(ex.Message + "\n\n是否要覆盖现有计划？",
                    "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // 调用覆盖逻辑
                    OverrideCurrentWeekPlan(txtWordInput.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"导入出错: {ex.Message}");
            }
            finally
            {
                BtnImport.Enabled = true;
            }
        }

        private void OverrideCurrentWeekPlan(string text)
        {
            // 1. 删除现有周计划
            var (startDate, endDate) = new WeeklyPlanRepository().GetCurrentWeekDateRange();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                conn.Execute("DELETE FROM WeeklyPlanWords WHERE WeeklyPlanId IN " +
                            "(SELECT Id FROM WeeklyPlans WHERE StartDate = @StartDate)",
                            new { StartDate = startDate });
                conn.Execute("DELETE FROM WeeklyPlans WHERE StartDate = @StartDate",
                            new { StartDate = startDate });
            }

            // 2. 重新导入
            new WordImporter(new WordRepository(), new WeeklyPlanRepository())
                .SafeImportToCurrentWeekPlan(text);
        }
    }
    

}
