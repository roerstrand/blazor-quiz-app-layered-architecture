using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        //GET api/quiz/subcategory/{subCategoryId}/next
        [HttpGet("subcategory/{subCategoryId:int}/next")]
        public ActionResult<QuestionDto> GetNextQuestion(int subCategoryId)
        {
            // TODO: return await _quizService.GetNextQuestionAsync(User.Identity?.Name ?? "user", subCategoryId);
            return NotFound();
        }

        //POST: api/quiz/answer
        [HttpPost("answer")]
        public ActionResult<SubmitResponseDto> SubmitAnswer(SubmitAnswerRequestDto request)
        {
            if (request is null)
                return BadRequest();

            // TODO: return await _quizService.SubmitAnswerAsync(User.Identity?.Name ?? "user", request);
            return Ok(new SubmitResponseDto());
        }



        //[HttpGet("/api/quizzes")]
        //public async Task<ActionResult<List<QuizDto>>> GetQuizzes()
        //{
        //    var quizzes = await _quizService.GetAllAsync();
        //    return Ok(quizzes);
        //}
    }
}
