using Cyberquiz.DAL.Models;

namespace Cyberquiz.DAL.Interface
{
    public interface IProgressRepository
    {
        // Retrieves progress for a user in a specific subcategory
        Task<UserProgressModel?> GetByUserAndSubCategoryAsync(string userName, int subCategoryId);

        // Retrieves all progress for a user
        Task<IEnumerable<UserProgressModel>> GetAllByUserAsync(string userName);

        // Saves or updates progress (upsert)
        Task SaveProgressAsync(UserProgressModel progress);

        // Saves a single user answer
        Task SaveUserAnswerAsync(UserAnswerModel answer);

        // Retrieves all answers a user has submitted for a subcategory
        Task<IEnumerable<UserAnswerModel>> GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId);

        // Retrieves a specific progress record by id
        Task<UserProgressModel?> GetByIdAsync(int id);

        // Updates an existing progress record (score, totalquestions)
        Task UpdateProgressAsync(UserProgressModel progress);

        // Retrieves answered question ids for a specific session
        Task<HashSet<int>> GetAnsweredQuestionIdsBySessionAsync(int progressId);

        // Deletes all data for a user (GDPR/admin)
        Task DeleteByUserAsync(string userName);

        // Keeps the X most recent results and deletes the rest (DB cleanup)
        Task DeleteOldestByUserAsync(string userName, int keepLatest);
    }
}
