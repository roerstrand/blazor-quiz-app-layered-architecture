using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IProgressService // Interface för kontrakt med Service
    {
        Task<UserProgressDto?> GetByUserAndSubCategoryAsync(string userId, int subCategoryId);

        Task<IEnumerable<UserProgressDto>> GetAllByUserAsync(string userId);

        Task SaveProgressAsync(UserProgressDto progress);

        Task SaveUserAnswerAsync(SubmitAnswerRequestDto answer);

        Task<IEnumerable<SubmitAnswerRequestDto>> GetAnswersByUserAndSubCategoryAsync(string userId, int subCategoryId);

        Task<double> CalculateSuccessRateAsync(string userId, int subCategoryId);

        Task<bool> IsSubCategoryCompletedAsync(string userId, int subCategoryId);
    }
}
