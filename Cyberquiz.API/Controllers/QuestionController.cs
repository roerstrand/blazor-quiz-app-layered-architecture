using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/questions")]
    [Authorize]
    public class QuestionController : Controller
    {
        //private readonly IQuestionService _questionService;

        //public QuestionController(IQuestionService questionService)
        //{
        //    _questionService = questionService;
        //}

        //// GET api/quiz/subcategory/{subCategoryId}/next
        //[HttpGet("subcategory/{subCategoryId:int}/next")]
        //public async Task<ActionResult<QuestionDto>> GetNext(int subCategoryId)
        //{
        //    var userName = User.Identity?.Name ?? "user";

        //    var q = await _quiz.GetNextQuestionAsync(userName, subCategoryId);
        //    if (q is null) return NotFound();

        //    return Ok(q);
        //}

        //// POST api/quiz/answer
        //[HttpPost("answer")]
        //public async Task<ActionResult<SubmitResponseDto>> Submit([FromBody] SubmitAnswerRequestDto request)
        //{
        //    if (request is null) return BadRequest();

        //    var userName = User.Identity?.Name ?? "user";
        //    var result = await _quiz.SubmitAnswerAsync(userName, request);

        //    return Ok(result);
        //}


        //OSÄKER-------------------------------------------------------------------------------------------------

        // POST api/questions/subcategory/{subCategoryId}/start
        //[HttpPost("subcategory/{subCategoryId:int}/start")]
        //public async Task<ActionResult<List<QuestionDto>>> StartQuiz(int subCategoryId)
        //{
        //    var userId = User.Identity?.Name ?? "anonymous";
        //    var questions = await _questionService.StartQuizAsync(subCategoryId, userId);
        //    return Ok(questions);
        //}

        // GET api/questions/subcategory/{subCategoryId}
        //[HttpGet("subcategory/{subCategoryId:int}")]
        //public async Task<ActionResult<List<QuestionDto>>> GetBySubCategory(int subCategoryId)
        //{
        //    var userId = User.Identity?.Name ?? "anonymous";
        //    var questions = await _questionService.GetQuestionsBySubCategoryAsync(subCategoryId, userId);
        //    return Ok(questions);
        //}

        // POST api/questions/answer
        //[HttpPost("answer")]
        //public async Task<ActionResult<SubmitResponseDto>> SubmitAnswer([FromBody] SubmitAnswerRequestDto request)
        //{
        //    if (request == null)
        //        return BadRequest("Request body saknas");

        //    var userId = User.Identity?.Name ?? "anonymous";
        //    var result = await _questionService.SubmitAnswerRequestAsync(userId, request.QuestionId, request.AnswerOptionId);
        //    return Ok(result);
        //}
    }
}
