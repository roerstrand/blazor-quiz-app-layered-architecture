using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionDto?> GetByIdAsync(int id);
        //Task<IEnumerable<QuestionDto>> GetBySubCategoryAsync(int subCategoryId, string userName); // METOD ANVÄNDS INTE I NUVARANDE VERSION
        Task<QuestionDto?> GetNextQuestionInSubCategoryAsync(int subCategoryId); // hämtar nästa fråga som användaren inte har svarat på i den subkategorin
        Task<SubmitResponseDto> SubmitAnswerAsync(SubmitAnswerRequestDto request, string userName); //tar emot användarens svar, sparar det och returnerar om det var rätt eller fel
    }
}
