using Cyberquiz.DAL.Data;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberquiz.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Include(c => c.SubCategories)
                    .ThenInclude(sc => sc.Questions)
                .ToListAsync();
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .Include(c => c.SubCategories)
                    .ThenInclude(sc => sc.Questions)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<SubCategoryModel>> GetAllSubCategoriesAsync()
        {
            return await _context.SubCategories
                .AsNoTracking()
                .Include(sc => sc.Category)
                .Include(sc => sc.Questions)
                .OrderBy(sc => sc.CategoryId)
                .ThenBy(sc => sc.Order)
                .ToListAsync();
        }

        public async Task<SubCategoryModel?> GetSubCategoryByIdAsync(int id)
        {
            return await _context.SubCategories
                .AsNoTracking()
                .Include(sc => sc.Category)
                .Include(sc => sc.Questions)
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }
    }
}
