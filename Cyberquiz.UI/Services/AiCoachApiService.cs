using Cyberquiz.Shared.DTOs.AI_DTOs;

namespace Cyberquiz.UI.Services
{
    public class AiCoachApiService
    {
        private readonly HttpClient _http;

        public AiCoachApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AiFeedbackDto> GetFeedback(string? userName)
        {
            return await _http.GetFromJsonAsync<AiFeedbackDto>($"api/aicoach?userName={userName}");
        }

    }
}
