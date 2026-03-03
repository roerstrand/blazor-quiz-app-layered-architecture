using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs.Progress;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberquiz.BLL.Services
{
    public class ResultService : IResultService
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IQuizRepository _quizRepo;

        public ResultService(IQuestionRepository questionRepo, IQuizRepository quizRepo)
        {
            _questionRepo = questionRepo;
            _quizRepo = quizRepo;
        }

        // Metod för att spara ett enskilt svar från användaren
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

            // Spara användarens svar i databasen
            await _quizRepo.SaveUserAnswerAsync(new UserAnswerModel
            {
                UserName = userId,
                QuestionId = questionId,
                AnswerOptionId = selectedOptionId,
                IsCorrect = isCorrect,
                AnsweredAt = DateTime.UtcNow
            });

            return isCorrect;
        }

        // Metod för att slutföra quiz och spara progress i UserProgressModel
        public async Task CompleteQuizAsync(string userId, int subCategoryId)
        {
            // Hämta alla användarens svar för denna subkategori
            var userAnswers = await _quizRepo.GetUserAnswersBySubCategoryAsync(userId, subCategoryId);

            // Beräkna resultat
            var totalQuestions = userAnswers.Count();
            var score = userAnswers.Count(ua => ua.IsCorrect);

            // Spara progress
            await _quizRepo.SaveUserProgressAsync(new UserProgressModel
            {
                UserName = userId,
                SubCategoryId = subCategoryId,
                Score = score,
                TotalQuestions = totalQuestions,
                CompletedAt = DateTime.UtcNow
            });
        }
    }
}
}
