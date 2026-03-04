using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/profile")]
    
    public class ProgressController : Controller
    {
        //// Senare: injicera IProgressService
        //private readonly IProgressService _progressService;

        //public ProgressController(IProgressService progressService)
        //{
        //    _progressService = progressService;
        //}

        
        //// GET api/progress/profile
        //[HttpGet("profile")]
        //public async Task<ActionResult<List<UserProgressDto>>> GetProgress()
        //{
        //    var userName = User.Identity?.Name ?? "user";
        //    var data = await _progressService.GetUserProgressAsync(userName);
        //    return Ok(data);
        //}




        
    }
}
