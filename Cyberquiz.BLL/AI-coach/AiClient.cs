using Cyberquiz.BLL.Interfaces;
using System.Net.Http.Json;

namespace Cyberquiz.BLL.AI_coach
{
    public class AiClient : IAiClient
    {
        private readonly HttpClient _http;
        private static readonly TimeSpan Timeout = TimeSpan.FromMinutes(3);

        public AiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetFeedback(string prompt)
        {
            using var cts = new CancellationTokenSource(Timeout);

            var request = new { model = "llama3.1:8b", prompt = prompt, stream = false, num_predict = 200 };

            HttpResponseMessage response;
            try
            {
                response = await _http.PostAsJsonAsync("api/generate", request, cts.Token);
            }
            catch (OperationCanceledException)
            {
                throw new TimeoutException("AI-modellen svarade inte i tid. Försök igen.");
            }

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>(cts.Token);
            return result?.Response ?? string.Empty;
        }

        private class OllamaResponse
        {
            public string Response { get; set; } = string.Empty;
        }
    }
}
