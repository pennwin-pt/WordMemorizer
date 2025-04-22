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
using WordMemorizer.Core.Audio;
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
        private readonly ConfigIniHelper _configIniHelper = new ConfigIniHelper();
        private readonly List<WeeklyPlan> _allWeekPlans = new List<WeeklyPlan>();

        private readonly PortugueseTTS _speaker;

        private int _currentIndex = 0;
        public FormAddWeek()
        {
            InitializeComponent();

            // 初始化数据库相关对象
            _wordRepo = new WordRepository();
            _weeklyPlanRepo = new WeeklyPlanRepository();
            _wordImporter = new WordImporter(_wordRepo, _weeklyPlanRepo);
            string audioFolder = _configIniHelper.GetValue(Constants.AUDIO_PATH_KEY, Constants.DEFAULT_AUDIO_PATH);
            // 初始化语音合成器
            _speaker = new PortugueseTTS(audioFolder);
            //_speaker = new SpeechSynthesizer();
            //_speaker.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new CultureInfo("pt-PT")); 
            //_speaker.Rate = -3; // 设置语速
        }

        private void FormAddWeek_Load(object sender, EventArgs e)
        {
            LoadAllWeekPlans();
            if (_allWeekPlans.Count > 0)
            {
                _currentIndex = _allWeekPlans.Count - 1;
            }
            LblIndex.Text = $"{_currentIndex + 1}/{_allWeekPlans.Count}";
            RefreshWeekPlanDetails();
        }

        private void LoadAllWeekPlans()
        {
            _allWeekPlans.Clear();
            _allWeekPlans.AddRange(_weeklyPlanRepo.GetAllWeeklyPlans());
        }

        private void BtnReCreateWeekPlan_Click(object sender, EventArgs e)
        {
            // 1. 删除现有周计划
            _weeklyPlanRepo.DeleteCurrentWeekPlanIfExists();

            // 2. 重新导入
            _wordImporter.AppendToCurrentWeekPlan(txtWordInput.Text);
            RefreshWeekPlanDetails();
        }

        private void RefreshWeekPlanDetails()
        {
            bool IsTextHidden = CBHideText.Checked;
            bool IsChineseMeaningHidden = CBHideChinese.Checked;
            if (_allWeekPlans.Count == 0)
            {
                return;
            }
            WeeklyPlan currentWeeklyPlan = _allWeekPlans[_currentIndex];
            int currentWeeklyPlanId = currentWeeklyPlan.Id;
            List<Word> wordList = _weeklyPlanRepo.GetWordsInWeeklyPlan(currentWeeklyPlanId).ToList();
            LblCount.Text = $"日期: {Tools.CalcShortDate(currentWeeklyPlan.StartDate)} - {Tools.CalcShortDate(currentWeeklyPlan.EndDate)}, 单词数量: {wordList.Count}";
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

            RefreshWeekPlanDetails();
        }

        private async Task LvWeeklyPlan_MouseDoubleClickAsync(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = LvWeeklyPlan.GetItemAt(e.X, e.Y);

            if (clickedItem != null)
            {
                string itemText = clickedItem.Text;
                string wordText = clickedItem.SubItems[1].Text;
                if(wordText.Equals(""))
                {
                    Word word = _wordRepo.GetWordById(int.Parse(itemText));
                    await _speaker.Speak(word.Text);
                } 
                else
                {
                    await _speaker.Speak(wordText);
                }
                
            }
        }

        private void CBHideText_CheckedChanged(object sender, EventArgs e)
        {
            RefreshWeekPlanDetails();

        }

        private void CBHideChinese_CheckedChanged(object sender, EventArgs e)
        {
            RefreshWeekPlanDetails();
        }

        private void BtnNextWeek_Click(object sender, EventArgs e)
        {
            if ( _currentIndex >= _allWeekPlans.Count - 1)
            {
                MessageBox.Show("已经是最新的周计划了");
                return;
            }
            _currentIndex++;
            LblIndex.Text = $"{_currentIndex + 1}/{_allWeekPlans.Count}";
            RefreshWeekPlanDetails();
        }

        private void BtnPrevWeek_Click(object sender, EventArgs e)
        {
            if (_currentIndex <= 0)
            {
                MessageBox.Show("已经是最旧的周计划了");
                return;
            }
            _currentIndex--;
            LblIndex.Text = $"{_currentIndex + 1}/{_allWeekPlans.Count}";
            RefreshWeekPlanDetails();
        }
    }
    

}
