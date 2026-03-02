using Cyberquiz.BLL.DummyFilesBLL;
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    [Authorize]
    public class CategoryController : Controller
    {
        // TODO: Injicera ICategoryService när den är implementerad

        //GET: /api/categories
        [HttpGet]
        public ActionResult<List<CategoryDto>> GetCategories()
        {
            // TODO: return await _categoryService.GetCategoriesAsync(User.Identity?.Name ?? "user");
            return Ok(new List<CategoryDto>());
        }

        // GET api/categories/{categoryId}/subcategories
        [HttpGet("{categoryId}/subcategories")]
        public ActionResult<List<SubCategoryDto>> GetSubCategoriesByCategoryId(int categoryId)
        {
            // TODO: return await _categoryService.GetSubCategoriesByCategoryIdAsync(categoryId, User.Identity?.Name ?? "user");
            return Ok(new List<SubCategoryDto>());
        }
    }
}
