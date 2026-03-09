using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Interface;
using Cyberquiz.Shared.DTOs;

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

        // Metod för ENDPOINT "questions/{id:int}" som hämtar en enskild fråga med svarsalternativ
        public async Task<QuestionDto?> GetQuestionByIdAsync(int id)
        {
            var question = await _questionRepo.GetQuestionByIdAsync(id);
            return question == null ? null : MapToQuestionDto(question);
        }

        // METOD SOM INTE ANVÄNDS I NUVARANDE VERSION
        //// Metod för ENDPOINT "subcategory/{subCategoryId:int}/questions" som hämtar alla frågor inom en underkategori
        //public async Task<IEnumerable<QuestionDto>> GetBySubCategoryAsync(int subCategoryId, string userName)
        //{
        //    var questions = await _questionRepo.GetBySubCategoryAsync(subCategoryId, userName);
        //    return questions.Select(qs => MapToQuestionDto(qs));
        //}

        // Metod för ENDPOINT "subcategory/{subCategoryId:int}/next" som hämtar nästa fråga inom underkategori utifrån användarens tidigare svar och framsteg
        public async Task<QuestionDto?> GetNextQuestionInSubCategoryAsync(int subCategoryId, string userName) // Dela upp metoden på QuestionService och ProgressService?
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
        } // Om null så måste Controllern plocka upp det och meddela användaren

        // Flytta till ProgressService? Eller dela upp logiken så att QuestionService bara hämtar frågan och ProgressService hanterar användarens svar och framsteg?
        // Metod för ENDPOINT "answer" som tar emot användarens svar och uppdaterar framsteg
        public async Task<SubmitResponseDto> SubmitAnswerAsync(string userName, SubmitAnswerRequestDto request) // Ska detta skickas till SaveUserAnswerAsync i IProgressRepo? 
        {
            // Hämta frågan
            var question = await _questionRepo.GetByIdAsync(request.QuestionId);
            if (question == null)
            {
                throw new Exception("Frågan kunde inte hittas.");
            }
            // Kolla om användaren valt rätta svaret till den frågan
            var correctAnswerOption = question.QuestionAnswerOptions?
                .FirstOrDefault(qao => qao.AnswerOptionId == request.AnswerOptionId);
            if (correctAnswerOption == null) 
            { 
                throw new Exception("Rätt svar kunde inte hittas."); 
            }
            // Annars hämta svarets id
            bool isCorrect = correctAnswerOption.AnswerOptionId == request.AnswerOptionId;
            // Spara användarens svar
            var userAnswer = new UserAnswerModel
            {
                UserName = userName,
                QuestionId = request.QuestionId,
                AnswerOptionId = request.AnswerOptionId,
                IsCorrect = isCorrect,
                AnsweredAt = DateTime.UtcNow,
            };
            // ...och uppdatera framsteg
            await _progressRepo.SaveUserAnswerAsync(userAnswer);
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
