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
            _context.UserProgress.Add(progress);
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

        public async Task DeleteByUserAsync(string userName)
        {
            var answers = await _context.UserAnswers
                .Where(a => a.UserName == userName)
                .ToListAsync();
            _context.UserAnswers.RemoveRange(answers);

            var progress = await _context.UserProgress
                .Where(p => p.UserName == userName)
                .ToListAsync();
            _context.UserProgress.RemoveRange(progress);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOldestByUserAsync(string userName, int keepLatest)
        {
            var toDelete = await _context.UserProgress
                .Where(p => p.UserName == userName)
                .OrderByDescending(p => p.CompletedAt)
                .Skip(keepLatest)
                .ToListAsync();

            _context.UserProgress.RemoveRange(toDelete);
            await _context.SaveChangesAsync();
        }
    }
}