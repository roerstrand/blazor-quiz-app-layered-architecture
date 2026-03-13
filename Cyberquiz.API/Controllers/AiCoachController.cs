using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs.AI_DTOs;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/aicoach")]
    public class AiCoachController : ControllerBase
    {
        private readonly IAiCoachService _aiCoachService;

        public AiCoachController(IAiCoachService aiCoachService)
        {
            _aiCoachService = aiCoachService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AiFeedbackDto>> GetFeedback()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName)) return Unauthorized();
            var result = await _aiCoachService.GetUserAnalysisAsync(userName);
            return Ok(result);
        }
    }
}
