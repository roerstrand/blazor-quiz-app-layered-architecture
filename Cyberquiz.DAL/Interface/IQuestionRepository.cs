using Cyberquiz.DAL.Models;

namespace Cyberquiz.DAL.Interface
{
    public interface IQuestionRepository
    {
        // Retrieves a single question with answer options
        Task<QuestionModel?> GetQuestionByIdAsync(int id);

        // Retrieves all questions belonging to a specific subcategory
        Task<IEnumerable<QuestionModel>> GetQuestionsBySubCategoryAsync(int subCategoryId);
    }
}
