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
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // GET: api/quiz/subcategory/{subCategoryId}/next
        [HttpGet("subcategory/{subCategoryId:int}/next")]
        public async Task<ActionResult<QuestionDto>> GetNextQuestion(int subCategoryId)
        {
            var userName = User.Identity?.Name ?? "user";

            // TODO: Implementera GetNextQuestionAsync i QuizService
            // var question = await _quizService.GetNextQuestionAsync(userName, subCategoryId);

            // if (question is null)
            //     return NotFound();

            // return Ok(question);

            return NotFound("GetNextQuestionAsync not implemented yet");
        }

        // POST: api/quiz/answer
        [HttpPost("answer")]
        public async Task<ActionResult<SubmitResponseDto>> SubmitAnswer([FromBody] SubmitAnswerRequestDto request)
        {
            if (request is null)
                return BadRequest("Request cannot be null");

            var userName = User.Identity?.Name ?? "user";

            var response = await _quizService.SubmitAnswerRequestAsync(
                userName, 
                request.QuestionId, 
                request.AnswerOptionId
            );

            return Ok(response);
        }
    }
}
