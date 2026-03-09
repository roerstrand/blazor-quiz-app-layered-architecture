using Cyberquiz.DAL.Models;

namespace Cyberquiz.DAL.Interface
{
    public interface IQuestionRepository
    {
        // Hämtar en enskild fråga med svarsalternativ
        Task<QuestionModel?> GetQuestionByIdAsync(int id);

        // Hämtar alla frågor som tillhör en specifik subkategori
        Task<IEnumerable<QuestionModel>> GetQuestionsBySubCategoryAsync(int subCategoryId);
    }
}
