// TODO: Kommenterad tills IOpenAiClient är implementerad
/*
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs.AI_DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace Cyberquiz.BLL.Services
{
    public class AiCoachService
    {
        private readonly IProgressService _progressService;
        private readonly IOpenAiClient _openAiClient;
        public AiCoachService(IProgressService progressService, IOpenAiClient openAiClient)
        {
            _progressService = progressService;
            _openAiClient = openAiClient;
        }

        public async Task<AiFeedbackDto> GetUserAnalysisAsync(string userName)
        {
            var history = await _progressService.GetAllByUserAsync(userName);
            var summary = BuildSummary(history);
            var aiResponse = await _openAiClient.GetFeedback(summary);
            return new AiFeedbackDto
            {
                Feedback = aiResponse
            };
        }
    }
}
*/
