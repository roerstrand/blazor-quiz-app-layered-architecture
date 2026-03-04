using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;

namespace Cyberquiz.BLL.Services
{
    // Reglerar åtkomst
    // Använder ResultsService för att hämta information om användarens resultat
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepo;
        private readonly IQuestionRepository _questionRepo;

        public ProgressService(IProgressRepository progressRepo, IQuestionRepository questionRepo)
        {
            _progressRepo = progressRepo;
            _questionRepo = questionRepo;
        }
        public async Task<UserProgressModel?> GetByUserAndSubCategoryAsync(string userId, int subCategoryId)
        {
            return await _progressRepo.GetByUserAndSubCategoryAsync(userId, subCategoryId);
        }

        public async Task<IEnumerable<UserProgressModel>> GetAllByUserAsync(string userId)
        {
            return await _progressRepo.GetAllByUserAsync(userId);
        }

        public async Task SaveProgressAsync(UserProgressModel progress)
        {
            await _progressRepo.SaveProgressAsync(progress);
        }

        public async Task SaveUserAnswerAsync(UserAnswerModel answer)
        {
            await _progressRepo.SaveUserAnswerAsync(answer);
        }

        public async Task<IEnumerable<UserAnswerModel>> GetAnswersByUserAndSubCategoryAsync(string userId, int subCategoryId)
        {
            return await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userId, subCategoryId);
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
    }
}
