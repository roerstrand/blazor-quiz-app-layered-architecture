using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization; // Uttonad - Används inte?
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

        public async Task<ActionResult<List<UserProgressDto>>> GetProgress([FromQuery] string? userName)
        {
            var data = await _progressService.GetAllByUserAsync(userName);
            if (data == null) return BadRequest(string.Empty);
            return Ok(data);
        }

        // GET Endpoint som hämtar alla de svar en användare lämnat i en underkategori 
        [HttpGet("subcategory/{subCategoryId:int}/answers")]
        public async Task<ActionResult<IEnumerable<SubmitAnswerRequestDto>>> GetAnswersByUserAndSubCategory(
            int subCategoryId, [FromQuery] string? userName)
        {
            if (userName == null) return NotFound();

            var answers = await _progressService.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            if (answers == null) return BadRequest(string.Empty);
            return Ok(answers);
        }

        // GET api/progress/subcategory/{subCategoryId}/completed
        [HttpGet("subcategory/{subCategoryId:int}/completed")]
        public async Task<ActionResult<bool>> isSubCategoryCompleted(int subCategoryId, [FromQuery] string? userName)
        {
            if (userName == null) return BadRequest("Användaren kunde inte hittas.");
            var completed = await _progressService.IsSubCategoryCompletedAsync(userName, subCategoryId);
            return Ok(completed);
        }

    }
}
