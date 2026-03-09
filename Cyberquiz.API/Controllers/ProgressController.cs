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
            var userName = User.Identity?.Name ?? "null"; // Ändrat från user till null så att vi inte går vidare utan användare
            if (userName == null)
            { 
                return BadRequest("Användaren kunde inte hittas.");
            }
            var data = await _progressService.GetAllByUserAsync(userName);
            return Ok(data);
        }

        // GET Endpoint som hämtar alla de svar en användare lämnat i en underkategori 
        [HttpGet("subcategory/{subCategoryId:int}/answers")]
        public async Task<ActionResult<IEnumerable<SubmitAnswerRequestDto>>> GetAnswersByUserAndSubCategory(
            int subCategoryId)
        {
            var userName = User.Identity?.Name ?? "null"; 
            if (userName == null)
            {
                return BadRequest("Användaren kunde inte hittas.");
            }
            var answers = await _progressService.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            return Ok(answers);
        }

        // GET api/progress/subcategory/{subCategoryId}/completed
        [HttpGet("subcategory/{subCategoryId:int}/completed")]
        public async Task<ActionResult<bool>> isSubCategoryCompleted(int subCategoryId)
        {
           var userName = User.Identity?.Name ?? "null"; // Ändrat från usre till null så att vi inte går vidare utan användare
            if (userName == null)
            {
                return BadRequest("Användaren kunde inte hittas.");
            }
            var completed = await _progressService.IsSubCategoryCompletedAsync(userName, subCategoryId);
            return Ok(completed);
        }
        

        // DUMMY DATA (ta bort när ni har riktig data från BLL)-----------------------------------------------------------

        //// GET api/progress/profile
        //[HttpGet("profile")]
        //public ActionResult<List<UserProgressDto>> GetProfile()
        //{
        //    var data = new List<UserProgressDto>
        //{
        //    new UserProgressDto
        //    {
        //        Id = 1,
        //        UserName = "user",
        //        SubCategoryId = 101,
        //        SubCategoryName = "TCP/IP",
        //        Score = 4,
        //        TotalQuestions = 5,
        //        CompletedAt = DateTime.UtcNow.AddDays(-1)
        //    }
        //};

        //    return Ok(data);
        //}

    }
}
