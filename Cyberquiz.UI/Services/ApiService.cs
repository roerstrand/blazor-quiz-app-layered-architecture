using Cyberquiz.Shared.DTOs;
using System.Net;
using System.Net.Http.Headers;

namespace Cyberquiz.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly TokenProvider _tokenProvider;

        public ApiService(HttpClient http, TokenProvider tokenProvider)
        {
            _http = http;
            _tokenProvider = tokenProvider;
        }

        private async Task SetAuthAsync()
        {
            var token = await _tokenProvider.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // GET api/categories
        public async Task<List<CategoryDto>> GetCategoriesAsync()
        { await SetAuthAsync(); return await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories") ?? new(); }

        // GET api/categories/{categoryId}/subcategories
        public async Task<List<SubCategoryDto>> GetSubCategoriesAsync()
        { await SetAuthAsync(); return await _http.GetFromJsonAsync<List<SubCategoryDto>>("api/categories/subcategories") ?? new(); }

        // POST api/progress/session
        public async Task<int> StartSessionAsync(int subCategoryId)
        {
            await SetAuthAsync();
            var res = await _http.PostAsync($"api/progress/session?subCategoryId={subCategoryId}", null);
            if (!res.IsSuccessStatusCode) return 0;
            return await res.Content.ReadFromJsonAsync<int>();
        }

        // GET api/quiz/subcategory/{subCategoryId}/next
        public async Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId, int progressId)
        {
            await SetAuthAsync();
            var res = await _http.GetAsync($"api/quiz/subcategory/{subCategoryId}/next?progressId={progressId}");

            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null; // inga fler frågor

            if (!res.IsSuccessStatusCode)
                return null; // eller throw om du vill

            return await res.Content.ReadFromJsonAsync<QuestionDto>();
        }

        // POST api/quiz/answer
        public async Task<SubmitResponseDto?> SubmitAnswerWithFeedbackAsync(SubmitAnswerRequestDto request)
        {
            try
            {
                await SetAuthAsync();
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
        { await SetAuthAsync(); return await _http.GetFromJsonAsync<List<UserProgressDto>>("api/progress/profile") ?? new(); }
    }
}
