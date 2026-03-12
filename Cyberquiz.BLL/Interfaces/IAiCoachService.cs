using Cyberquiz.Shared.DTOs.AI_DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface IAiCoachService
    {
        Task<AiFeedbackDto> GetUserAnalysisAsync(string userId);
    }
}
