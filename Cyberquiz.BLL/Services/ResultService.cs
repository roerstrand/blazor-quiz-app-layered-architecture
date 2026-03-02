using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs.Progress;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IQuestionRepository _questionRepo;

        public ResultService(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        // Metod för att skicka in ett svar från användaren
        public async Task<bool> SubmitAnswerAsync(string userId, int questionId, int selectedOptionId)
        {
            // Hämta frågan med alla svarsalternativ
            var question = await _questionRepo.GetByIdAsync(questionId);

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

            // TODO: Spara användarens svar i databasen
            // Detta bör göras via en UserAnswerRepository
            // await _userAnswerRepo.SaveAsync(new UserAnswerModel { ... });

            return isCorrect;
        }
    }
}
