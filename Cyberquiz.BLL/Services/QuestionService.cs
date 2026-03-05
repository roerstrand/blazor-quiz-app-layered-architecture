using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Interface;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;
        public QuestionService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }
        public async Task<QuestionDto?> GetByIdAsync(int id)
        {
            var question = await _questionRepo.GetByIdAsync(id);
            return question == null ? null : MapToQuestionDto(question);
        }

        public async Task<IEnumerable<QuestionDto>> GetBySubCategoryAsync(int subCategoryId)
        {
            var questions = await _questionRepo.GetBySubCategoryAsync(subCategoryId);
            return questions.Select(MapToQuestionDto);
        }

        // Mapping-metod från Model till Dto
        private QuestionDto MapToQuestionDto(QuestionModel model)
        {
            return new QuestionDto
            {
                Id = model.Id,
                Question = model.Question,
                AnswerOptions = model.QuestionAnswerOptions?
                    .Select(qao => new AnswerOptionDto
                    {
                        Id = qao.AnswerOption.Id,
                        Answer = qao.AnswerOption.Answer
                    })
                    .ToList() ?? new List<AnswerOptionDto>()
            };
        }
    }
}
