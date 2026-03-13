using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.AI_DTOs;
using System.Text;

namespace Cyberquiz.BLL.Services
{
    public class AiCoachService : IAiCoachService
    {
        private readonly IProgressService _progressService;
        private readonly IAiClient _openAiClient;

        public AiCoachService(IProgressService progressService, IAiClient openAiClient)
        {
            _progressService = progressService;
            _openAiClient = openAiClient;
        }

        public async Task<AiFeedbackDto> GetUserAnalysisAsync(string userName)
        {
            var history = await _progressService.GetAllByUserAsync(userName);
            var prompt = BuildPrompt(history);
            var aiResponse = await _openAiClient.GetFeedback(prompt);
            return new AiFeedbackDto { Feedback = aiResponse };
        }

        private string BuildPrompt(IEnumerable<UserProgressDto> history)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Du är en AI-coach som ger personlig feedback till EN användare baserat på resultaten nedan.");
            sb.AppendLine("Skriv direkt till användaren i du-form (\"du\").");
            sb.AppendLine("Använd aldrig ord som \"studenter\", \"elever\" eller \"klass\".");
            sb.AppendLine();

            sb.AppendLine("Användarens quizresultat per subkategori (poäng/antal = procent):");
            foreach (var entry in history)
            {
                var percent = entry.TotalQuestions > 0 ? (entry.Score * 100 / entry.TotalQuestions) : 0;
                sb.AppendLine($"- {entry.SubCategoryName}: {entry.Score}/{entry.TotalQuestions} = {percent}%");
            }

            sb.AppendLine();
            sb.AppendLine("Svara på svenska med exakt tre rubriker:");
            sb.AppendLine("Styrkor:");
            sb.AppendLine("Svagheter:");
            sb.AppendLine("Rekommendationer:");
            sb.AppendLine("Max 150 ord. Var konkret och koppla rekommendationerna till resultaten.");

            return sb.ToString();
        }
    }
}
