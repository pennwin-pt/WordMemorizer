using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using WordMemorizer.Core.DB.Repositories;
using WordMemorizer.Core.DB.Models;
using WordMemorizer.Core.Audio;


namespace WordMemorizer.Core
{
    public partial class FormMain : Form
    {
        private readonly PortugueseTTS _speaker;
        private readonly WeeklyPlanRepository _weeklyPlanRepository;
        private List<Word> _weekWordList;
        private List<Word> _todayWords = new List<Word>();
        private List<Word> _tomorrowWords = new List<Word>();
        private List<Word> _allDueWords = new List<Word>();
        private int _currentWordIndex = 0;
        private readonly ConfigIniHelper _configIniHelper = new ConfigIniHelper();
        private Rectangle _pnlMainOriginalBounds;

        public FormMain()
        {
            InitializeComponent();
            Sunisoft.IrisSkin.SkinEngine skin = new Sunisoft.IrisSkin.SkinEngine();
            // "Warm.ssk";//"MacOS.ssk";//"XPSilver.ssk";// "EmeraldColor1.ssk";//"MidsummerColor3.ssk";
            // Emerald /DiamondBlue/ Page
            // Calmness  /  SteelBlack
            // mp10pink
            string skinName = "mp10pink";
            skin.SkinFile = System.Environment.CurrentDirectory + "\\skins\\" + skinName + ".ssk";
            skin.Active = true;
            StartPosition = FormStartPosition.CenterScreen;

            string audioFolder = _configIniHelper.GetValue("AudioFolder", Constants.DEFAULT_AUDIO_PATH);
            // 初始化语音合成器
            _speaker = new PortugueseTTS(audioFolder);

            _weeklyPlanRepository = new WeeklyPlanRepository();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _pnlMainOriginalBounds = PnlMain.Bounds;
            InitView();
            ReloadData();
        }

        private void ReloadData()
        {            
            LoadWords();
            _currentWordIndex = 0;
            LblDay.Text = Tools.GetCurrentDayOfWeekChinese();
            LblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DisplayWord(CBHideText.Checked, CBHideChinese.Checked);
        }

        private void LoadWords()
        {
            int currentWeekPlanId = _weeklyPlanRepository.GetCurrentWeekPlanId();
            _weekWordList = _weeklyPlanRepository.GetWordsInWeeklyPlan(currentWeekPlanId).ToList();
            if (_weekWordList.Count == 0)
            {
                return;
            }
            LoadTodayWords();
            LoadAllDueWordsBeforeToday();
        }

        private void InitView()
        {
            TBText.Text = "-";
            TbSentence.Text = "-";
            TBChineseMeaning.Text = "-";
            TbSentenceChinese.Text = "-";
            LblIndex.Text = "0/0";
        }

        private void LoadTodayWords()
        {
            // 清空今天的单词列表
            _todayWords.Clear();
            _tomorrowWords.Clear();

            // 获取当前是星期几（1=周一，7=周日）
            DayOfWeek today = DateTime.Now.DayOfWeek;
            int currentDayIndex = (int)today;

            // 如果是周六或周日，不处理（或可以自定义逻辑）
            if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
            {
                _todayWords.AddRange(_weekWordList);
                _tomorrowWords.AddRange(_weekWordList);
                return;
            }

            // 计算当前是本周的第几个工作日（周一=0，周二=1，...，周五=4）
            int workDayIndex = currentDayIndex - 1;

            // 计算当前天应该取的单词范围
            int todayStartIndex, todayCount;
            int tomorrowStartIndex, tomorrowCount;

            if (today == DayOfWeek.Friday)
            {
                // 周五：取剩余所有单词
                todayStartIndex = workDayIndex * Constants.WORDS_COUNT_PER_DAY;
                todayCount = _weekWordList.Count - todayStartIndex;
                tomorrowStartIndex = 0;
                tomorrowCount = _weekWordList.Count;
            }
            else
            {
                // 周一至周四：每天固定6个单词
                todayStartIndex = workDayIndex * Constants.WORDS_COUNT_PER_DAY;
                todayCount = Constants.WORDS_COUNT_PER_DAY;

                // 确保不超过列表范围
                if (todayStartIndex + todayCount > _weekWordList.Count)
                {
                    todayCount = _weekWordList.Count - todayStartIndex;
                }

                // 计算明天的单词范围
                tomorrowStartIndex = todayStartIndex + todayCount;
                tomorrowCount = Math.Min(Constants.WORDS_COUNT_PER_DAY, _weekWordList.Count - tomorrowStartIndex);
            }

            // 提取今天的单词
            if (todayStartIndex < _weekWordList.Count && todayCount > 0)
            {
                _todayWords.AddRange(_weekWordList.GetRange(todayStartIndex, todayCount));
                _tomorrowWords.AddRange(_weekWordList.GetRange(tomorrowStartIndex, tomorrowCount));
            }
        }

        /// <summary>
        /// 获取今天及之前所有应该学习的单词（包括补学未完成的单词）
        /// </summary>
        /// <returns>包含今天和之前未学单词的列表</returns>
        private void LoadAllDueWordsBeforeToday()
        {
            _allDueWords.Clear();
            DayOfWeek today = DateTime.Now.DayOfWeek;

            // 如果是周末，返回本周所有单词（用于补学）
            if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday || today == DayOfWeek.Friday)
            {
                _allDueWords.AddRange(_weekWordList);
                return;
            }

            // 计算今天是本周第几个工作日（周一=0，周二=1，...，周四=3）
            int currentWorkDayIndex = (int)today - 1;
            // 获取本周所有工作日应该学习的单词
            _allDueWords.AddRange(_weekWordList.GetRange(0, currentWorkDayIndex * Constants.WORDS_COUNT_PER_DAY));
        }

