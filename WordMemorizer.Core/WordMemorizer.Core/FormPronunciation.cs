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
using Whisper.net;
using WordMemorizer.Core.Aduio;
using WordMemorizer.Core.Audio;
using WordMemorizer.Core.DB.Models;
using WordMemorizer.Core.Score;

namespace WordMemorizer.Core
{
    public partial class FormPronunciation : Form
    {
        private readonly Recorder _recorder;
        private readonly PronunciationTranscriber _transcriber;
        private readonly List<Word> _wordList = new List<Word>();
        private Word _currentWord;
        private readonly PortugueseTTS _speaker;
        private readonly ConfigIniHelper _configIniHelper = new ConfigIniHelper();
        private readonly SimpleAudioPlayer _simpleAudioPlayer = new SimpleAudioPlayer();
        private int _currentIndex = 0;

        public FormPronunciation(List<DB.Models.Word> todayWordList)
        {
            InitializeComponent();
            string audioFolder = _configIniHelper.GetValue("AudioFolder", Constants.DEFAULT_AUDIO_PATH);
            // 初始化语音合成器
            _speaker = new PortugueseTTS(audioFolder);
            _recorder = new Recorder(pbWaveform);
            _transcriber = new PronunciationTranscriber();
            SetupEventHandlers();
            _wordList.AddRange(todayWordList);
        }

        private void FormPronunciation_Load(object sender, EventArgs e)
        {
            SetCurrentWord();
        }

        private void SetupEventHandlers()
        {
            _recorder._waveformUpdated += bmp => {
                pbWaveform.Image = bmp;
            };

            _recorder._recordingSaved += async filePath => {
                var result = await _transcriber.TranscribePronunciationPt(filePath);
                if (Tools.AreSimilarWords(result.Text , _currentWord.Text, true))
                {
                    // LblResult.Text = "Correct!";
                    PbResult.Load(Constants.CORRECT_IMAGE_PATH);
                    _simpleAudioPlayer.Play(Constants.CORRECT_AUDIO_PATH);
                }
                else
                {
                   // LblResult.Text = "Incorrect!";
                   PbResult.Load(Constants.INCORRECT_IMAGE_PATH);
                    _simpleAudioPlayer.Play(Constants.INCORRECT_AUDIO_PATH);
                }
            };
        }

        public void SetCurrentWord()
        {
            Word word = _wordList[_currentIndex];
            _currentWord = word;
            TbText.Text =  CBHideText.Checked ? "***" : word.Text;
            TbChinese.Text = CBHideChinese.Checked ? "***" : word.ChineseMeaning;
            LblIndex.Text = $"{_currentIndex + 1}/{_wordList.Count}";
        }

        private void BtnStartRecording_Click(object sender, EventArgs e)
        {
            string outputFolder = Path.Combine(Application.StartupPath, Constants.RECORDING_PATH);
            PbResult.Load(Constants.LISTENING_IMAGE_PATH);

            _recorder.StartRecording(_currentWord.Text, outputFolder);

            btnStartRecording.Enabled = false;
            btnStopRecording.Enabled = true;
        }

        private void BtnStopRecording_Click(object sender, EventArgs e)
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

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentIndex < _wordList.Count - 1)
            {
                _currentIndex++;
            }
            else
            {
                _currentIndex = 0; // 如果到达最后一个单词，则返回第一个单词
            }
            SetCurrentWord();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
            }
            else
            {
                _currentIndex = _wordList.Count - 1; // 如果到达第一个单词，则返回最后一个单词
            }
            SetCurrentWord();

        }

        private void CBHideText_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentWord();
        }

        private void CBHideChinese_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentWord();
        }
    }
}
