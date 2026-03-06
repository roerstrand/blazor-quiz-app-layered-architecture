using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionDto?> GetByIdAsync(int id);
        Task<IEnumerable<QuestionDto>> GetBySubCategoryAsync(int subCategoryId);
        Task<QuestionDto?> GetNextQuestionAsync(string userName, int subCategoryId); // hämtar nästa fråga som användaren inte har svarat på i den subkategorin
        Task<SubmitResponseDto> SubmitAnswerAsync(string userName, SubmitAnswerRequestDto request); //tar emot användarens svar, sparar det och returnerar om det var rätt eller fel
    }
}
