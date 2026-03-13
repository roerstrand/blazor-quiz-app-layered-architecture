using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string? userName);
        Task<CategoryDto?> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(string? userName);
        Task<SubCategoryDto?> GetSubCategoryByIdAsync(int subCategoryId);
    }
}
