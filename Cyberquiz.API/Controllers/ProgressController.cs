using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/progress")]
    [Authorize]
    public class ProgressController : Controller
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }

        //Get api/progress/profile
        [HttpGet("profile")]
        public ActionResult<List<UserProgressDto>> GetUserProgress()
        {
            // TODO: return await _progressService.GetUserProgressAsync(User.Identity?.Name ?? "user");
            return Ok(new List<UserProgressDto>());
        }
    }
}
