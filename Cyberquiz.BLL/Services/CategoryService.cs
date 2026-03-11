using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;

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
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            // Anropar repo 
            var categories = await _categoryRepo.GetAllCategoriesAsync();
            // Mappa varje CategoryModel till CategoryDto
            return categories.Select(cs => MapToCategoryDto(cs));
        }
        // Metod som inte behövs?

        public async Task<CategoryDto?> GetCategoryByIdAsync(int categoryId)
        {
            // Anropar repo med kategori-id som argument
            var category = await _categoryRepo.GetCategoryByIdAsync(categoryId);
            // Om category inte finns, returnera null, annars mappa till CategoryDto
            return category == null ? null : MapToCategoryDto(category);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync()
        {
            // Anropa repo 
            var subCategories = await _categoryRepo.GetAllSubCategoriesAsync();
            // Mappa varje SubCategoryModel till SubCategoryDto
            return subCategories.Select(scs => MapToSubCategoryDto(scs));
        }

        public async Task<SubCategoryDto?> GetSubCategoryByIdAsync(int subCategoryId)
        {
            // Anropar repo med underkategori-id som argument
            var subCategory = await _categoryRepo.GetSubCategoryByIdAsync(subCategoryId);
            // Om subCategory inte finns, returnera null, annars mappa till SubCategoryDto
            return subCategory == null ? null : MapToSubCategoryDto(subCategory);
        }

        // Mapping-metoder från Model till Dto
        private CategoryDto MapToCategoryDto(CategoryModel model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                TotalSubCategories = model.SubCategories?.Count ?? 0,
                QuestionCount = model.QuestionCount,
                SubCategories = model.SubCategories?
                .Select(scs => MapToSubCategoryDto(scs))
                .ToList() ?? new()
            };
        }

        private SubCategoryDto MapToSubCategoryDto(SubCategoryModel model)
        {
            return new SubCategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                CategoryName = model.Category?.Name ?? string.Empty,
                Order = model.Order,
                QuestionCount = model.QuestionCount
            };
        }
    }
}