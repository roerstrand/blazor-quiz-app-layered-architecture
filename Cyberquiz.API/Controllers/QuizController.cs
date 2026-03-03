using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        // POST api/quiz/subcategory/{subCategoryId}/start
        // Startar ett quiz och returnerar alla frågor
        [HttpPost("subcategory/{subCategoryId:int}/start")]
        public async Task<ActionResult<List<QuestionDto>>> StartQuiz(int subCategoryId)
        {
            var userId = User.Identity?.Name ?? "anonymous";
            var questions = await _quizService.StartQuizAsync(subCategoryId, userId);

            return Ok(questions);
        }

        // GET api/quiz/subcategory/{subCategoryId}/questions
        // Hämtar alla frågor för en subkategori
        [HttpGet("subcategory/{subCategoryId:int}/questions")]
        public async Task<ActionResult<List<QuestionDto>>> GetQuestions(int subCategoryId)
        {
            var userId = User.Identity?.Name ?? "anonymous";
            var questions = await _quizService.GetQuestionsBySubCategoryAsync(subCategoryId, userId);

            return Ok(questions);
        }

        // POST api/quiz/answer
        // Skickar in ett svar från användaren
        [HttpPost("answer")]
        public async Task<ActionResult<SubmitResponseDto>> SubmitAnswer([FromBody] SubmitAnswerRequestDto request)
        {
            if (request == null)
                return BadRequest("Request body saknas");

            var userId = User.Identity?.Name ?? "anonymous";
            var result = await _quizService.SubmitAnswerRequestAsync(
                userId, 
                request.QuestionId, 
                request.AnswerOptionId);

            return Ok(result);
        }
    }
}
