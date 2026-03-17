using Cyberquiz.DAL.Data;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberquiz.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        // Retrieves a single question with all answer options
        public async Task<QuestionModel?> GetQuestionByIdAsync(int questionId)
        {
            return await _context.Questions
                .AsNoTracking()
                .Include(q => q.QuestionAnswerOptions)
                    .ThenInclude(qao => qao.AnswerOption)
                .FirstOrDefaultAsync(q => q.Id == questionId);
        }

        // Retrieves all questions linked to a subcategory — used e.g. for the 80% calculation in BLL
        public async Task<IEnumerable<QuestionModel>> GetQuestionsBySubCategoryAsync(int subCategoryId)
        {
            return await _context.Questions
                .AsNoTracking()
                .Where(q => q.SubCategoryId == subCategoryId)
                .Include(q => q.QuestionAnswerOptions)
                    .ThenInclude(qao => qao.AnswerOption)
                .ToListAsync();
        }
    }
}
