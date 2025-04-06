using System;
using System.Collections.Generic;
using NAudio.Wave;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WordMemorizer.Core.Aduio
{
    public class Recorder
    {
        private WaveInEvent _waveIn;
        private List<byte> _audioBuffer = new List<byte>();
        private string _recordFilePrefix;

        public event Action<Bitmap> _waveformUpdated;
        public event Action<string> _recordingSaved;
        private readonly PictureBox _pbWaveform;

        public Recorder(PictureBox pbWaveform)
        {
            _pbWaveform = pbWaveform;
        }

        public void StartRecording(string checkingContent, string outputFolder)
        {
            _recordFilePrefix = checkingContent;
            _audioBuffer.Clear();

            _waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 16, 1) // 44.1kHz sample rate, 16-bit, mono
            };

            _waveIn.DataAvailable += (s, e) => {
                _audioBuffer.AddRange(e.Buffer);
                UpdateWaveform(e.Buffer, e.BytesRecorded);
            };

            _waveIn.RecordingStopped += (s, e) => {
                SaveRecording(outputFolder);
            };

            _waveIn.StartRecording();
        }

        private void UpdateWaveform(byte[] buffer, int bytesRecorded)
        {
            // 简单的波形绘制
            Bitmap bmp = new Bitmap(_pbWaveform.Width, _pbWaveform.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
                Pen pen = new Pen(Color.Lime);

                for (int x = 0; x < bmp.Width; x++)
                {
                    int bufferIndex = x * bytesRecorded / bmp.Width;
                    float y = buffer[bufferIndex] / 255f * bmp.Height;
                    g.DrawLine(pen, x, bmp.Height / 2, x, bmp.Height / 2 - y);
                }
            }

            _waveformUpdated?.Invoke(bmp);
        }

        private void SaveRecording(string outputFolder)
        {
            string dateFolder = Path.Combine(outputFolder, DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(dateFolder);

            string fileName = $"{_recordFilePrefix}_{DateTime.Now:HHmmss}.wav";
            string fullPath = Path.Combine(dateFolder, fileName);

            // Create proper WAV file using WaveFileWriter
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            using (var waveWriter = new WaveFileWriter(fileStream, _waveIn.WaveFormat))
            {
                waveWriter.Write(_audioBuffer.ToArray(), 0, _audioBuffer.Count);
                waveWriter.Flush();
            }

            _recordingSaved?.Invoke(fullPath);
        }

        public void StopRecording()
        {
            _waveIn?.StopRecording();
        }
    }
}
