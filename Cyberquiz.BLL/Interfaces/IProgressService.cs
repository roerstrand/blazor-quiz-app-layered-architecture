using Cyberquiz.DAL.Models;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IProgressService // Interface för kontrakt med Service
    {
        Task<UserProgressModel?> GetByUserAndSubCategoryAsync(string userId, int subCategoryId);

        Task<IEnumerable<UserProgressModel>> GetAllByUserAsync(string userId);

        Task SaveProgressAsync(UserProgressModel progress);

        Task SaveUserAnswerAsync(UserAnswerModel answer);

        Task<IEnumerable<UserAnswerModel>> GetAnswersByUserAndSubCategoryAsync(string userId, int subCategoryId);

        Task<double> CalculateSuccessRateAsync(string userId, int subCategoryId);

        Task<bool> IsSubCategoryCompletedAsync(string userId, int subCategoryId);
    }
}
