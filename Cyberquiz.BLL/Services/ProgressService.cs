using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Services
{
    // Controls access
    // Uses QuestionService to retrieve information about user results
    // Contains five methods to cooperate with endpoints in ProgressController in the API layer
    // Contains two business logic methods to calculate user success rate and determine if a subcategory is passed
    // Contains two methods for GDPR and database cleanup, not tied to any endpoints
    // Currently also contains mapping methods to convert between Model and Dto (consider moving to a dedicated Mapper class)
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepo;

        public ProgressService(IProgressRepository progressRepo)
        {
            _progressRepo = progressRepo;
        }

        // Method for ENDPOINT "progress/subcategory/{subCategoryId:int}" — retrieves user progress within a subcategory
        public async Task<UserProgressDto?> GetByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            // Calls repo method with username and subcategory id as arguments
            var progress = await _progressRepo.GetByUserAndSubCategoryAsync(userName, subCategoryId);
            // Maps Dto to Model
            return progress == null ? null : MapToUserProgressDto(progress);
        }

        // Method for ENDPOINT "progress/user/{userName}" — retrieves all progress for a user
        public async Task<IEnumerable<UserProgressDto>> GetAllByUserAsync(string userName)
        {
            // Calls repo method with username as argument
            var progressList = await _progressRepo.GetAllByUserAsync(userName);
            // Maps the entire list of dtos to model
            return progressList.Select(pl => MapToUserProgressDto(pl));
        }

        // Method for ENDPOINT "progress" — saves user progress
        public async Task SaveProgressAsync(UserProgressDto progress)
        {
            // Maps Dto to Model
            var progressModel = MapToUserProgressModel(progress);
            // Calls repo method with model as argument
            await _progressRepo.SaveProgressAsync(progressModel);
        }

        // Method for ENDPOINT [HttpPost("answer")] — saves user answer

        // Method for ENDPOINT [HttpGet("subcategory/{subCategoryId:int}/answers")]
        // — retrieves all answers saved for a user within a subcategory
        // — filters with LINQ-select for the current user and subcategory
        public async Task<IEnumerable<SubmitAnswerRequestDto>> GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            // Calls repo method with username and subcategory id as arguments
            var answers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            // Maps the entire list of dtos to model
            return answers.Select(ans => MapToSubmitAnswerRequestDto(ans));
        }

        // Starts a new session (new UserProgress record) and returns its id
        public async Task<int> StartSessionAsync(string userName, int subCategoryId)
        {
            var progress = new UserProgressModel
            {
                UserName = userName,
                SubCategoryId = subCategoryId,
                Score = 0,
                TotalQuestions = 0,
                CompletedAt = DateTime.UtcNow
            };
            await _progressRepo.SaveProgressAsync(progress);
            return progress.Id;
        }

        // Retrieves answered question ids for a specific session
        public async Task<HashSet<int>> GetAnsweredQuestionIdsAsync(int progressId)
        {
            return await _progressRepo.GetAnsweredQuestionIdsBySessionAsync(progressId);
        }

        // Saves answer and updates score for the session
        public async Task SaveUserAnswerAsync(SubmitAnswerRequestDto answer, string userName)
        {
            var progress = await _progressRepo.GetByIdAsync(answer.ProgressId);
            if (progress == null) throw new Exception("Session not found.");

            var answerModel = MapToUserAnswerModel(answer);
            answerModel.UserName = userName;
            answerModel.UserProgressId = progress.Id;
            answerModel.AnsweredAt = DateTime.UtcNow;
            await _progressRepo.SaveUserAnswerAsync(answerModel);

            progress.TotalQuestions++;
            if (answer.IsCorrect) progress.Score++;
            progress.CompletedAt = DateTime.UtcNow;
            await _progressRepo.UpdateProgressAsync(progress);
        }

        // Method to delete all answers and progress for a user (GDPR/admin)
        public async Task DeleteAllProgressForUserAsync(string userName)
        {
            // Calls repo method with username as argument
            await _progressRepo.DeleteByUserAsync(userName);
        }

        // Method to keep the X most recent results and delete the rest (DB cleanup)
        public async Task KeepRecentProgressForUserAsync(string userName, int maxSavedInstances)
        {
            // Calls repo method to retrieve progress with username as argument
            var allProgress = await _progressRepo.GetAllByUserAsync(userName);
            var progressToDelete = allProgress
                .OrderByDescending(p => p.CompletedAt) // sort by date
                .Skip(maxSavedInstances) // skip the newest, leaving the oldest
                .ToList(); // convert to list to iterate (foreach) over it
            foreach (var progress in progressToDelete)
            {
                // Calls repo method to delete progress with username and maxSavedInstances as arguments
                await _progressRepo.DeleteOldestByUserAsync(progress.UserName, maxSavedInstances);
            }
        }

        // Method to calculate the user's success rate within a subcategory
        public async Task<double> CalculateSuccessRateAsync(string userName, int subCategoryId)
        {
            // Calls repo method with username and subcategory id as arguments
            var answers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            // If no answers exist for the user and subcategory, return 0% success
            if (!answers.Any())
                return 0;

            double correct = answers.Count(a => a.IsCorrect); // Number of correct answers
            double total = answers.Count(); // Total number of answers

            return (correct / total) * 100; // Returns calculation
        }

        // Determines if a subcategory is passed — checks if ANY attempt reached ≥80%
        public async Task<bool> IsSubCategoryCompletedAsync(string userName, int subCategoryId)
        {
            var allProgress = await _progressRepo.GetAllByUserAsync(userName);
            return allProgress.Any(p =>
                p.SubCategoryId == subCategoryId &&
                p.TotalQuestions > 0 &&
                (double)p.Score / p.TotalQuestions * 100 >= 80);
        }

        // Mapping from Model to Dto
        private UserProgressDto MapToUserProgressDto(UserProgressModel model)
        {
            return new UserProgressDto
            {
                Id = model.Id,
                UserName = model.UserName,
                SubCategoryId = model.SubCategoryId,
                SubCategoryName = model.SubCategory?.Name ?? string.Empty,
                Score = model.Score,
                TotalQuestions = model.TotalQuestions,
                CompletedAt = model.CompletedAt
            };
        }

        // Mapping from Dto to Model
        private UserProgressModel MapToUserProgressModel(UserProgressDto dto)
        {
            return new UserProgressModel
            {
                Id = dto.Id,
                UserName = dto.UserName,
                SubCategoryId = dto.SubCategoryId,
                Score = dto.Score,
                TotalQuestions = dto.TotalQuestions,
                CompletedAt = dto.CompletedAt
            };
        }

        private SubmitAnswerRequestDto MapToSubmitAnswerRequestDto(UserAnswerModel model)
        {
            return new SubmitAnswerRequestDto
            {
                SubCategoryId = model.Question?.SubCategoryId ?? 0,
                QuestionId = model.QuestionId,
                AnswerOptionId = model.AnswerOptionId
            };
        }

        private UserAnswerModel MapToUserAnswerModel(SubmitAnswerRequestDto dto)
        {
            return new UserAnswerModel
            {
                QuestionId = dto.QuestionId,
                AnswerOptionId = dto.AnswerOptionId,
                IsCorrect = dto.IsCorrect
            };
        }
    }
}
