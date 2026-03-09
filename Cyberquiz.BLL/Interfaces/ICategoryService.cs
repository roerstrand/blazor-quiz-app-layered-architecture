using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string userName); 
        Task<CategoryDto?> GetCategoryByIdAsync(string userName, int categoryId);

        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(string userName);
        Task<SubCategoryDto?> GetSubCategoryByIdAsync(string userName, int id); 
    }
}
