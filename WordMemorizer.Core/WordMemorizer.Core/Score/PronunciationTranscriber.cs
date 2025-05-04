using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using Whisper.net.Ggml;
using System.Net.Http.Headers;


namespace WordMemorizer.Core.Score
{

    public class PronunciationTranscriber
    {
        private readonly HttpClient httpClient;
        private readonly string ptTranscribeServiceUrl = "http://127.0.0.1:5000/transcribe_pt";//"http://172.16.0.207:5000/transcribe_pt";
        private readonly string zhTranscribeServiceUrl = "http://127.0.0.1:5000/transcribe_zh";


        public PronunciationTranscriber()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<TranscriptionResponse> TranscribePronunciationPt(string wavFilePath)
        {
            return await TranscribePrononciation(wavFilePath, ptTranscribeServiceUrl);
        }

        public async Task<TranscriptionResponse> TranscribePronunciationZh(string wavFilePath)
        {
            return await TranscribePrononciation(wavFilePath, zhTranscribeServiceUrl);
        }

        private async Task<TranscriptionResponse> TranscribePrononciation(string wavFilePath, string serviceUrl)
        {
            try
            {
                var formData = new MultipartFormDataContent();
                var fileStream = File.OpenRead(wavFilePath);
                formData.Add(new StreamContent(fileStream), "audio_file", "audio.wav");

                var response = await httpClient.PostAsync(serviceUrl, formData);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // 解析 JSON
                var result = JsonConvert.DeserializeObject<TranscriptionResponse>(jsonResponse);

                if (result.Status == "success")
                {
                    Console.WriteLine($"转录结果: {result.Text}");
                }
                else
                {
                    Console.WriteLine($"错误: {result.Message}");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常: {ex.Message}");
            }
            return null;
        }
    }

    public class TranscriptionResponse
    {
        public string Status { get; set; }
        public string Text { get; set; }
        public string Message { get; set; } // 错误信息（可选）
    }
}
