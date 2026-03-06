using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Interface;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;

namespace Cyberquiz.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IProgressRepository _progressRepo; 
        public QuestionService(IQuestionRepository questionRepo, IProgressRepository progressRepo)
        {
            _questionRepo = questionRepo;
            _progressRepo = progressRepo;
        }

        // Metod för ENDPOINT "subcategory/{subCategoryId:int}/questions" som hämtar alla frågor inom en underkategori
        public async Task<IEnumerable<QuestionDto>> GetBySubCategoryAsync(int subCategoryId)
        {
            var questions = await _questionRepo.GetBySubCategoryAsync(subCategoryId);
            return questions.Select(MapToQuestionDto);
        }

        // Metod för ENDPOINT "questions/{id:int}" som hämtar en enskild fråga med svarsalternativ
        public async Task<QuestionDto?> GetByIdAsync(int id)
        {
            var question = await _questionRepo.GetByIdAsync(id);
            return question == null ? null : MapToQuestionDto(question);
        }

        // Metod för ENDPOINT "subcategory/{subCategoryId:int}/next" som hämtar nästa fråga inom underkategori utifrån användarens tidigare svar och framsteg
        public async Task<QuestionDto?> GetNextQuestionAsync(string userName, int subCategoryId)
        {
            // Hämta alla frågor inom underkategorin
            var allQuestions = await _questionRepo.GetBySubCategoryAsync(subCategoryId);
            // Hämta användarens framsteg hittills inom underkategorin
            var userProgress = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            // Hämta de frågor som användaren redan har svarat på i underkategorin
            var answeredQuestionIds = userProgress.Select(up => up.QuestionId).ToHashSet();
            // Hitta nästa (= första) frågan som användaren inte har svarat på
            var nextQuestion = allQuestions.FirstOrDefault(q => !answeredQuestionIds.Contains(q.Id));
            // Returnera DTO för nästa fråga eller null om alla frågor redan är besvarade
            return nextQuestion == null ? null : MapToQuestionDto(nextQuestion); // Vet programmet vad det ska göra när en underkategori är klar? Slussa tillbaka till Categori-översikt?
        }

        // Metod för ENDPOINT "answer" som tar emot användarens svar och uppdaterar framsteg
        public async Task<SubmitResponseDto> SubmitAnswerAsync(string userName, SubmitAnswerRequestDto request) // Ska detta skickas till SaveUserAnswerAsync i IProgressRepo? 
        {
            var result = await _questionRepo.SubmitAnswerAsync(userName, request); // Behöver fångas upp i Repo! 
            return new SubmitResponseDto
            {
                IsCorrect = result.IsCorrect, 
                CorrectAnswerOptionId = result.CorrectAnswerOptionId
            };
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
