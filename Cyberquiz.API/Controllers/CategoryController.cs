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
    
    // Koppling till DummyRepo - Behöver ange "riktiga" repot
        private readonly ICatRepo _categoryRepo;

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }

        //GET: /api/categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync(User.Identity?.Name ?? "user");
            return Ok(categories);

        }

        //// GET api/categories/{categoryId}/subcategories
        [HttpGet("{categoryId}/subcategories")]
        public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCategories = await _categoryService.GetSubCategoriesByCategoryIdAsync(categoryId, User.Identity?.Name ?? "user");
            return Ok(subCategories);


        }

    }
}
