using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemorizer.Core.DB.Repositories;

namespace WordMemorizer.Core
{
    public partial class FormConsumeScore : Form
    {
        private readonly ConsumeLogRepository _consumeLogRepository;
        private readonly ScoreRecordRepository _scoreRecordRepository;
        public FormConsumeScore()
        {
            InitializeComponent();
            _consumeLogRepository = new ConsumeLogRepository();
            _scoreRecordRepository = new ScoreRecordRepository();
        }

        private void FormConsumeScore_Load(object sender, EventArgs e)
        {
            LoadAndDisplayConsumeRecords();
        }

        public decimal CalculateRemainingScore(int totalScores, int consumedScores)
        {
            // 1. 相减后转换为decimal防止整数除法
            // 2. 除以100
            // 3. 使用Math.Round保留两位小数
            return Math.Round((decimal)(totalScores - consumedScores) / 100m, 2);
        }

        private void LoadAndDisplayConsumeRecords()
        {
            int totalScores = _scoreRecordRepository.GetAllCorrectRecordsCount();
            int consumedScores = _consumeLogRepository.GetTotalConsumedScore();
            LblScores.Text = "累计得分："+totalScores+",累计消费："+consumedScores;
            LblAvailableBalance.Text = "可用余额：" + CalculateRemainingScore(totalScores, consumedScores) + "欧元";
            try
            {
                // 1. 清空现有项
                LVList.Items.Clear();

                // 2. 设置列（如果尚未设置）
                if (LVList.Columns.Count == 0)
                {
                    LVList.View = View.Details;
                    LVList.Columns.Add("ID", 50, HorizontalAlignment.Left);
                    LVList.Columns.Add("消费时间", 150, HorizontalAlignment.Left);
                    LVList.Columns.Add("消费积分", 80, HorizontalAlignment.Right);
                    LVList.FullRowSelect = true;
                }

                // 3. 从数据库获取数据
                var records = _consumeLogRepository.GetAllConsumeLogs();

                // 4. 添加数据到ListView
                foreach (var record in records)
                {
                    var item = new ListViewItem(record.Id.ToString());
                    item.SubItems.Add(record.CreatedTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    item.SubItems.Add("-" + record.ConsumedScore.ToString());
                    item.Tag = record; // 保存原始对象引用

                    LVList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int consumedScore = Tools.StrToInt(TbConsumedScore.Text.Trim());
            if (consumedScore <= 0)
            {
                MessageBox.Show("请输入有效的消费积分！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // 1. 添加消费记录
                int newId = _consumeLogRepository.AddConsumeRecord(consumedScore);
                // 2. 刷新列表
                LoadAndDisplayConsumeRecords();
                // 3. 清空输入框
                TbConsumedScore.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加消费记录失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
