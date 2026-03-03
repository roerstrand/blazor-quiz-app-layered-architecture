using System.Collections.Generic;
using System.Threading.Tasks;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IQuizService
    {
        // Hämtar frågor för en subkategori (med validation av användarens tillgång)
        Task<List<QuestionDto>> GetQuestionsBySubCategoryAsync(int subCategoryId, string userId);

        // Startar ett quiz - returnerar alla frågor för subkategorin
        Task<List<QuestionDto>> StartQuizAsync(int subCategoryId, string userId);

        // Skickar in ett svar från användaren
        Task<SubmitResponseDto> SubmitAnswerRequestAsync(string userId, int questionId, int selectedOptionId);
    }
}
