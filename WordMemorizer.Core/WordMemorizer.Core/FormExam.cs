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
using WordMemorizer.Core.Score;

namespace WordMemorizer.Core
{
    public partial class FormExam : Form
    {
        private readonly bool _isExamingPortuguese;
        private readonly Recorder _recorder;
        private readonly PronunciationTranscriber _transcriber;
        private readonly List<Word> _wordList = new List<Word>();
        private Word _currentWord;
        private readonly PortugueseTTS _speaker;
        private readonly ConfigIniHelper _configIniHelper = new ConfigIniHelper();
        private readonly SimpleAudioPlayer _simpleAudioPlayer = new SimpleAudioPlayer();
        private int _currentIndex = 0;
        private bool _isTested;

        public FormExam(List<DB.Models.Word> todayWordList, bool isExamingPortuguese)
        {
            _isExamingPortuguese = isExamingPortuguese;
            _wordList.AddRange(todayWordList);
            InitializeComponent();
            string audioFolder = _configIniHelper.GetValue("AudioFolder", Constants.DEFAULT_AUDIO_PATH);
            // 初始化语音合成器
            _speaker = new PortugueseTTS(audioFolder);
            _recorder = new Recorder(pbWaveform);
            _transcriber = new PronunciationTranscriber();
            SetupEventHandlers();
        }

        private void FormExam_Load(object sender, EventArgs e)
        {
            if ( _wordList.Count > 0)
            {
                _currentWord = _wordList[0];
                SetCurrentWord(_currentWord);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_isTested == false)
            {
                MessageBox.Show("请点开始按钮开始测验当前单词");
                return;
            }
            if (_currentIndex < _wordList.Count - 1)
            {
                _currentIndex++;
            }
            SetCurrentWord(_wordList[_currentIndex]);
            btnStartRecording.Enabled = true;
            BtnRead.Visible = false;
            PbResult.Load(Constants.LISTENING_IMAGE_PATH);
            _isTested = false;
        }

        public void SetCurrentWord(Word word)
        {
            _currentWord = word;
            TbText.Text = _isExamingPortuguese ? "***" : word.Text;
            TbChinese.Text = _isExamingPortuguese ? word.ChineseMeaning : "***";
            LblIndex.Text = $"{_currentIndex + 1}/{_wordList.Count}";
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
            }
            SetCurrentWord(_wordList[_currentIndex]);
        }

        private void SetupEventHandlers()
        {
            _recorder._waveformUpdated += bmp => {
                pbWaveform.Image = bmp;
            };

            _recorder._recordingSaved += async filePath => {
                bool IsCorrect = false;
                if (_isExamingPortuguese)
                {
                    var result = await _transcriber.TranscribePronunciationPt(filePath);
                    if (Tools.AreSimilarWords(result.Text, _currentWord.Text, true))
                    {
                        PbResult.Load(Constants.CORRECT_IMAGE_PATH);
                        _simpleAudioPlayer.Play(Constants.CORRECT_AUDIO_PATH);
                        IsCorrect = true;
                    }
                    else
                    {
                        PbResult.Load(Constants.INCORRECT_IMAGE_PATH);
                        _simpleAudioPlayer.Play(Constants.INCORRECT_AUDIO_PATH);
                    }
                }
                else
                {
                    var result = await _transcriber.TranscribePronunciationZh(filePath);
                    if (Tools.AreSimilarWords(result.Text, _currentWord.ChineseMeaning, false))
                    {
                        PbResult.Load(Constants.CORRECT_IMAGE_PATH);
                        _simpleAudioPlayer.Play(Constants.CORRECT_AUDIO_PATH);
                        IsCorrect = true;
                    }
                    else
                    {
                        PbResult.Load(Constants.INCORRECT_IMAGE_PATH);
                        _simpleAudioPlayer.Play(Constants.INCORRECT_AUDIO_PATH);
                    }
                }
                if (IsCorrect)
                {
                    _currentWord.LatestScore = Constants.SCORES_PER_WORD;
                }
                else
                {
                    _currentWord.LatestScore = 0;
                }
                RefreshPoints();
                btnStartRecording.Enabled = false;
                BtnRead.Visible = true;
                _isTested = true;
            };
        }

        private void RefreshPoints()
        {
            int result = 0;
            foreach (var word in _wordList)
            {
                result += word.LatestScore;
            }
            LblTotalScores.Text = "总得分：" + result.ToString();
            if (_isExamingPortuguese)
            { 
                TbText.Text = _currentWord.Text;
            }
            else
            {
                TbChinese.Text = _currentWord.ChineseMeaning;
            }
        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            string outputFolder = Path.Combine(Application.StartupPath, Constants.RECORDING_PATH);
            PbResult.Load(Constants.LISTENING_IMAGE_PATH);

            if (_isExamingPortuguese)
            {
                _recorder.StartRecording(_currentWord.Text, outputFolder);
            }
            else
            {
                _recorder.StartRecording(_currentWord.ChineseMeaning, outputFolder);
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
            await _speaker.Speak(_currentWord.Text);
        }
    }
}
