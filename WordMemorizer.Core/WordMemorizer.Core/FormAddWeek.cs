using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemorizer.Core.DB;
using WordMemorizer.Core.DB.Models;
using WordMemorizer.Core.DB.Repositories;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WordMemorizer.Core
{
    public partial class FormAddWeek : Form
    {
        private readonly WordRepository _wordRepo;
        private readonly WeeklyPlanRepository _weeklyPlanRepo;
        private readonly WordImporter _wordImporter;
        private readonly SpeechSynthesizer _speaker;
        public FormAddWeek()
        {
            InitializeComponent();

            // 初始化数据库相关对象
            _wordRepo = new WordRepository();
            _weeklyPlanRepo = new WeeklyPlanRepository();
            _wordImporter = new WordImporter(_wordRepo, _weeklyPlanRepo);
            _speaker = new SpeechSynthesizer();
            _speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new CultureInfo("pt-PT")); 
            _speaker.Rate = -3; // 设置语速
        }

        private void FormAddWeek_Load(object sender, EventArgs e)
        {
            RefreshCurrentWeekPlanDetails(CBHideText.Checked, CBHideChinese.Checked);
        }

        private void BtnReCreateWeekPlan_Click(object sender, EventArgs e)
        {
            // 1. 删除现有周计划
            _weeklyPlanRepo.DeleteCurrentWeekPlanIfExists();

            // 2. 重新导入
            _wordImporter.AppendToCurrentWeekPlan(txtWordInput.Text);
            RefreshCurrentWeekPlanDetails(CBHideText.Checked, CBHideChinese.Checked);
        }

        private void RefreshCurrentWeekPlanDetails(bool IsTextHidden, bool IsChineseMeaningHidden)
        {
            int currentWeeklyPlanId = _weeklyPlanRepo.GetCurrentWeekPlanId();
            List<Word> wordList = _weeklyPlanRepo.GetWordsInWeeklyPlan(currentWeeklyPlanId).ToList();
            LblCount.Text = $"当前周计划单词数量: {wordList.Count}";
            if (wordList.Count > 0)
            {
                LvWeeklyPlan.Items.Clear();
                foreach (var word in wordList)
                {
                    ListViewItem item = new ListViewItem(word.Text);
                    item.Text = word.Id.ToString();
                    item.SubItems.Add(IsTextHidden ? "" : word.Text);
                    item.SubItems.Add(IsChineseMeaningHidden ? "" : word.ChineseMeaning);
                    LvWeeklyPlan.Items.Add(item);
                }
            }
        }

        private void BtnAppend_Click(object sender, EventArgs e)
        {
            _wordImporter.AppendToCurrentWeekPlan(txtWordInput.Text);

            RefreshCurrentWeekPlanDetails(CBHideText.Checked, CBHideChinese.Checked);
        }

        private void LvWeeklyPlan_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = LvWeeklyPlan.GetItemAt(e.X, e.Y);

            if (clickedItem != null)
            {
                string itemText = clickedItem.Text;
                string wordText = clickedItem.SubItems[1].Text;
                if(wordText.Equals(""))
                {
                    Word word = _wordRepo.GetWordById(int.Parse(itemText));
                    _speaker.Speak(word.Text);
                } else
                {
                    _speaker.Speak(wordText);
                }
                
            }
        }

        private void CBHideText_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCurrentWeekPlanDetails(CBHideText.Checked, CBHideChinese.Checked);

        }

        private void CBHideChinese_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCurrentWeekPlanDetails(CBHideText.Checked, CBHideChinese.Checked);

        }
    }
    

}
