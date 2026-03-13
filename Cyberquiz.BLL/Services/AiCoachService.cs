using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.AI_DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace Cyberquiz.BLL.Services
{
    // Serviceklass som hanterar AI-coachning
    public class AiCoachService : IAiCoachService
    {
        private readonly IProgressService _progressService;
        private readonly IAiPromptBuilder _promptBuilder;
        private readonly IOpenAiClient _openAiClient;
        public AiCoachService(IProgressService progressService, IAiPromptBuilder promptBuilder, IOpenAiClient openAiClient)
        {
            _progressService = progressService;
            _promptBuilder = promptBuilder;
            _openAiClient = openAiClient;
        }

        public async Task<AiFeedbackDto> GetUserAnalysisAsync(string userName)
        {
            // Hämtar användarens resultat
            var results = await _progressService.GetAllByUserAsync(userName); // Vad är det vi vill anropa?
            // Bygger en sammanfattning av användarens resultat
            var summary = BuildSummary(new List<UserProgressDto>(results));
            // Skapar en prompt för AI:n baserat på sammanfattningen
            var prompt = _promptBuilder.BuildUserAnalysisPrompt(summary);
            // Hämtar feedback från AI:n
            var aiResponse = await _openAiClient.GetFeedback(prompt);
            // Returnerar feedbacken i en DTO
            return new AiFeedbackDto
            {
                Feedback = aiResponse
            };
        }
        private AiUserSummaryDto BuildSummary(List<UserProgressDto> results)
        {
            // Grupperar resultaten per underkategori och hämtar procent via IProgressService
            var categoryStats = results
                .GroupBy(r => r.SubCategoryName)
                .Select(g => new AiCategoryResultDto
                {
                    CategoryName = g.Key,
                    CorrectPercentage =
                        (int)(g.Count(x => x.IsCorrect) * 100.0 / g.Count())
                })
                .ToList();

            return new AiUserSummaryDto
            {
                CategoryResults = categoryStats
            };
        }

    }
}
