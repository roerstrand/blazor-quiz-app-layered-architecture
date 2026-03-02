using Cyberquiz.BLL.DummyFilesBLL;
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Repositories;
using Cyberquiz.Shared.DTOs;
using Cyberquiz.Shared.DTOs.Progress;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mono.TextTemplating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.BLL.Services
{
    // Beroende av fråge-repo och användarens tidigare resultat
    // Flödeslogik för att visa quiz för användaren
    // Starta quiz
    // Ta emot och validera svar
    // Kolla resultat
    // Säkerställa att quiz får startas
    public class QuizService : IQuizService
    {
        private readonly IQRepo _questionRepo;
        private readonly IProgressService _progressService;
        private readonly IResultService _resultService;

        public QuizService(IQRepo questionRepo, IProgressService progressService, IResultService resultService)
        {
            _questionRepo = questionRepo;
            _progressService = progressService;
            _resultService = resultService;
        }

        // Metod för att hämta frågor med svarsalternativ för en subkategori
        public async Task<List<QuestionDto>> GetQuestionsBySubCategoryAsync(int subCategoryId, string userId)
        {
            // Kolla om användaren har tillgång till subkategorin
            var isUnlocked = await _progressService.IsSubCategoryUnlockedAsync(userId, subCategoryId);
            if (!isUnlocked)
            {
                throw new UnauthorizedAccessException("Subkategorin är inte upplåst");
            }

            // Hämta frågor från repository
            var questions = await _questionRepo.GetBySubCategoryIdAsync(subCategoryId);

            // Slumpa ordning
            var shuffledQs = questions.OrderBy(q => Guid.NewGuid()).ToList();

            // Mappa till DTO
            return MapToQuestionDtos(shuffledQs);
        }

        private List<QuestionDto> MapToQuestionDtos(List<QuestionModel> questions)
        {
            return questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Question = q.Question,
                AnswerOptions = q.QuestionAnswerOptions.Select(qao => new AnswerOptionDto
                {
                    Id = qao.AnswerOptionId,
                    Answer = qao.AnswerOption.Answer
                    // IsCorrect skickas INTE till frontend
                }).ToList()
            }).ToList();
        }

        // Metod för att starta ett quiz
        public async Task<QuizDto> StartQuizAsync(int subCategoryId, string userId)
        {
            var questions = await GetQuestionsBySubCategoryAsync(subCategoryId, userId);

            return new QuizDto
            {
                SubCategoryId = subCategoryId,
                Questions = questions,
                //TotalQuestions = questions.Count
            };
        }

        // Metod för att skicka in ett svar
        public async Task<SubmitResponseDto> SubmitAnswerRequestAsync(string userId, int questionId, int selectedOptionId)
        {
            // QuizService skickar vidare till ResultService 
            var isCorrect = await _resultService.SubmitAnswerAsync(userId, questionId, selectedOptionId);

            // Skicka med info om svaret är rätt
            return new SubmitResponseDto
            {
                IsCorrect = isCorrect
            };
        }
    }
}
