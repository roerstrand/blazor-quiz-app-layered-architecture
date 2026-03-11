using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IProgressService // Interface för kontrakt med Service
    {
        Task<UserProgressDto?> GetByUserAndSubCategoryAsync(string userName, int subCategoryId);
        Task<IEnumerable<UserProgressDto>> GetAllByUserAsync(string userName);
        Task SaveProgressAsync(UserProgressDto progress);
        Task SaveUserAnswerAsync(SubmitAnswerRequestDto answer);
        Task<HashSet<int>> GetAnsweredQuestionIdsAsync(string userName, int subCategoryId);
        Task SaveUserAnswerAsync(UserAnswerModel answer);
        Task<IEnumerable<SubmitAnswerRequestDto>> GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId);
        Task<double> CalculateSuccessRateAsync(string userName, int subCategoryId);
        Task<bool> IsSubCategoryCompletedAsync(string userName, int subCategoryId);
    }
}
