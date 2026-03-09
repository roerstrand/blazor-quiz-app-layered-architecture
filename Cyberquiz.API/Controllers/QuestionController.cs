using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<QuestionDto>> GetQuestionByIdAsync(int id)
        {
            var result = await _questionService.GetQuestionByIdAsync(id);
            if (result == null) return NotFound();

            return Ok(result);
        }
        

        [HttpGet("subcategory/{subCategoryId:int}/next")]
        public async Task<ActionResult<QuestionDto>> GetNextQuestionAsync(int subCategoryId)
        {
            var userName = User.Identity?.Name ?? "user";

            var q = await _questionService.GetNextQuestionInSubCategoryAsync(subCategoryId, userName);
            if (q is null) return NotFound();

            return Ok(q);
        }

        // POST api/questions/answer
        [HttpPost("answer")]
        public async Task<ActionResult<SubmitResponseDto>> SubmitAnswer ([FromBody] SubmitAnswerRequestDto request)
        {
            if (request is null) return BadRequest();
            var userName = User.Identity?.Name ?? "user";
            var result = await _questionService.SubmitAnswerAsync(request, userName);
            return Ok(result);
        }
        

        //DUMMY DATA (ta bort när ni har riktig data från BLL)-----------------------------------------------------------

        //private static readonly Dictionary<int, List<QuestionDto>> _bank = new()
        //{
        //    [101] = new List<QuestionDto>
        //{
        //    new QuestionDto
        //    {
        //        Id = 5001,
        //        Question = "Vad är TCP?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9001, Answer = "Ett transportlager-protokoll" },
        //            new() { Id = 9002, Answer = "Ett filformat" },
        //            new() { Id = 9003, Answer = "En krypteringsalgoritm" }
        //        }
        //    },
        //    new QuestionDto
        //    {
        //        Id = 5002,
        //        Question = "Vilket lager (i OSI) hör TCP till?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9011, Answer = "Transportlagret" },
        //            new() { Id = 9012, Answer = "Applikationslagret" },
        //            new() { Id = 9013, Answer = "Fysiska lagret" }
        //        }
        //    },
        //    new QuestionDto
        //    {
        //        Id = 5003,
        //        Question = "Vad står '3-way handshake' för?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9021, Answer = "SYN, SYN-ACK, ACK" },
        //            new() { Id = 9022, Answer = "ACK, ACK, ACK" },
        //            new() { Id = 9023, Answer = "DNS, DHCP, NAT" }
        //        }
        //    }
        //},

        //    [102] = new List<QuestionDto>
        //{
        //    new QuestionDto
        //    {
        //        Id = 5101,
        //        Question = "Vad används DNS till?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9101, Answer = "Översätta domännamn till IP-adresser" },
        //            new() { Id = 9102, Answer = "Kryptera all trafik automatiskt" },
        //            new() { Id = 9103, Answer = "Skapa VPN-tunnlar" }
        //        }
        //    },
        //    new QuestionDto
        //    {
        //        Id = 5102,
        //        Question = "Vad kallas en attack där DNS-svar manipuleras?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9111, Answer = "DNS spoofing / cache poisoning" },
        //            new() { Id = 9112, Answer = "SQL injection" },
        //            new() { Id = 9113, Answer = "Brute force" }
        //        }
        //    },
        //    new QuestionDto
        //    {
        //        Id = 5103,
        //        Question = "Vilken typ av DNS-post pekar en domän till en IP-adress?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9121, Answer = "A-record" },
        //            new() { Id = 9122, Answer = "MX-record" },
        //            new() { Id = 9123, Answer = "TXT-record" }
        //        }
        //    }
        //},

        //    [201] = new List<QuestionDto>
        //{
        //    new QuestionDto
        //    {
        //        Id = 6101,
        //        Question = "Vad är OWASP Top 10?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9201, Answer = "En lista över vanliga webbsårbarheter" },
        //            new() { Id = 9202, Answer = "Ett antivirusprogram" }
        //        }
        //    },
        //    new QuestionDto
        //    {
        //        Id = 6102,
        //        Question = "Vilket är ett exempel på 'Broken Access Control'?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9211, Answer = "Användare kan se admin-data utan behörighet" },
        //            new() { Id = 9212, Answer = "Dåligt lösenord" }
        //        }
        //    }
        //},

        //    [202] = new List<QuestionDto>
        //{
        //    new QuestionDto
        //    {
        //        Id = 6201,
        //        Question = "Vad står XSS för?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9301, Answer = "Cross-Site Scripting" },
        //            new() { Id = 9302, Answer = "Cross-Server Security" }
        //        }
        //    },
        //    new QuestionDto
        //    {
        //        Id = 6202,
        //        Question = "Vilket är ett bra skydd mot XSS?",
        //        AnswerOptions = new List<AnswerOptionDto>
        //        {
        //            new() { Id = 9311, Answer = "Output encoding + CSP" },
        //            new() { Id = 9312, Answer = "Större databasserver" }
        //        }
        //    }
        //}
        //};

        //// Håller koll på vilket index som är "nästa" per subkategori (per server-process)
        //private static readonly Dictionary<int, int> _index = new();

        //// GET api/quiz/subcategory/{subCategoryId}/next
        //[HttpGet("subcategory/{subCategoryId:int}/next")]
        //public ActionResult<QuestionDto> GetNext(int subCategoryId)
        //{
        //    if (!_bank.TryGetValue(subCategoryId, out var list) || list.Count == 0)
        //        return NotFound();

        //    if (!_index.ContainsKey(subCategoryId))
        //        _index[subCategoryId] = 0;

        //    var i = _index[subCategoryId];
        //    if (i >= list.Count)
        //    {
        //        // om ni vill: börja om från 0 istället
        //        // _index[subCategoryId] = 0; i = 0;
        //        return NotFound(); // "inga fler frågor"
        //    }

        //    return Ok(list[i]);
        //}

        //// POST api/quiz/answer
        //[HttpPost("answer")]
        //public ActionResult<SubmitResponseDto> Answer([FromBody] SubmitAnswerRequestDto request)
        //{
        //    if (request is null) return BadRequest();

        //    // Dummy: välj "första alternativet" som korrekt för varje fråga
        //    // (du kan göra en riktig facit-mapp om du vill)
        //    int correctId = 0;

        //    foreach (var kv in _bank)
        //    {
        //        var q = kv.Value.FirstOrDefault(x => x.Id == request.QuestionId);
        //        if (q != null)
        //        {
        //            correctId = q.AnswerOptions.First().Id;
        //            break;
        //        }
        //    }

        //    if (correctId == 0) return NotFound("Question not found.");

        //    var isCorrect = request.AnswerOptionId == correctId;

        //    // Flytta index framåt (så "Nästa" ger ny fråga)
        //    if (_index.ContainsKey(request.SubCategoryId))
        //        _index[request.SubCategoryId]++;

        //    return Ok(new SubmitResponseDto
        //    {
        //        IsCorrect = isCorrect,
        //        CorrectAnswerOptionId = correctId
        //    });
        //}
    }
}
