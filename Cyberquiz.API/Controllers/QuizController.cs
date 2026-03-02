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
        public async Task<ActionResult<QuestionDto>> GetNextQuestion(int subCategoryId)
        {
            var userName = User.Identity?.Name ?? "user";

            var question = await _quizService.GetNextQuestionAsync(userName, subCategoryId);

            if (question is null)
                return NotFound();

            return Ok(question);
        }

        //POST: api/quiz/answer
        [HttpPost("answer")]
        public async Task<ActionResult<SubmitResponseDto>> SubmitAnswer(SubmitAnswerRequestDto request)
        {
            if (request is null)
                return BadRequest();
            
            var userName = User.Identity?.Name ?? "user";
            var response = await _quizService.SubmitAnswerAsync(userName, request);

            return Ok(response);
        }



        //[HttpGet("/api/quizzes")]
        //public async Task<ActionResult<List<QuizDto>>> GetQuizzes()
        //{
        //    var quizzes = await _quizService.GetAllAsync();
        //    return Ok(quizzes);
        //}
    }
}
