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
        public async Task<ActionResult<List<UserProgressDto>>> GetUserProgress()
        {
            var username = User.Identity?.Name ?? "user";
            var progress = await _progressService.GetUserProgressAsync(username);
            return Ok(progress);
        }
    }
}
