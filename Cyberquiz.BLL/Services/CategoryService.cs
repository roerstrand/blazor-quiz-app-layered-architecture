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
            var categories = await _categoryRepo.GetAllCategoriesAsync();
            return categories.Select(MapToCategoryDto);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepo.GetCategoryByIdAsync(id);
            return category == null ? null : MapToCategoryDto(category);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync()
        {
            var subCategories = await _categoryRepo.GetAllSubCategoriesAsync();
            return subCategories.Select(MapToSubCategoryDto);
        }

        public async Task<SubCategoryDto?> GetSubCategoryByIdAsync(int id)
        {
            var subCategory = await _categoryRepo.GetSubCategoryByIdAsync(id);
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
                SubCategories = model.SubCategories?.Select(MapToSubCategoryDto).ToList() ?? new()
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