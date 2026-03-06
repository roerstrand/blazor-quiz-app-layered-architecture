using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;

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
        public async Task<UserProgressDto?> GetByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            var progress = await _progressRepo.GetByUserAndSubCategoryAsync(userName, subCategoryId);
            return progress == null ? null : MapToUserProgressDto(progress);
        }

        public async Task<IEnumerable<UserProgressDto>> GetAllByUserAsync(string userName)
        {
            var progressList = await _progressRepo.GetAllByUserAsync(userName);
            return progressList.Select(pl => MapToUserProgressDto(pl)); // Mappar om hela listan av dto's till model
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

        public async Task<IEnumerable<SubmitAnswerRequestDto>> GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            var answers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            return answers.Select(ans => MapToSubmitAnswerRequestDto(ans));
        }

        public async Task<double> CalculateSuccessRateAsync(string userName, int subCategoryId)
        {
            var answers = await _progressRepo
                .GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);

            if (!answers.Any())
                return 0;

            double correct = answers.Count(a => a.IsCorrect);
            double total = answers.Count();

            return (correct / total) * 100;
        }

        public async Task<bool> IsSubCategoryCompletedAsync(string userName, int subCategoryId)
        {
            double successRate = await CalculateSuccessRateAsync(userName, subCategoryId);
            return successRate >= 80; // godkänd-gräns
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
