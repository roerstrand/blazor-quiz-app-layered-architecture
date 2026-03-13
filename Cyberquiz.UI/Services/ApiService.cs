using Cyberquiz.Shared.DTOs;
using System.Net.Http.Headers;

namespace Cyberquiz.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly JwtTokenStore _tokenStore;

        public ApiService(HttpClient http, JwtTokenStore tokenStore)
        {
            _http = http;
            _tokenStore = tokenStore;
        }

        private void SetAuth()
        {
            if (!string.IsNullOrEmpty(_tokenStore.Token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenStore.Token);
        }

        // GET api/categories
        public async Task<List<CategoryDto>> GetCategoriesAsync()
        { SetAuth(); return await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories") ?? new(); }

        // GET api/categories/subcategories
        public async Task<List<SubCategoryDto>> GetSubCategoriesAsync()
        { SetAuth(); return await _http.GetFromJsonAsync<List<SubCategoryDto>>("api/categories/subcategories") ?? new(); }

        // POST api/progress/session
        public async Task<int> StartSessionAsync(int subCategoryId)
        {
            SetAuth();
            var res = await _http.PostAsync($"api/progress/session?subCategoryId={subCategoryId}", null);
            if (!res.IsSuccessStatusCode) return 0;
            return await res.Content.ReadFromJsonAsync<int>();
        }

        // GET api/quiz/subcategory/{subCategoryId}/next
        public async Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId, int progressId)
        {
            SetAuth();
            var res = await _http.GetAsync($"api/quiz/subcategory/{subCategoryId}/next?progressId={progressId}");

            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            if (!res.IsSuccessStatusCode)
                return null;

            return await res.Content.ReadFromJsonAsync<QuestionDto>();
        }

        // POST api/quiz/answer
        public async Task<SubmitResponseDto?> SubmitAnswerWithFeedbackAsync(SubmitAnswerRequestDto request)
        {
            try
            {
                SetAuth();
                Console.WriteLine($"🔵 Submitting answer: QuestionId={request.QuestionId}, AnswerOptionId={request.AnswerOptionId}");

                var response = await _http.PostAsJsonAsync("api/quiz/answer", request);

                Console.WriteLine($"🔵 Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"🔴 API Error: {response.StatusCode} - {errorContent}");
                    return null;
                }

                var result = await response.Content.ReadFromJsonAsync<SubmitResponseDto>();
                Console.WriteLine($"🟢 Success! IsCorrect={result?.IsCorrect}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔴 Exception: {ex.Message}");
                return null;
            }
        }

        // GET api/progress/profile
        public async Task<List<UserProgressDto>> GetUserProgressAsync()
        { SetAuth(); return await _http.GetFromJsonAsync<List<UserProgressDto>>("api/progress/profile") ?? new(); }

        // DELETE api/progress/all — raderar all progression (GDPR)
        public async Task<bool> DeleteAllProgressAsync()
        {
            SetAuth();
            var res = await _http.DeleteAsync("api/progress/all");
            return res.IsSuccessStatusCode;
        }

        // DELETE api/progress/keep/{keepLatest} — behåller N senaste sessioner
        public async Task<bool> KeepRecentProgressAsync(int keepLatest)
        {
            SetAuth();
            var res = await _http.DeleteAsync($"api/progress/keep/{keepLatest}");
            return res.IsSuccessStatusCode;
        }
    }
}
