using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Interface;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Services
{
    // Hanterar logik för frågor och svarsalternativ
    // Kontrollerar om användaren svarar rätt eller fel på en fråga
    // Tar emot requests från API-lagret, anropar metoder i repo-lagret och returnerar DTOs till API-lagret
    // Innehåller tre metoder för att samarbeta med Endpoints i QuestionController i API-lagret
    // Innehåller just nu även en mapping-metod för att konvertera mellan Model och Dto (eventuellt flytta till egen Mapper-klass)
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IProgressService _progressService;

        public QuestionService(IQuestionRepository questionRepo, IProgressService progressService)
        {
            _questionRepo = questionRepo;
            _progressService = progressService;
        }

        // Metod för ENDPOINT "questions/{id:int}" som hämtar en enskild fråga med svarsalternativ
        public async Task<QuestionDto?> GetQuestionByIdAsync(int questionId)
        {
            // Anropar repo med frågans id som argument (repot packar varje fråga med fyra svaralternativ)
            var question = await _questionRepo.GetQuestionByIdAsync(questionId);
            // Returnerar DTO för frågan eller null om frågan inte hittas
            return question == null ? null : MapToQuestionDto(question);
        }

        // METOD SOM INTE ANVÄNDS I NUVARANDE VERSION
        //// Metod för ENDPOINT "subcategory/{subCategoryId:int}/questions" som hämtar alla frågor inom en underkategori
        //public async Task<IEnumerable<QuestionDto>> GetQuestionBySubCategoryAsync(int subCategoryId)
        //{
        //    var questions = await _questionRepo.GetQuestionsBySubCategoryAsync(subCategoryId);
        //    return questions.Select(qs => MapToQuestionDto(qs));
        //}

        // Metod för ENDPOINT "subcategory/{subCategoryId:int}/next" som hämtar nästa fråga inom underkategori utifrån användarens tidigare svar och framsteg
        public async Task<QuestionDto?> GetNextQuestionInSubCategoryAsync(int subCategoryId)
        {
            // Hämta alla frågor inom underkategorin
            var allQuestions = await _questionRepo.GetQuestionsBySubCategoryAsync(subCategoryId);
            // Hämta de frågor som användaren redan har svarat på i underkategorin
            var answeredQuestionIds = await _progressService.GetAnsweredQuestionIdsAsync(userName, subCategoryId);
            // Hitta nästa (= första) frågan som användaren inte har svarat på
            var nextQuestion = allQuestions.FirstOrDefault(q => !answeredQuestionIds.Contains(q.Id));
            // Returnera DTO för nästa fråga eller null om alla frågor redan är besvarade
            return nextQuestion == null ? null : MapToQuestionDto(nextQuestion); // Om inga svar 
        } 

        // Metod för ENDPOINT "answer" som tar emot användarens svar och uppdaterar framsteg
        public async Task<SubmitResponseDto> SaveUserAnswerAsync(SubmitAnswerRequestDto request) // Ska detta skickas till SaveUserAnswerAsync i IProgressRepo? 
        {
            // Hämta frågan
            var question = await _questionRepo.GetQuestionByIdAsync(request.QuestionId);
            // Om frågan inte hittas
            if (question == null)
            {
                throw new Exception("Frågan kunde inte hittas.");
            }
            // (Annars) Kolla om användaren valt rätta svaret till den frågan
            var correctAnswerOption = question.QuestionAnswerOptions?
                .FirstOrDefault(qao => qao.AnswerOptionId == request.AnswerOptionId);
            if (correctAnswerOption == null) 
            { 
                throw new Exception("Rätt svar kunde inte hittas."); 
            }
            // Annars hämta svarets id
            bool isCorrect = correctAnswerOption.AnswerOptionId == request.AnswerOptionId;
            // Spara användarens svar enligt modell
            var userAnswer = new UserAnswerModel
            {
                UserName = userName,
                QuestionId = request.QuestionId,
                AnswerOptionId = request.AnswerOptionId,
                IsCorrect = isCorrect,
                AnsweredAt = DateTime.UtcNow,
            };
            // ...och uppdatera framsteg
            await _progressService.SaveUserAnswerAsync(userAnswer);
            // ... samt returnera resultatet till användaren
            return new SubmitResponseDto
            {
                IsCorrect = isCorrect,
                CorrectAnswerOptionId = correctAnswerOption.AnswerOptionId
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
