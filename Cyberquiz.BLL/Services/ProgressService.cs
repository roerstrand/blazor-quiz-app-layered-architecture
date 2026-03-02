using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using System.Threading.Tasks;

namespace Cyberquiz.BLL.Services
{
    // Reglerar åtkomst
    // Använder ResultsService för att hämta information om användarens resultat
    public class ProgressService : IProgressService
    {
        private readonly IQuizRepository _quizRepository;

        public ProgressService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        // Metod för att avgöra om en subkategori är upplåst
        public async Task<bool> IsSubCategoryUnlockedAsync(string userId, int subCatId)
        {
            // Hämta användarens progress för underkategorin
            var progress = await _quizRepository.GetUserProgressAsync(userId, subCatId);

            // Om ingen progress finns: subkategorin är inte upplåst
            if (progress == null)
            {
                return false;
            }

            // Om inga frågor besvarats: returnera false
            if (progress.TotalQuestions == 0)
            {
                return false;
            }

            // Beräkna andel rätt svar
            double resultsScore = (double)progress.Score / progress.TotalQuestions;

            // Subkategorin är upplåst om användaren har minst 80% rätt
            return resultsScore >= 0.80;
        }
    }
}
