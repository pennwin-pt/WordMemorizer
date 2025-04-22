using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemorizer.Core.Aduio;
using WordMemorizer.Core.Audio;
using WordMemorizer.Core.DB.Models;
using WordMemorizer.Core.DB.Repositories;

namespace WordMemorizer.Core
{
    public partial class FormCorrection : Form
    {
        private List<string> _batchNumbersOfTheWeek = new List<string>();
        private List<ScoreRecord> _currentRecords = new List<ScoreRecord>();
        private readonly ScoreRecordRepository _scoreRecordRepository;
        private readonly ConsumeLogRepository _consumeLogRepository = new ConsumeLogRepository();
        private int _currentIndex = 0;
        private readonly PortugueseTTS _answerSpeaker;

        private readonly SimpleAudioPlayer _recordingPlayer;
        private readonly ConfigIniHelper _configIniHelper = new ConfigIniHelper();


        public FormCorrection()
        {
            InitializeComponent();
            _scoreRecordRepository = new ScoreRecordRepository();
            string audioFolder = _configIniHelper.GetValue("AudioFolder", Constants.DEFAULT_AUDIO_PATH);

            _answerSpeaker = new PortugueseTTS(audioFolder);
            _recordingPlayer = new SimpleAudioPlayer();
        }

        private void FormCorrection_Load(object sender, EventArgs e)
        {
            InitData();
            InitView();
        }

        private void InitData()
        {
            _currentIndex = 0;
            _batchNumbersOfTheWeek.AddRange(_scoreRecordRepository.GetBatchNumbersForCurrentWeek());
        }

        private void RefreshControls()
        {

            if (_batchNumbersOfTheWeek.Count > 0)
            {
                
                _currentRecords.Clear();
                _currentRecords.AddRange(_scoreRecordRepository.GetRecordsByBatchNumber(_batchNumbersOfTheWeek[_currentIndex]));
                for (int i = 1; i <= 6; i++)
                {
                    // 设置TBText系列
                    if (Controls.Find($"TBText{i}", true).FirstOrDefault() is TextBox tbText)
                    {
                        if (i - 1 < _currentRecords.Count)
                        {
                            tbText.Text = _currentRecords[i - 1].Word.Text;
                        }
                        else
                        {
                            tbText.Text = "-";
                        }
                    }

                    // 设置TBChinese系列                
                    if (Controls.Find($"TBChinese{i}", true).FirstOrDefault() is TextBox tbChinese)
                    {
                        if (i - 1 < _currentRecords.Count)
                        {
                            tbChinese.Text = _currentRecords[i - 1].Word.ChineseMeaning;
                        }
                        else
                        {
                            tbChinese.Text = "-";
                        }
                    }

                    // 设置checkbox
                    if (Controls.Find($"checkBox{i}", true).FirstOrDefault() is CheckBox chkIsCorrect)
                    {
                        if (i - 1 < _currentRecords.Count)
                        {
                            chkIsCorrect.Enabled = true;
                            chkIsCorrect.Checked = _currentRecords[i - 1].IsCorrect;
                        }
                        else
                        {
                            chkIsCorrect.Enabled = false;
                            chkIsCorrect.Checked = false;
                        }
                    }

                    // 设置读答案按钮
                    if (Controls.Find($"BtnAnswer{i}", true).FirstOrDefault() is Button btnAnswer)
                    {
                        if (i - 1 < _currentRecords.Count)
                        {
                            if (_currentRecords[i - 1].IsPortuguese)
                            {
                                btnAnswer.Enabled = true;
                            }
                            else
                            {
                                btnAnswer.Enabled = false;
                            }
                        }
                        else
                        {
                            btnAnswer.Enabled = false;
                        }
                    }
                }
                string language = _currentRecords[0].IsPortuguese ? "葡语" : "中文";
                LblRecordInfo.Text = Tools.ConvertUtcStringToDateTime(_batchNumbersOfTheWeek[_currentIndex]).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") +
                    " 做的" + language + "测试";
            }
        }

        private void InitView()
        {
            int totalScore = _scoreRecordRepository.GetAllCorrectRecordsCount();// - _consumeLogRepository.GetTotalConsumedScore();
            LblTotalScores.Text = "累计得分：" + totalScore;

            MakeAllTextboxesReadOnly();
            RefreshControls();
            RefreshIndexLabel();
        }

