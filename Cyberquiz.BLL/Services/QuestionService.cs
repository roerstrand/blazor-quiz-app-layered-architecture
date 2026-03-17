using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Models;
using Cyberquiz.DAL.Interface;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Services
{
    // Handles logic for questions and answer options
    // Checks whether the user answers a question correctly or incorrectly
    // Receives requests from the API layer, calls methods in the repo layer, and returns DTOs to the API layer
    // Contains three methods to cooperate with endpoints in QuestionController in the API layer
    // Currently also contains a mapping method to convert between Model and Dto (consider moving to a dedicated Mapper class)
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IProgressService _progressService;

        public QuestionService(IQuestionRepository questionRepo, IProgressService progressService)
        {
            _questionRepo = questionRepo;
            _progressService = progressService;
        }

        // Method for ENDPOINT "questions/{id:int}" — retrieves a single question with answer options
        public async Task<QuestionDto?> GetQuestionByIdAsync(int questionId)
        {
            // Calls repo with the question's id as argument (repo packs each question with four answer options)
            var question = await _questionRepo.GetQuestionByIdAsync(questionId);
            // Returns DTO for the question or null if the question is not found
            return question == null ? null : MapToQuestionDto(question);
        }

        // METHOD NOT USED IN CURRENT VERSION
        //// Method for ENDPOINT "subcategory/{subCategoryId:int}/questions" — retrieves all questions within a subcategory
        //public async Task<IEnumerable<QuestionDto>> GetQuestionBySubCategoryAsync(int subCategoryId)
        //{
        //    var questions = await _questionRepo.GetQuestionsBySubCategoryAsync(subCategoryId);
        //    return questions.Select(qs => MapToQuestionDto(qs));
        //}

        // Method for ENDPOINT "subcategory/{subCategoryId:int}/next" — retrieves the next question in a subcategory based on the user's previous answers and progress
        public async Task<QuestionDto?> GetNextQuestionInSubCategoryAsync(int subCategoryId, int progressId)
        {
            var allQuestions = await _questionRepo.GetQuestionsBySubCategoryAsync(subCategoryId);
            var answeredQuestionIds = await _progressService.GetAnsweredQuestionIdsAsync(progressId);
            var nextQuestion = allQuestions.FirstOrDefault(q => !answeredQuestionIds.Contains(q.Id));
            return nextQuestion == null ? null : MapToQuestionDto(nextQuestion);
        }

        // Method for ENDPOINT "answer" — receives the user's answer and updates progress
        public async Task<SubmitResponseDto> SaveUserAnswerAsync(SubmitAnswerRequestDto request, string userName)
        {
            // Get the question
            var question = await _questionRepo.GetQuestionByIdAsync(request.QuestionId);
            // If question not found
            if (question == null) throw new Exception("Question could not be found.");
            // Find the correct answer
            var correctAnswerOption = question.QuestionAnswerOptions?
                .FirstOrDefault(qao => qao.IsCorrect);
            if (correctAnswerOption == null) throw new Exception("Correct answer could not be found.");

            bool isCorrect = request.AnswerOptionId == correctAnswerOption.AnswerOptionId;
            request.IsCorrect = isCorrect;

            await _progressService.SaveUserAnswerAsync(request, userName);

            return new SubmitResponseDto
            {
                IsCorrect = isCorrect,
                CorrectAnswerOptionId = correctAnswerOption.AnswerOptionId
            };
        }

        // Mapping method from Model to Dto
        private QuestionDto MapToQuestionDto(QuestionModel model)
        {
            return new QuestionDto
            {
                Id = model.Id,
                Question = model.Question,
                AnswerOptions = model.QuestionAnswerOptions?
                    .OrderBy(_ => Guid.NewGuid())
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
