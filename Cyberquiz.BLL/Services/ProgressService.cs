using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Services
{
    // Reglerar åtkomst
    // Använder ResultsService för att hämta information om användarens resultat
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
            var progress = await _progressRepo.GetByUserAndSubCategoryAsync(userName, subCategoryId);
            return progress == null ? null : MapToUserProgressDto(progress);
        }

        // Metod för ENDPOINT "progress/user/{userName}" som hämtar alla framsteg för en användare
        public async Task<IEnumerable<UserProgressDto>> GetAllByUserAsync(string userName)
        {
            var progressList = await _progressRepo.GetAllByUserAsync(userName);
            return progressList.Select(pl => MapToUserProgressDto(pl)); // Mappar om hela listan av dto's till model
        }

        // Metod för ENDPOINT "progress" som sparar användarens framsteg
        public async Task SaveProgressAsync(UserProgressDto progress)
        {
            var progressModel = MapToUserProgressModel(progress);
            await _progressRepo.SaveProgressAsync(progressModel);
        }

        // Metod för ENDPOINT "progress/answer" som sparar användarens svar
        public async Task SaveUserAnswerAsync(SubmitAnswerRequestDto answer)
        {
            var answerModel = MapToUserAnswerModel(answer);
            await _progressRepo.SaveUserAnswerAsync(answerModel);
        }

        // Metod för ENDPOINT "progress/answers/{userName}/{subCategoryId:int}"
        // ...som hämtar alla svar för en användare inom en underkategori
        public async Task<IEnumerable<SubmitAnswerRequestDto>> 
            GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            var answers = await _progressRepo.GetAnswersByUserAndSubCategoryAsync(userName, 
                subCategoryId);
            return answers.Select(ans => MapToSubmitAnswerRequestDto(ans));
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
            var answers = await _progressRepo
                .GetAnswersByUserAndSubCategoryAsync(userName, subCategoryId);

            if (!answers.Any())
                return 0;

            double correct = answers.Count(a => a.IsCorrect);
            double total = answers.Count();

            return (correct / total) * 100;
        }

        // Metod för att avgöra om en underkategori är godkänd baserat på framgångsprocenten
        public async Task<bool> IsSubCategoryCompletedAsync(string userName, int subCategoryId)
        {
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
