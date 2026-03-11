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

        // Hämtar en enskild fråga med alla svarsalternativ
        public async Task<QuestionModel?> GetQuestionByIdAsync(int questionId) // Döpa om till questionId
        {
            return await _context.Questions
                .AsNoTracking()
                .Include(q => q.QuestionAnswerOptions)
                    .ThenInclude(qao => qao.AnswerOption)
                .FirstOrDefaultAsync(q => q.Id == questionId);
        }

        // Hämtar alla frågor kopplade till en subkategori — används bl.a. för 80%-beräkning i BLL
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
