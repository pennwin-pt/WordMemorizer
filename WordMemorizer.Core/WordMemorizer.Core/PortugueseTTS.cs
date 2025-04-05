using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using NAudio.Wave;


namespace WordMemorizer.Core
{

    public class PortugueseTTS
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _audioFolder = "../../audio"; // 音频保存目录

        public PortugueseTTS()
        {
            // 确保 audio 文件夹存在
            Directory.CreateDirectory(_audioFolder);
        }

        public async Task Speak(string word, bool isWords=true)
        {
            try
            {
                // 1. 检查本地是否已有该单词的音频文件
                string safeFileName = GetSafeFileName(word) + ".mp3";
                string filePath;
                if (isWords)
                {
                    filePath = Path.Combine(_audioFolder, Constants.AUDIO_PATH_WORDS, safeFileName);
                }
                else
                {
                    filePath = Path.Combine(_audioFolder, Constants.AUDIO_PATH_SENTENCES, safeFileName);
                }

                if (File.Exists(filePath))
                {
                    // 直接播放本地文件
                    Console.WriteLine($"使用本地音频: {filePath}");
                    await PlayAudioFileAsync(filePath);
                    return;
                }

                // 2. 如果没有本地文件，则调用Google TTS
                Console.WriteLine($"生成新音频: {word}");
                string url = $"https://translate.google.com/translate_tts?ie=UTF-8&tl=pt-PT&client=tw-ob&q={Uri.EscapeDataString(word)}";

                // 3. 获取音频数据
                byte[] audioData = await _httpClient.GetByteArrayAsync(url);

                // 4. 保存为MP3文件
                File.WriteAllBytes(filePath, audioData);

                // 5. 播放音频
                await PlayAudioAsync(audioData);

                Console.WriteLine($"已保存: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"错误: {ex.Message}");
            }
        }

        private async Task PlayAudioFileAsync(string filePath)
        {
            using (var mp3Reader = new Mp3FileReader(filePath))
            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(mp3Reader);
                waveOut.Play();

                // 等待播放完成
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    await Task.Delay(100);
                }
            }
        }

        private async Task PlayAudioAsync(byte[] audioData)
        {
            using (var stream = new MemoryStream(audioData))
            using (var mp3Reader = new Mp3FileReader(stream))
            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(mp3Reader);
                waveOut.Play();

                // 等待播放完成
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    await Task.Delay(100);
                }
            }
        }

        private string GetSafeFileName(string input)
        {
            // 替换非法文件名字符
            var invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                input = input.Replace(c, '_');
            }
            return input;
        }
    }


}
