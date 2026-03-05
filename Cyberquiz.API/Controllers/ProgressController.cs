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
            var userName = User.Identity?.Name ?? "user";
            var data = await _progressService.GetAllByUserAsync(userName);
            return Ok(data);

        }
        

        // GET api/progress/subcategory/{subCategoryId}/completed
        [HttpGet("subcategory/{subCategoryId:int}/completed")]
        public async Task<ActionResult<bool>> isSubCategoryCompleted(int subCategoryId)
        {
           var userName = User.Identity?.Name ?? "user";
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