        private void MakeAllTextboxesReadOnly()
        {
            // 设置所有TBText1-TBText6和TBChinese1-TBChinese6为只读
            for (int i = 1; i <= 6; i++)
            {
                // 设置TBText系列
                if (Controls.Find($"TBText{i}", true).FirstOrDefault() is TextBox tbText)
                {
                    tbText.ReadOnly = true;
                }

                // 设置TBChinese系列
                if (Controls.Find($"TBChinese{i}", true).FirstOrDefault() is TextBox tbChinese)
                {
                    tbChinese.ReadOnly = true;
                }
            }
        }

        void RefreshIndexLabel()
        {
            if (_batchNumbersOfTheWeek.Count > 0)
            {
                LblIndex.Text = $"{_currentIndex + 1}/{_batchNumbersOfTheWeek.Count}";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CorrectItem(2 - 1, (sender as CheckBox).Checked);

        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
            }
            RefreshControls();
            RefreshIndexLabel();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentIndex < _batchNumbersOfTheWeek.Count - 1)
            {
                _currentIndex++;
            }

            RefreshControls();
            RefreshIndexLabel();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CorrectItem(1-1, (sender as CheckBox).Checked);
        }

        private void CorrectItem(int idx, bool isCorrect)
        {
            if (idx >= _currentRecords.Count)
            {
                return;
            }
            if (isCorrect)
            {
                _scoreRecordRepository.SetRecordCorrect(_currentRecords[idx].Id, "被人工纠正"+DateTime.Now.ToString());
            }
            else
            {
                _scoreRecordRepository.SetRecordInCorrect(_currentRecords[idx].Id, "取消人工纠正"+DateTime.Now.ToString());
            }
            LblTotalScores.Text = "累计得分：" + _scoreRecordRepository.GetAllCorrectRecordsCount();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CorrectItem(3 - 1, (sender as CheckBox).Checked);

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CorrectItem(4 - 1, (sender as CheckBox).Checked);

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CorrectItem(5 - 1, (sender as CheckBox).Checked);

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CorrectItem(6 - 1, (sender as CheckBox).Checked);

        }

        private async void BtnAnswer1_Click(object sender, EventArgs e)
        {
            await ReadAnswer(1 - 1);
        }

        private async Task ReadAnswer(int idx)
        {
            if (idx >= _currentRecords.Count)
            {
                return;
            }
            await _answerSpeaker.Speak(_currentRecords[idx].Word.Text);
        }

        private async void BtnAnswer2_Click(object sender, EventArgs e)
        {
            await ReadAnswer(2 - 1);
        }

        private async void BtnAnswer3_Click(object sender, EventArgs e)
        {
            await ReadAnswer(3 - 1);
        }

        private async void BtnAnswer4_Click(object sender, EventArgs e)
        {
            await ReadAnswer(4 - 1);
        }

        private async void BtnAnswer5_Click(object sender, EventArgs e)
        {
            await ReadAnswer(5 - 1);
        }

        private async void BtnAnswer6_Click(object sender, EventArgs e)
        {
            await ReadAnswer(6 - 1);
        }

        private void BtnRecording1_Click(object sender, EventArgs e)
        {
            ReadRecording(1 - 1);
        }

        private void ReadRecording(int idx)
        {
            if (idx >= _currentRecords.Count)
            {
                return;
            }
            _recordingPlayer.Play(_currentRecords[idx].AudioPath);
        }

        private void BtnRecording2_Click(object sender, EventArgs e)
        {
            ReadRecording(2 - 1);
        }

        private void BtnRecording3_Click(object sender, EventArgs e)
        {
            ReadRecording(3 - 1);
        }

        private void BtnRecording4_Click(object sender, EventArgs e)
        {
            ReadRecording(4 - 1);
        }

        private void BtnRecording5_Click(object sender, EventArgs e)
        {
            ReadRecording(5 - 1);
        }

        private void BtnRecording6_Click(object sender, EventArgs e)
        {
            ReadRecording(6 - 1);
        }

        private void LblRecordInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
