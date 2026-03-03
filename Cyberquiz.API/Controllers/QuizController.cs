using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    //[Authorize]
    public class QuizController : Controller
    {

        // Senare: injicera IQuizService
        // private readonly IQuizService _quizService;
        // public QuizController(IQuizService quizService) => _quizService = quizService;

        // GET api/quiz/subcategory/{subCategoryId}/next
        [HttpGet("subcategory/{subCategoryId:int}/next")]
        public ActionResult<QuestionDto> GetNextQuestion(int subCategoryId)
        {
            // DUMMY: alltid samma fråga (för att UI ska funka)
            var q = new QuestionDto
            {
                Id = 5001,
                Question = $"(SubCategory {subCategoryId}) Vad används DNS till?",
                AnswerOptions = new List<AnswerOptionDto>
            {
                new() { Id = 9001, Answer = "Översätta domännamn till IP-adresser" },
                new() { Id = 9002, Answer = "Kryptera all trafik automatiskt" },
                new() { Id = 9003, Answer = "Blockera portar i brandväggen" }
            }
            };

            return Ok(q);
        }

        // POST api/quiz/answer
        [HttpPost("answer")]
        public ActionResult<SubmitResponseDto> SubmitAnswer([FromBody] SubmitAnswerRequestDto request)
        {
            if (request is null) return BadRequest("Body saknas.");

            // DUMMY: correct är alltid optionId 9001
            var correctId = 9001;
            var isCorrect = request.AnswerOptionId == correctId;

            // Här ska ni i riktig version:
            // 1) rätta via DB (QuestionAnswerOptionModel)
            // 2) spara UserAnswer/UserProgress
            // 3) räkna 80% och låsa upp nästa subkategori

            return Ok(new SubmitResponseDto
            {
                IsCorrect = isCorrect,
                CorrectAnswerOptionId = correctId
            });
        }
        //private readonly IQuizService _quizService;

        //public QuizController(IQuizService quizService)
        //{
        //    _quizService = quizService;
        //}

        ////GET api/quiz/subcategory/{subCategoryId}/next
        //[HttpGet("subcategory/{subCategoryId:int}/next")]
        //public ActionResult<QuestionDto> GetNextQuestion(int subCategoryId)
        //{
        //    // TODO: return await _quizService.GetNextQuestionAsync(User.Identity?.Name ?? "user", subCategoryId);
        //    return NotFound();
        //}

        ////POST: api/quiz/answer
        //[HttpPost("answer")]
        //public ActionResult<SubmitResponseDto> SubmitAnswer(SubmitAnswerRequestDto request)
        //{
        //    if (request is null)
        //        return BadRequest();

        //    // TODO: return await _quizService.SubmitAnswerAsync(User.Identity?.Name ?? "user", request);
        //    return Ok(new SubmitResponseDto());
        //}



        //[HttpGet("/api/quizzes")]
        //public async Task<ActionResult<List<QuizDto>>> GetQuizzes()
        //{
        //    var quizzes = await _quizService.GetAllAsync();
        //    return Ok(quizzes);
        //}
    }
}
