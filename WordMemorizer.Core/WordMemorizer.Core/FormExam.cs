using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMemorizer.Core.Aduio;
using WordMemorizer.Core.Audio;
using WordMemorizer.Core.DB.Models;
using WordMemorizer.Core.DB.Repositories;
using WordMemorizer.Core.Score;

namespace WordMemorizer.Core
{
    public partial class FormExam : Form
    {
        private readonly bool _isExamingPortuguese;
        private readonly Recorder _recorder;
        private readonly PronunciationTranscriber _transcriber;
        private readonly List<WordWrapper> _wordWrapperList = new List<WordWrapper>();
        private readonly PortugueseTTS _speaker;
        private readonly ConfigIniHelper _configIniHelper = new ConfigIniHelper();
        private readonly SimpleAudioPlayer _simpleAudioPlayer = new SimpleAudioPlayer();
        private int _currentIndex = 0;
        private bool _isTested;
        private readonly bool _isExamMode;
        private readonly ScoreRecordRepository _scoreRecordRepository = new ScoreRecordRepository();
        private string _batchNumber = "00000000000000";

        public FormExam(List<Word> todayWordList, bool isExamingPortuguese, bool isExamMode)
        {
            _isExamingPortuguese = isExamingPortuguese;
            foreach(var word in todayWordList)
            {
                var wrapper = new WordWrapper();
                wrapper.Word = word;
                _wordWrapperList.Add(wrapper);
            }
            InitializeComponent();
            string audioFolder = _configIniHelper.GetValue("AudioFolder", Constants.DEFAULT_AUDIO_PATH);
            // 初始化语音合成器
            _speaker = new PortugueseTTS(audioFolder);
            _recorder = new Recorder(pbWaveform);
            _transcriber = new PronunciationTranscriber();
            SetupEventHandlers();
            _isExamMode = isExamMode;
        }

        private void FormExam_Load(object sender, EventArgs e)
        {
            if ( _wordWrapperList.Count > 0)
            {
                SetCurrentWord(_wordWrapperList[0].Word);
            }
            RefreshPoints();
            _batchNumber = Tools.GenerateBatchNumber();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (BtnNext.Text == Constants.BTN_TEXT_RESTART)
            {
                PrepareForRestart();
            }
            else
            {
                if (_isTested == false)
                {
                    MessageBox.Show("请点开始按钮开始测验当前单词");
                    return;
                }
                if (_currentIndex < _wordWrapperList.Count - 1)
                {
                    _currentIndex++;
                }
            }
            
            SetCurrentWord(_wordWrapperList[_currentIndex].Word);
            btnStartRecording.Enabled = true;
            BtnRead.Visible = false;
            PbResult.Load(Constants.LISTENING_IMAGE_PATH);
            _isTested = false;
        }

        private void PrepareForRestart()
        {
            BtnNext.Text = Constants.BTN_TEXT_CONTINUE;
            _currentIndex = 0;
            _isTested = false;
            foreach (var wrapper in _wordWrapperList)
            {
                wrapper.Word.LatestScore = 0;
            }
            RefreshPoints();
            _batchNumber = Tools.GenerateBatchNumber();
        }

        public void SetCurrentWord(Word word)
        {
            TbText.Text = _isExamingPortuguese ? "***" : word.Text;
            TbChinese.Text = _isExamingPortuguese ? word.ChineseMeaning : "***";
            LblIndex.Text = $"{_currentIndex + 1}/{_wordWrapperList.Count}";
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
            }
            SetCurrentWord(_wordWrapperList[_currentIndex].Word);
        }

        private Word GetCurrentWord()
        {
            return _wordWrapperList[_currentIndex].Word;
        }

        private void SetupEventHandlers()
        {
            _recorder._waveformUpdated += bmp => {
                pbWaveform.Image = bmp;
            };

            _recorder._recordingSaved += async filePath => {
                await HandleAnswer(filePath);               
            };
        }

