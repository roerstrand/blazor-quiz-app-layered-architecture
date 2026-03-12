using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string? userName);
        Task<CategoryDto?> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync();
        Task<SubCategoryDto?> GetSubCategoryByIdAsync(int subCategoryId);
    }
}
