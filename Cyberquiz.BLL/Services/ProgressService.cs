using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Services
{
    // Reglerar åtkomst
    // Använder QuestionService för att hämta information om användarens resultat - ELLER???
    // Innehåller fem metoder för att samarbeta med Endpoints i ProgressController i API-lagret
    // Innehåller två metoder med affärslogik för att beräkna användarens framgångsprocent och avgöra om en underkategori är godkänd
    // Innehåller två metoder för att hantera GDPR och databasrensning, som inte är kopplade till några endpoints
    // Innehåller just nu även mapping-metoder för att konvertera mellan Model och Dto (eventuellt flytta till egen Mapper-klass)
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepo;

        public ProgressService(IProgressRepository progressRepo)
        {
            _progressRepo = progressRepo;
        }

        // Metod för ENDPOINT "progress/subcategory/{subCategoryId:int}" som hämtar användarens framsteg inom en underkategori
        public async Task<UserProgressDto?> GetByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            // Anropar metod i repo, användarnamn och underkategori-id som argument
            var progress = await _progressRepo.GetByUserAndSubCategoryAsync(userName, subCategoryId);
            // Mappar Dto till Model
            return progress == null ? null : MapToUserProgressDto(progress); 
        }

        // Metod för ENDPOINT "progress/user/{userName}" som hämtar alla framsteg för en användare
        public async Task<IEnumerable<UserProgressDto>> GetAllByUserAsync(string userName)
        {
            // Anropar metod i repo, användarnamn som argument
            var progressList = await _progressRepo.GetAllByUserAsync(userName);
            // Mappar om hela listan av dto's till model
            return progressList.Select(pl => MapToUserProgressDto(pl)); 
        }

        // Metod för ENDPOINT "progress" som sparar användarens framsteg
        public async Task SaveProgressAsync(UserProgressDto progress)
        {
            // Mappar Dto till Model
            var progressModel = MapToUserProgressModel(progress);
            // Anropar metod i repo, modell som argument
            await _progressRepo.SaveProgressAsync(progressModel); 
        }

        // Metod för ENDPOINT [HttpPost("answer")] som sparar användarens svar 

        // Metod för ENDPOINT [HttpGet("subcategory/{subCategoryId:int}/answers")]
        // ...som hämtar alla svar som sparats för en användare inom en underkategori
        // ...och filtrerar med LINQ-select för den aktuella användaren och underkategorin
        public async Task<IEnumerable<SubmitAnswerRequestDto>> GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            // Anropar metod i repo, användarnamn och underkategori-id som argument
            var answers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            // Mappar om hela listan av dto's till model
            return answers.Select(ans => MapToSubmitAnswerRequestDto(ans)); 
        }

        // Metod för att hämta alla frågor som användaren har svarat på inom en underkategori (för att kunna filtrera bort dem när nästa fråga hämtas)
        public async Task<HashSet<int>> GetAnsweredQuestionIdsAsync(string userName, int subCategoryId)
        {
            // Anropa metod i repo, användarnamn och underkategori-id som argument
            var userAnswers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            // Returnerar en hashset med alla fråge-id:n som användaren har svarat på inom underkategorin, så att det går snabbt att kolla om en fråga redan är besvarad eller inte
            return userAnswers
                .Select(a => a.QuestionId)
                .ToHashSet();
        }

        // Metod för att spara användarens svar (för att kunna visa det i användarprofilen och för att beräkna framgångsprocenten)
        public async Task SaveUserAnswerAsync(SubmitAnswerRequestDto answer, string userName)
        {
            var progress = await _progressRepo.GetByUserAndSubCategoryAsync(userName, answer.SubCategoryId);

            if (progress == null)
            {
                progress = new UserProgressModel
                {
                    UserName = userName,
                    SubCategoryId = answer.SubCategoryId,
                    Score = 0,
                    TotalQuestions = 0,
                    CompletedAt = DateTime.UtcNow
                };
                await _progressRepo.SaveProgressAsync(progress);
            }

            var answerModel = MapToUserAnswerModel(answer);
            answerModel.UserName = userName;
            answerModel.UserProgressId = progress.Id;

            await _progressRepo.SaveUserAnswerAsync(answerModel);
        }

        // Metod för att ta bort alla svar och framsteg för en användare (GDPR/admin)
        public async Task DeleteAllProgressForUserAsync(string userName)
        {
            // Anropar metod i repo med användarnamn som argument
            await _progressRepo.DeleteByUserAsync(userName);
        }

        // Metod för att behålla de X senaste resultaten och ta bort resten (DB-rensning)
        public async Task KeepRecentProgressForUserAsync(string userName, int maxSavedInstances)
        {
            // Anropar metod i repo för att hämta framsteg med användarnamn som argument
            var allProgress = await _progressRepo.GetAllByUserAsync(userName);
            var progressToDelete = allProgress
                .OrderByDescending(p => p.CompletedAt) // sorterar efter datum 
                .Skip(maxSavedInstances) // och tar bort de äldsta utifrån maxSavedInstances
                .ToList(); // konverterar till lista för att kunna iterera (foreach) över den
            foreach (var progress in progressToDelete)
            {
                // Anropar metod i repo för att ta bort framsteg med användarnamn och maxSavedInstances som argument
                await _progressRepo.DeleteOldestByUserAsync(progress.UserName, maxSavedInstances);
            }
        }

        // Metod för att beräkna användarens framgångsprocent inom en underkategori
        public async Task<double> CalculateSuccessRateAsync(string userName, int subCategoryId)
        {
            // Anropar metod i repo, användarnamn och underkategori-id som argument
            var answers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);
            // Om inga svar för användaren och underkategorin finns, returnera 0% framgång
            if (!answers.Any())
                return 0;

            double correct = answers.Count(a => a.IsCorrect); // Antal rätta svar 
            double total = answers.Count(); // Totala antalet svar

            return (correct / total) * 100; // Returnerar beräkning
        }

        // Metod för att avgöra om en underkategori är godkänd baserat på framgångsprocenten
        public async Task<bool> IsSubCategoryCompletedAsync(string userName, int subCategoryId)
        {
            // Anropar metod ovan, med användarnamn och underkategori-id som argument
            double successRate = await CalculateSuccessRateAsync(userName, subCategoryId);
            return successRate >= 80; // 80% godkänd-gräns (funkar dåligt om vi endast har fyra frågor per kategori - kan få antingen 75% eller 100%)
        }

        // Mapping från Model till Dto
        private UserProgressDto MapToUserProgressDto(UserProgressModel model)
        {
            return new UserProgressDto
            {
                Id = model.Id,
                UserName = model.UserName,
                SubCategoryId = model.SubCategoryId,
                SubCategoryName = model.SubCategory?.Name ?? string.Empty,
                Score = model.Score,
                TotalQuestions = model.TotalQuestions,
                CompletedAt = model.CompletedAt
            };
        }

        // Mapping från Dto till Model
        private UserProgressModel MapToUserProgressModel(UserProgressDto dto)
        {
            return new UserProgressModel
            {
                Id = dto.Id,
                UserName = dto.UserName,
                SubCategoryId = dto.SubCategoryId,
                Score = dto.Score,
                TotalQuestions = dto.TotalQuestions,
                CompletedAt = dto.CompletedAt
            };
        }

        private SubmitAnswerRequestDto MapToSubmitAnswerRequestDto(UserAnswerModel model)
        {
            return new SubmitAnswerRequestDto
            {
                SubCategoryId = model.Question?.SubCategoryId ?? 0,
                QuestionId = model.QuestionId,
                AnswerOptionId = model.AnswerOptionId
            };
        }

        private UserAnswerModel MapToUserAnswerModel(SubmitAnswerRequestDto dto)
        {
            return new UserAnswerModel
            {
                QuestionId = dto.QuestionId,
                AnswerOptionId = dto.AnswerOptionId
            };
        }
    }
}
