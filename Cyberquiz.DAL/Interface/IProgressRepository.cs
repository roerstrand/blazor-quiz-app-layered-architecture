using Cyberquiz.DAL.Models;

namespace Cyberquiz.DAL.Interface
{
    public interface IProgressRepository
    {
        // Hämtar progress för en användare i en specifik subkategori
        Task<UserProgressModel?> GetByUserAndSubCategoryAsync(string userName, int subCategoryId);

        // Hämtar all progress för en användare
        Task<IEnumerable<UserProgressModel>> GetAllByUserAsync(string userName);

        // Sparar eller uppdaterar progress (upsert)
        Task SaveProgressAsync(UserProgressModel progress);

        // Sparar ett enskilt användarsvar
        Task SaveUserAnswerAsync(UserAnswerModel answer);

        // Hämtar alla svar en användare lämnat för en subkategori
        Task<IEnumerable<UserAnswerModel>> GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId);

        // Tar bort all data för en användare (GDPR/admin)
        Task DeleteByUserAsync(string userName);

        // Behåller de X senaste resultaten och tar bort resten (DB-rensning)
        Task DeleteOldestByUserAsync(string userName, int keepLatest);
    }
}