        /// <summary>
        /// 录音结束后的处理函数
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private async Task HandleAnswer(string filePath)
        {
            _wordWrapperList[_currentIndex].RecordingFilePath = filePath;
            if (_isExamingPortuguese)
            {
                var result = await _transcriber.TranscribePronunciationPt(filePath);
                if (Tools.AreSimilarWords(result.Text, GetCurrentWord().Text, true))
                {
                    PbResult.Load(Constants.CORRECT_IMAGE_PATH);
                    _simpleAudioPlayer.Play(Constants.CORRECT_AUDIO_PATH);
                    _wordWrapperList[_currentIndex].IsCorrect = true;
                }
                else
                {
                    PbResult.Load(Constants.INCORRECT_IMAGE_PATH);
                    _simpleAudioPlayer.Play(Constants.INCORRECT_AUDIO_PATH);
                    _wordWrapperList[_currentIndex].IsCorrect = false;
                }
                TbText.Text = _wordWrapperList[_currentIndex].Word.Text;
            }
            else
            {
                var result = await _transcriber.TranscribePronunciationZh(filePath);
                if (Tools.AreSimilarWords(result.Text, GetCurrentWord().ChineseMeaning, false))
                {
                    PbResult.Load(Constants.CORRECT_IMAGE_PATH);
                    _simpleAudioPlayer.Play(Constants.CORRECT_AUDIO_PATH);
                    _wordWrapperList[_currentIndex].IsCorrect = true;
                }
                else
                {
                    PbResult.Load(Constants.INCORRECT_IMAGE_PATH);
                    _simpleAudioPlayer.Play(Constants.INCORRECT_AUDIO_PATH);
                    _wordWrapperList[_currentIndex].IsCorrect = false;
                }
                TbChinese.Text = _wordWrapperList[_currentIndex].Word.ChineseMeaning;
            }
            btnStartRecording.Enabled = false;
            BtnRead.Visible = true;
            _isTested = true;
            if (_currentIndex == _wordWrapperList.Count - 1)
            {
                BtnNext.Text = Constants.BTN_TEXT_RESTART;
            }
            if (_isExamMode)
            {
                ScoreRecord scoreRecord = new ScoreRecord();
                scoreRecord.Word = GetCurrentWord();
                scoreRecord.BatchNumber = _batchNumber;
                scoreRecord.WordId = GetCurrentWord().Id;
                scoreRecord.AudioPath = filePath;
                scoreRecord.IsCorrect = _wordWrapperList[_currentIndex].IsCorrect;
                scoreRecord.RecordTime = DateTime.Now;
                _scoreRecordRepository.AddScoreRecord(scoreRecord);
                RefreshPoints();
            }
        }

        private void RefreshPoints()
        {
            LblTotalScores.Text = "累计得分：" + _scoreRecordRepository.GetAllCorrectRecordsCount();

            if (_isExamMode)
            {

                LblThisRoundScores.Text = "本轮得分：" + CalcThisRoundScores();
            }
            else
            {
                LblThisRoundScores.Text = "本轮复习中..";

            }
        }

        private int CalcThisRoundScores()
        {
            int result = 0;
            foreach (var wrapper in _wordWrapperList)
            {
                if (wrapper.IsCorrect)
                {
                    result++;
                }
            }

            return result;
        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            string outputFolder = Path.Combine(Application.StartupPath, Constants.RECORDING_PATH);
            PbResult.Load(Constants.LISTENING_IMAGE_PATH);

            if (_isExamingPortuguese)
            {
                _recorder.StartRecording(GetCurrentWord().Text, outputFolder);
            }
            else
            {
                _recorder.StartRecording(GetCurrentWord().ChineseMeaning, outputFolder);
            }

            btnStartRecording.Enabled = false;
            btnStopRecording.Enabled = true;
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            _recorder.StopRecording();
            PbResult.Load(Constants.PROCESSING_IMAGE_PATH);

            btnStartRecording.Enabled = true;
            btnStopRecording.Enabled = false;
        }

        private async void BtnRead_Click(object sender, EventArgs e)
        {
            await _speaker.Speak(GetCurrentWord().Text);
        }

        private void BtnListenSelf_Click(object sender, EventArgs e)
        {
            if (_wordWrapperList[_currentIndex].RecordingFilePath != "")
            {
                _simpleAudioPlayer.Play(_wordWrapperList[_currentIndex].RecordingFilePath);
            }
        }

        private class WordWrapper
        {
            public Word Word { get; set; }
            public string RecordingFilePath { get; set; } = "";
            public bool IsCorrect { get; set; } = false;
        }
    }
}
