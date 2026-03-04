using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;

namespace Cyberquiz.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        // Injicerar repo
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        // Anropar metoder i repo
        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            return await _categoryRepo.GetAllCategoriesAsync();
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepo.GetCategoryByIdAsync(id);
        }

        public async Task<IEnumerable<SubCategoryModel>> GetAllSubCategoriesAsync()
        {
            return await _categoryRepo.GetAllSubCategoriesAsync();
        }

        public async Task<SubCategoryModel?> GetSubCategoryByIdAsync(int id)
        {
            return await _categoryRepo.GetSubCategoryByIdAsync(id);
        }
    }
}