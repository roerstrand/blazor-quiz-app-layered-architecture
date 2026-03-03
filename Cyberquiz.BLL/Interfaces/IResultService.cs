using System.Threading.Tasks;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IResultService
    {
        // Spara ett enskilt svar från användaren
        Task<bool> SubmitAnswerAsync(string userId, int questionId, int selectedOptionId);

        // Slutför quiz och spara progress
        Task CompleteQuizAsync(string userId, int subCategoryId);
    }
}
