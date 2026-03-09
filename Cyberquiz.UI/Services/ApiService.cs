using Cyberquiz.Shared.DTOs;


namespace Cyberquiz.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        // GET api/categories
        public async Task<List<CategoryDto>> GetCategoriesAsync()
            => await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories") ?? new();

        // GET api/categories/{categoryId}/subcategories
        public async Task<List<SubCategoryDto>> GetSubCategoriesByCategoryIdAsync(int categoryId)
            => await _http.GetFromJsonAsync<List<SubCategoryDto>>($"api/categories/{categoryId}/subcategories") ?? new();

        // GET api/quiz/subcategory/{subCategoryId}/next
        public async Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId)
        {
            var res = await _http.GetAsync($"api/quiz/subcategory/{subCategoryId}/next");

            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null; // inga fler frågor

            if (!res.IsSuccessStatusCode)
                return null; // eller throw om du vill

            return await res.Content.ReadFromJsonAsync<QuestionDto>();
        }

        // POST api/quiz/answer
        public async Task<SubmitResponseDto?> SubmitAnswerWithFeedbackAsync(SubmitAnswerRequestDto request)
        {
            var response = await _http.PostAsJsonAsync("api/quiz/answer", request);
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<SubmitResponseDto>();
        }

        // GET api/progress/profile
        public async Task<List<UserProgressDto>> GetUserProgressAsync()
            => await _http.GetFromJsonAsync<List<UserProgressDto>>("api/progress/profile") ?? new();
    }
}
