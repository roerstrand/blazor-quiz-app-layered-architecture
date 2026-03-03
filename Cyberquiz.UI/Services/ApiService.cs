using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;

namespace Cyberquiz.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> GetCategoryOverviewAsync()
        => await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories/overview") ?? new();

        public async Task<List<SubCategoryDto>> GetSubCategoriesByCategoryIdAsync(int categoryId)
        => await _http.GetFromJsonAsync<List<SubCategoryDto>>($"api/categories/{categoryId}/subcategories") ?? new();

        public async Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId)
        => await _http.GetFromJsonAsync<QuestionDto>($"api/quiz/subcategory/{subCategoryId}/next");

        public async Task<SubmitResponseDto?> SubmitAnswerWithFeedbackAsync(SubmitAnswerRequestDto request)
        {
            var res = await _http.PostAsJsonAsync("api/quiz/answer", request);
            if (!res.IsSuccessStatusCode) return null;
            return await res.Content.ReadFromJsonAsync<SubmitResponseDto>();
        }

        public async Task<List<UserProgressDto>> GetUserProgressAsync()
        => await _http.GetFromJsonAsync<List<UserProgressDto>>("api/progress/profile") ?? new();

        //public async Task<List<CategoryDto>> GetCategoryOverviewAsync()
        //=> await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/categories/overview") ?? new();
        //public async Task<List<CategoryDto>?> GetCategoriesAsync()
        //    => await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/categories");

        //public async Task<List<SubCategoryDto>> GetSubCategoiesByCategoryIdAsync(int categoryId)
        //    => await _httpClient.GetFromJsonAsync<List<SubCategoryDto>>($"api/categories/{categoryId}/subcategories") ?? new();

        //public async Task<List<QuestionDto>> GetQuestionsAsync(int subCategoryId)
        //     => await _httpClient.GetFromJsonAsync<List<QuestionDto>>($"api/quiz/{subCategoryId}") ?? new();

        //public async Task<QuestionDto?> GetNextQuestionAsync(int subCategoryId)
        //    => await _httpClient.GetFromJsonAsync<QuestionDto>($"api/quiz/subcategory/{subCategoryId}/next");

        //public async Task<SubmitResponseDto?> SubmitAnswerWithFeedbackAsync(SubmitAnswerRequestDto request)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/quiz/answer", request);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return null;
        //    }

        //    return await response.Content.ReadFromJsonAsync<SubmitResponseDto>();
        //}
        //public async Task<SubmitResponseDto?> SubmitAnswerAsync(SubmitAnswerRequestDto request)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/quiz/answer", request);
        //    if (!response.IsSuccessStatusCode) return null;

        //    return await response.Content.ReadFromJsonAsync<SubmitResponseDto>();
        //}
        //public async Task<bool> SubmitAnswerAsync(UserAnswerDto answer)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/answers", answer);
        //    return response.IsSuccessStatusCode;
        //}

        //public async Task<List<UserProgressDto>> GetUserProgressAsync()
        //    => await _httpClient.GetFromJsonAsync<List<UserProgressDto>>("api/progress/profile") ?? new();



        //public async Task<List<CategoryDto>?> GetCategoriesAsync()
        //{
        //    return await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/categories");
        //}

        //public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<CategoryDto>($"api/categories/{id}");
        //}

        //// === SubCategories ===
        //public async Task<List<SubCategoryDto>?> GetSubCategoriesByCategoryIdAsync(int categoryId)
        //{
        //    return await _httpClient.GetFromJsonAsync<List<SubCategoryDto>>($"api/categories/{categoryId}/subcategories");
        //}

        //public async Task<SubCategoryDto?> GetSubCategoryByIdAsync(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<SubCategoryDto>($"api/subcategories/{id}");
        //}

        //public async Task<List<QuestionDto>?> GetQuestionsBySubCategoryIdAsync(int subCategoryId)
        //{
        //    return await _httpClient.GetFromJsonAsync<List<QuestionDto>>($"api/quiz/subcategory/{subCategoryId}");
        //}

        ////public async Task<QuizResultDto?> SubmitQuizAnswerAsync(int questionId, int answerId)
        ////{
        ////    var response = await _httpClient.PostAsJsonAsync($"api/quiz/submit", new { QuestionId = questionId, AnswerId = answerId });
        ////    return await response.Content.ReadFromJsonAsync<QuizResultDto>();
        ////}

        //// === Progress ===
        //public async Task<bool> IsSubCategoryUnlockedAsync(int subCategoryId)
        //{
        //    return await _httpClient.GetFromJsonAsync<bool>($"api/progress/unlocked/{subCategoryId}");
        //}

        ////public async Task<ProgressDto?> GetUserProgressAsync()
        ////{
        ////    return await _httpClient.GetFromJsonAsync<ProgressDto>("api/progress");
        ////}

        //// === User Results ===
        //public async Task<List<UserResultDto>?> GetUserResultsAsync()
        //{
        //    return await _httpClient.GetFromJsonAsync<List<UserResultDto>>("api/results");
        //}

        //public async Task<UserResultDto?> GetResultBySubCategoryAsync(int subCategoryId)
        //{
        //    return await _httpClient.GetFromJsonAsync<UserResultDto>($"api/results/subcategory/{subCategoryId}");
        //}
    }
}
