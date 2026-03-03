using Cyberquiz.DAL.Models;

namespace Cyberquiz.DAL.Interface
{
    public interface IQuizRepository
    {
        // Hämtar alla quizar (utan frågor/svar — för listvy)
        Task<IEnumerable<QuizModel>> GetAllAsync();

        // Hämtar ett quiz med alla frågor och svarsalternativ (för gameplay)
        Task<QuizModel?> GetByIdAsync(int id);

    }
}
