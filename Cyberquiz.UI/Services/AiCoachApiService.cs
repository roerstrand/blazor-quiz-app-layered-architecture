using Cyberquiz.Shared.DTOs.AI_DTOs;
using System.Net.Http.Headers;

namespace Cyberquiz.UI.Services
{
    public class AiCoachApiService
    {
        private readonly HttpClient _http;
        private readonly TokenProvider _tokenProvider;

        public AiCoachApiService(HttpClient http, TokenProvider tokenProvider)
        {
            _http = http;
            _tokenProvider = tokenProvider;
        }

        public async Task<AiFeedbackDto> GetFeedback()
        {
            var token = await _tokenProvider.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _http.GetFromJsonAsync<AiFeedbackDto>("api/aicoach");
        }

    }
}
