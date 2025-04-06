using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core.Audio
{
    internal class Speaker
    {
        private readonly HttpClient client;
        public Speaker()
        {
            client = new HttpClient();
        }

        public async Task Speak(string text)
        {
            string url = $"https://translate.google.com/translate_tts?ie=UTF-8&tl=pt-PT&client=tw-ob&q={Uri.EscapeDataString(text)}";
            var audioData = await client.GetByteArrayAsync(url);
            using (var stream = new MemoryStream(audioData))
            {
                using (var mp3Reader = new Mp3FileReader(stream))
                {

                    using (var waveOut = new WaveOutEvent())
                    {
                        waveOut.Init(mp3Reader);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            await Task.Delay(100);
                        }
                    }
                }
            }
        }
    }
}
