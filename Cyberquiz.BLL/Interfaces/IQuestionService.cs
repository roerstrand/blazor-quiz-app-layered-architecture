using Cyberquiz.DAL.Models;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionModel?> GetByIdAsync(int id);
        Task<IEnumerable<QuestionModel>> GetBySubCategoryAsync(int subCategoryId);
    }
}
