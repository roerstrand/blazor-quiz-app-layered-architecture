using Cyberquiz.DAL.Models;

namespace Cyberquiz.DAL.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<SubCategoryModel>> GetAllSubCategoriesAsync();
        Task<SubCategoryModel?> GetSubCategoryByIdAsync(int id);
    }
}
