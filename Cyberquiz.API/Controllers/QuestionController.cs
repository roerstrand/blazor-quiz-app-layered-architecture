using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Http.HttpResults; // Uttonad - Används inte?
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    public class QuestionController : ControllerBase
    {

        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{id:int}")] // Varje fråga kommer med fyra svaralternativ pga repots metod
        public async Task<ActionResult<QuestionDto>> GetQuestionByIdAsync(int questionId)
        {
            var result = await _questionService.GetQuestionByIdAsync(questionId);  // Visar bara om ngn är inloggad
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("subcategory/{subCategoryId:int}/next")]
        public async Task<ActionResult<QuestionDto>> GetNextQuestionAsync(int subCategoryId, [FromQuery] int progressId)
        {
            var q = await _questionService.GetNextQuestionInSubCategoryAsync(subCategoryId, progressId);
            if (q is null) return NotFound();
            return Ok(q);
        }

        // POST api/questions/answer
     
        [HttpPost("answer")]
        public async Task<ActionResult<SubmitResponseDto>> SubmitAnswer([FromBody] SubmitAnswerRequestDto request)
        {
            if (request is null) return BadRequest();

            var userName = request.UserName;
            if (string.IsNullOrEmpty(userName)) return Unauthorized();

            var result = await _questionService.SaveUserAnswerAsync(request, userName);

            return Ok(result);
        }
    }
}
