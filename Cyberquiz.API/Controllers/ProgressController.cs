using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/progress")]

    public class ProgressController : ControllerBase
    {

        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }

        // GET api/progress/profile

        [HttpGet("profile")]

        public async Task<ActionResult<List<UserProgressDto>>> GetProgress()
        {
            var userName = User.Identity?.Name ?? null;
            if (userName == null) return BadRequest("Hittade ingen inloggad användare");

            var data = await _progressService.GetAllByUserAsync(userName);
            return Ok(data);

        }

        // GET api/progress/subcategory/{subCategoryId}/completed
        [HttpGet("subcategory/{subCategoryId:int}/completed")]
        public async Task<ActionResult<bool>> isSubCategoryCompleted(int subCategoryId)
        {
            var userName = User.Identity?.Name ?? null;
            if (userName == null) return BadRequest("Hittade ingen inloggad användare");

            var completed = await _progressService.IsSubCategoryCompletedAsync(userName, subCategoryId);
            return Ok(completed);
        }

    }
}
