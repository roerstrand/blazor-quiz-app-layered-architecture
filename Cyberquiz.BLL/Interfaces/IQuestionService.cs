using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionDto?> GetQuestionByIdAsync(int questionId);
        //Task<IEnumerable<QuestionDto>> GetQuestionBySubCategoryAsync(int subCategoryId, string userName); // METOD ANVÄNDS INTE I NUVARANDE VERSION
        Task<QuestionDto?> GetNextQuestionInSubCategoryAsync(int subCategoryId, int progressId);
        Task<SubmitResponseDto> SaveUserAnswerAsync(SubmitAnswerRequestDto request, string userName);
    }
}
