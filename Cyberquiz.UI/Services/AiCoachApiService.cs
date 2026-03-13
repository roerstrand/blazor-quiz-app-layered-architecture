using Cyberquiz.Shared.DTOs.AI_DTOs;
using System.Net.Http.Headers;

namespace Cyberquiz.UI.Services
{
    public class AiCoachApiService
    {
        private readonly HttpClient _http;
        private readonly JwtTokenStore _tokenStore;

        public AiCoachApiService(HttpClient http, JwtTokenStore tokenStore)
        {
            _http = http;
            _tokenStore = tokenStore;
        }

        public async Task<AiFeedbackDto> GetFeedback()
        {
            if (!string.IsNullOrEmpty(_tokenStore.Token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenStore.Token);
            return await _http.GetFromJsonAsync<AiFeedbackDto>("api/aicoach");
        }
    }
}
