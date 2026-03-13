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
            sb.AppendLine("Du är en coach för en cybersäkerhetsutbildning. En användare har genomfört följande quiz inom olika cybersäkerhetsämnen (resultat i procent rätt svar):");
            sb.AppendLine();
            foreach (var entry in history)
            {
                var percent = entry.TotalQuestions > 0 ? (entry.Score * 100 / entry.TotalQuestions) : 0;
                sb.AppendLine($"- {entry.SubCategoryName}: {percent}% rätt ({entry.Score} av {entry.TotalQuestions})");
            }
            sb.AppendLine();
            sb.AppendLine("Svara på svenska med exakt tre korta stycken. Nämn alltid ämnena vid namn:");
            sb.AppendLine("Styrkor: Vad klarar användaren bra (över 70%) och varför är det viktigt inom cybersäkerhet?");
            sb.AppendLine("Svagheter: Vilka specifika ämnen (under 70%) behöver förbättras och vad innebär bristerna i praktiken?");
            sb.AppendLine("Rekommendationer: Ge konkreta studietips för de svaga ämnena — vad bör användaren läsa på, öva på eller vara extra uppmärksam på inom cybersäkerhet?");
            return sb.ToString();
        }
    }
}
