using Cyberquiz.DAL.Data;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberquiz.DAL.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly AppDbContext _context;

        public ProgressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserProgressModel?> GetByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            return await _context.UserProgress
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserName == userName && p.SubCategoryId == subCategoryId);
        }

        public async Task<IEnumerable<UserProgressModel>> GetAllByUserAsync(string userName)
        {
            return await _context.UserProgress
                .AsNoTracking()
                .Where(p => p.UserName == userName)
                .Include(p => p.SubCategory)
                .OrderBy(p => p.SubCategoryId)
                .ToListAsync();
        }

        public async Task SaveProgressAsync(UserProgressModel progress)
        {
            var existing = await _context.UserProgress
                .FirstOrDefaultAsync(p => p.UserName == progress.UserName && p.SubCategoryId == progress.SubCategoryId);

            if (existing is null)
                _context.UserProgress.Add(progress);
            else
            {
                existing.Score = progress.Score;
                existing.TotalQuestions = progress.TotalQuestions;
                existing.CompletedAt = progress.CompletedAt;
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveUserAnswerAsync(UserAnswerModel answer)
        {
            _context.UserAnswers.Add(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserAnswerModel>> GetAnswersByUserAndSubCategoryAsync(string userName, int subCategoryId)
        {
            return await _context.UserAnswers
                .AsNoTracking()
                .Where(a => a.UserName == userName && a.Question.SubCategoryId == subCategoryId)
                .Include(a => a.Question)
                .Include(a => a.AnswerOption)
                .ToListAsync();
        }
    }
}