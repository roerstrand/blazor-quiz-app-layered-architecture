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
    public class QuestionController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuestionController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // POST api/questions/subcategory/{subCategoryId}/start
        [HttpPost("subcategory/{subCategoryId:int}/start")]
        public async Task<ActionResult<List<QuestionDto>>> StartQuiz(int subCategoryId)
        {
            var userId = User.Identity?.Name ?? "anonymous";
            var questions = await _quizService.StartQuizAsync(subCategoryId, userId);
            return Ok(questions);
        }

        // GET api/questions/subcategory/{subCategoryId}
        [HttpGet("subcategory/{subCategoryId:int}")]
        public async Task<ActionResult<List<QuestionDto>>> GetBySubCategory(int subCategoryId)
        {
            var userId = User.Identity?.Name ?? "anonymous";
            var questions = await _quizService.GetQuestionsBySubCategoryAsync(subCategoryId, userId);
            return Ok(questions);
        }

        // POST api/questions/answer
        [HttpPost("answer")]
        public async Task<ActionResult<SubmitResponseDto>> SubmitAnswer([FromBody] SubmitAnswerRequestDto request)
        {
            if (request == null)
                return BadRequest("Request body saknas");

            var userId = User.Identity?.Name ?? "anonymous";
            var result = await _quizService.SubmitAnswerRequestAsync(userId, request.QuestionId, request.AnswerOptionId);
            return Ok(result);
        }
    }
}
