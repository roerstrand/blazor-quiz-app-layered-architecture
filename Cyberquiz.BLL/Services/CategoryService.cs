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