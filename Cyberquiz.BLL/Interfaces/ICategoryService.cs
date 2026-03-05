using Cyberquiz.Shared.DTOs;

namespace Cyberquiz.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(); //Behöver ev. string username som paramater
        Task<CategoryDto?> GetCategoryByIdAsync(int id);

        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync();
        Task<SubCategoryDto?> GetSubCategoryByIdAsync(int id); //Behöver ev. string username och int id som paramater
    }
}
