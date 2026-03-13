using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [Authorize]
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
            var userName = User.Identity?.Name;
            var data = await _progressService.GetAllByUserAsync(userName);
            if (data == null) return BadRequest(string.Empty);
            return Ok(data);
        }

        // GET Endpoint som hämtar alla de svar en användare lämnat i en underkategori 
        [HttpGet("subcategory/{subCategoryId:int}/answers")]
        public async Task<ActionResult<IEnumerable<SubmitAnswerRequestDto>>> GetAnswersByUserAndSubCategory(int subCategoryId)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName)) return Unauthorized();

            var answers = await _progressService.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            if (answers == null) return BadRequest(string.Empty);
            return Ok(answers);
        }

        // POST api/progress/session — startar ett nytt quiz-försök och returnerar progressId
        [HttpPost("session")]
        public async Task<ActionResult<int>> StartSession([FromQuery] int subCategoryId)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName)) return Unauthorized();
            var progressId = await _progressService.StartSessionAsync(userName, subCategoryId);
            return Ok(progressId);
        }

        // GET api/progress/subcategory/{subCategoryId}/completed
        [HttpGet("subcategory/{subCategoryId:int}/completed")]
        public async Task<ActionResult<bool>> isSubCategoryCompleted(int subCategoryId)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName)) return Unauthorized();
            var completed = await _progressService.IsSubCategoryCompletedAsync(userName, subCategoryId);
            return Ok(completed);
        }

        // DELETE api/progress/all — raderar all progression för inloggad användare (GDPR)
        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAllProgress()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName)) return Unauthorized();
            await _progressService.DeleteAllProgressForUserAsync(userName);
            return NoContent();
        }

        // DELETE api/progress/keep/{keepLatest} — behåller N senaste, raderar resten
        [HttpDelete("keep/{keepLatest:int}")]
        public async Task<ActionResult> DeleteOldProgress(int keepLatest)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName)) return Unauthorized();
            await _progressService.KeepRecentProgressForUserAsync(userName, keepLatest);
            return NoContent();
        }

    }
}
