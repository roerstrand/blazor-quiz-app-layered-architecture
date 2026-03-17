using Cyberquiz.BLL.Interfaces;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Models;
using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProgressService _progressService;

        public CategoryService(ICategoryRepository categoryRepo, IProgressService progressService)
        {
            _categoryRepo = categoryRepo;
            _progressService = progressService;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string? userName)
        {
            var categories = await _categoryRepo.GetAllCategoriesAsync();
            var result = new List<CategoryDto>();

            foreach (var category in categories)
            {
                var dto = MapToCategoryDto(category);

                if (!string.IsNullOrEmpty(userName))
                {
                    var subs = dto.SubCategories.OrderBy(s => s.Order).ToList();
                    for (int i = 0; i < subs.Count; i++)
                    {
                        subs[i].IsCompleted = await _progressService.IsSubCategoryCompletedAsync(userName, subs[i].Id);
                        subs[i].IsLocked = i > 0 && !subs[i - 1].IsCompleted;
                    }
                    dto.CompletedSubCategories = subs.Count(s => s.IsCompleted);
                }

                result.Add(dto);
            }

            return result;
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int categoryId)
        {
            // Calls repo with category id as argument
            var category = await _categoryRepo.GetCategoryByIdAsync(categoryId);
            // If category not found, return null, otherwise map to CategoryDto
            return category == null ? null : MapToCategoryDto(category);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(string? userName)
        {
            var subCategories = await _categoryRepo.GetAllSubCategoriesAsync();
            var result = new List<SubCategoryDto>();

            if (string.IsNullOrEmpty(userName))
            {
                // If no user, return without lock logic
                return subCategories.Select(scs => MapToSubCategoryDto(scs));
            }

            // Group
            var groupedByCategory = subCategories
                .Where(s => s.Category != null) // Filter out subcategories without a category
                .GroupBy(s => s.Category!.Name)
                .OrderBy(g => g.Key);

            foreach (var categoryGroup in groupedByCategory)
            {
                // Sort subcategories within the category by Order
                var subs = categoryGroup.OrderBy(s => s.Order).ToList();

                for (int i = 0; i < subs.Count; i++)
                {
                    var dto = MapToSubCategoryDto(subs[i]);

                    // Calculate IsCompleted
                    dto.IsCompleted = await _progressService.IsSubCategoryCompletedAsync(userName, dto.Id);

                    // First in each category is not locked; rest are locked if the previous is not completed
                    dto.IsLocked = i > 0 && !result[result.Count - 1].IsCompleted;

                    result.Add(dto);
                }
            }

            return result;
        }

        public async Task<SubCategoryDto?> GetSubCategoryByIdAsync(int subCategoryId)
        {
            // Calls repo with subcategory id as argument
            var subCategory = await _categoryRepo.GetSubCategoryByIdAsync(subCategoryId);
            // If subcategory not found, return null, otherwise map to SubCategoryDto
            return subCategory == null ? null : MapToSubCategoryDto(subCategory);
        }

        // Mapping methods from Model to Dto
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
                Description = model.Description,
                QuestionCount = model.QuestionCount
            };
        }
    }
}
