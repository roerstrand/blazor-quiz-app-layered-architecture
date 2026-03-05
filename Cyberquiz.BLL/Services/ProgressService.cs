using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;

namespace Cyberquiz.BLL.Services
{
    // Reglerar åtkomst
    // Använder ResultsService för att hämta information om användarens resultat
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepo;

        public ProgressService(IProgressRepository progressRepo)
        {
            _progressRepo = progressRepo;
        }
        public async Task<UserProgressDto?> GetByUserAndSubCategoryAsync(string userId, int subCategoryId)
        {
            var progress = await _progressRepo.GetByUserAndSubCategoryAsync(userId, subCategoryId);
            return progress == null ? null : MapToUserProgressDto(progress);
        }

        public async Task<IEnumerable<UserProgressDto>> GetAllByUserAsync(string userId)
        {
            var progressList = await _progressRepo.GetAllByUserAsync(userId);
            return progressList.Select(MapToUserProgressDto);
        }

        public async Task SaveProgressAsync(UserProgressDto progress)
        {
            var progressModel = MapToUserProgressModel(progress);
            await _progressRepo.SaveProgressAsync(progressModel);
        }

        public async Task SaveUserAnswerAsync(SubmitAnswerRequestDto answer)
        {
            var answerModel = MapToUserAnswerModel(answer);
            await _progressRepo.SaveUserAnswerAsync(answerModel);
        }

        public async Task<IEnumerable<SubmitAnswerRequestDto>> GetAnswersByUserAndSubCategoryAsync(string userId, int subCategoryId)
        {
            var answers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userId, subCategoryId);
            return answers.Select(MapToSubmitAnswerRequestDto);
        }

        public async Task<double> CalculateSuccessRateAsync(string userId, int subCategoryId)
        {
            var answers = await _progressRepo
                .GetAnswersByUserAndSubCategoryAsync(userId, subCategoryId);

            if (!answers.Any())
                return 0;

            double correct = answers.Count(a => a.IsCorrect);
            double total = answers.Count();

            return (correct / total) * 100;
        }

        public async Task<bool> IsSubCategoryCompletedAsync(string userId, int subCategoryId)
        {
            double successRate = await CalculateSuccessRateAsync(userId, subCategoryId);

            return successRate >= 80; // er godkänd-gräns
        }

        // Mapping-metoder från Model till Dto
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
                AnswerOptionId = dto.AnswerOptionId
            };
        }
    }
}
