using Cyberquiz.BLL.DummyFilesBLL;
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs.Progress;
using Cyberquiz.DAL.Models;

namespace Cyberquiz.BLL.Services
{
    // Hanterar användarnas resultat
    // Spara resultat
    // Hämta senaste resultat
    // Hämta historik
    // Räkna genomsnitt
    // Räkna procent
    public class ResultService : IResultService
    {

        private readonly IQRepo _questionRepo;
        private readonly IUserResRepo _resultRepo;

        public ResultService(IQRepo questionRepo, IUserResRepo resultRepo)
        {
            _questionRepo = questionRepo;
            _resultRepo = resultRepo;
        }

        // Metod för att skicka in ett svar från användaren
        public async Task<bool> SubmitAnswerAsync(string userId, int questionId, int selectedOptionId)
        {
            // Hämta frågan med alla svarsalternativ
            var question = await _questionRepo.GetQByIdAsync(questionId);

            if (question == null)
            {
                throw new ArgumentException($"Fråga med ID {questionId} finns inte");
            }

            // Hitta rätt svar genom att kolla IsCorrect i QuestionAnswerOptions
            var correctAnswer = question.QuestionAnswerOptions
                .FirstOrDefault(qao => qao.IsCorrect);

            if (correctAnswer == null)
            {
                throw new InvalidOperationException($"Fråga {questionId} har inget rätt svar definierat");
            }

            // Validera om användarens svar är rätt
            bool isCorrect = correctAnswer.AnswerOptionId == selectedOptionId;

            // Spara användarens svar i databasen genom att skicka det till repository
            await _resultRepo.SaveAsync(new UserAnswerModel
            {
                UserName = userId,
                QuestionId = questionId,
                AnswerOptionId = selectedOptionId,
                IsCorrect = isCorrect,
                AnsweredAt = DateTime.UtcNow
            });

            return isCorrect;
        }
    }
}
