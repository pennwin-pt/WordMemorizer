using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core.Aduio
{
    internal class SimpleAudioPlayer
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public void Play(string filePath)
        {
            Stop(); // 先停止当前播放

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(filePath);
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }

        public void Stop()
        {
            outputDevice?.Stop();
            audioFile?.Dispose();
            outputDevice?.Dispose();
        }
    }
}