        private async void BtnReadWordText_Click(object sender, EventArgs e)
        {
            if (_currentWordIndex >= _todayWords.Count)
            {
                return;
            }
            await _speaker.Speak(_todayWords[_currentWordIndex].Text);
        }

        private void BtnSetWeek_Click(object sender, EventArgs e)
        {
            FormAddWeek formAddWeek = new FormAddWeek();
            formAddWeek.ShowDialog();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentWordIndex == _todayWords.Count - 1)
            {
                _currentWordIndex = 0;
            }
            else if (_currentWordIndex < _todayWords.Count - 1)
            {
                _currentWordIndex++;
            }
            DisplayWord(CBHideText.Checked, CBHideChinese.Checked);
        }

        private void DisplayWord(bool IsTextHidden, bool IsChineseHidden)
        {
            if(_currentWordIndex >= _todayWords.Count)
            {
                return;
            }
            Word word = _todayWords[_currentWordIndex];
            TBText.Text = IsTextHidden? "-" : word.Text;
            TBChineseMeaning.Text = IsChineseHidden?"-": word.ChineseMeaning;
            TbSentence.Text = IsTextHidden? "-":word.ExampleSentence;
            TbSentenceChinese.Text = IsChineseHidden? "-": word.ExampleChinese;
            LblIndex.Text = $"{_currentWordIndex + 1}/{_todayWords.Count}";
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_currentWordIndex > 0)
            {
                _currentWordIndex--;
            }
            DisplayWord(CBHideText.Checked, CBHideChinese.Checked);
        }

        private void CBHideText_CheckedChanged(object sender, EventArgs e)
        {
            DisplayWord(CBHideText.Checked, CBHideChinese.Checked);

        }

        private void CBHideChinese_CheckedChanged(object sender, EventArgs e)
        {
            DisplayWord(CBHideText.Checked, CBHideChinese.Checked);
        }

        private async void BtnReadSentence_Click(object sender, EventArgs e)
        {
            if (_currentWordIndex >= _todayWords.Count)
            {
                return;
            }
            await _speaker.Speak(_todayWords[_currentWordIndex].ExampleSentence);
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void BtnExamPortuguese_Click(object sender, EventArgs e)
        {
            List<Word> taregtWords = CalcTargetWords();
            if (taregtWords.Count == 0)
            {
                MessageBox.Show("没有单词!!");
                return;
            }
            FormExam formExam = new FormExam(taregtWords, true, CalcDayType());
            formExam.ShowDialog();
        }

        private Constants.DayType CalcDayType()
        {
            if (RBYesterday.Checked)
            {
                return Constants.DayType.Yesterday;
            }
            else if (RBTomorrow.Checked)
            {
                return Constants.DayType.Tomorrow;
            }
            return Constants.DayType.Today;
        }

        private void BtnPronounciation_Click(object sender, EventArgs e)
        {
            List<Word> taregtWords = CalcTargetWords();
            if (taregtWords.Count == 0)
            {
                MessageBox.Show("没有单词!!");
                return;
            }
            FormPronunciation formPronunciation = new FormPronunciation(taregtWords);
            formPronunciation.ShowDialog();
        }

        private void BtnExamChineseMeaning_Click(object sender, EventArgs e)
        {
            List<Word> taregtWords = CalcTargetWords();
            if (taregtWords.Count == 0 )
            {
                MessageBox.Show("没有单词!!");
                return ;
            }
            FormExam formExam = new FormExam(taregtWords, false, CalcDayType());
            formExam.ShowDialog();
        }

        private List<Word> CalcTargetWords()
        {
            if (RBToday.Checked)
            {
                return _todayWords;
            } else if (RBYesterday.Checked)
            {
                return _allDueWords;
            }
            else if (RBTomorrow.Checked)
            {
                return _tomorrowWords;
            }
            return _allDueWords;
        }

        private void BtnCorrection_Click(object sender, EventArgs e)
        {
            Tools.ShowNumberInputDialog(this, Constants.UNLOCK_PASSWORD, () => {
                // 验证通过后执行的操作
                MessageBox.Show("安全操作已解锁");
                FormCorrection formCorrection = new FormCorrection();
                formCorrection.ShowDialog();
            });
            
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
        }

        private void RefreshTotalPoints()
        {
            int totalPoints = new ScoreRecordRepository().GetAllCorrectRecordsCount();// - new ConsumeLogRepository().GetTotalConsumedScore();
            LblTotalScores.Text = "累计得分：" + totalPoints;
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            RefreshTotalPoints();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                FormConsumeScore formConsumeScore = new FormConsumeScore();
                formConsumeScore.ShowDialog();
        }
        private void CenterPanelOnMaximize()
        {
            PnlMain.SuspendLayout();

            // 计算居中位置
            int newX = (this.ClientSize.Width - PnlMain.Width) / 2;
            int newY = (this.ClientSize.Height - PnlMain.Height) / 2;

            PnlMain.Location = new Point(newX, newY);
            PnlMain.ResumeLayout();
        }

        private void RestorePanelPosition()
        {
            PnlMain.SuspendLayout();

            // 仅恢复位置，保持当前尺寸
            PnlMain.Location = _pnlMainOriginalBounds.Location;

            // 或者如果需要恢复原始尺寸：
            // PnlMain.Size = _pnlMainOriginalBounds.Size;

            PnlMain.ResumeLayout(true); // 强制立即重新布局
            PnlMain.Refresh();          // 强制重绘
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // 最大化时居中
                CenterPanelOnMaximize();
            }
            else
            {
                // 恢复正常大小时还原位置
                RestorePanelPosition();
            }
        }
    }
}
