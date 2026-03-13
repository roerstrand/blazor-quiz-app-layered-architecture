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

            sb.AppendLine("Du analyserar quizresultat i cybersäkerhet.");
            sb.AppendLine("Använd endast resultaten.");
            sb.AppendLine();

            foreach (var entry in history)
            {
                var percent = entry.TotalQuestions > 0 ? (entry.Score * 100 / entry.TotalQuestions) : 0;
                sb.AppendLine($"{entry.SubCategoryName}: {percent}%");
            }

            sb.AppendLine();
            sb.AppendLine("Svara på svenska.");
            sb.AppendLine("Max 300 tecken totalt.");
            sb.AppendLine();
            sb.AppendLine("Format:");
            sb.AppendLine("Styrkor:");
            sb.AppendLine("Svagheter:");
            sb.AppendLine("Rekommendationer:");

            return sb.ToString();
        }
    }
}
