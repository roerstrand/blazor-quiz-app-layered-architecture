
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization; // Uttonad - Används inte?
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/categories")]

    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/categories/
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var userName = User.Identity?.Name ?? null;
            var data = await _categoryService.GetAllCategoriesAsync(); // Visar bara om ngn är inloggad
            if (data == null) return NotFound("Kategorier kunde inte hämtas");
            return Ok(data);
        }

        // GET api/categories/{categoryId}/subcategories
        [HttpGet("{categoryId:int}/subcategories")]
        public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategories(int categoryId)
        {
            var userName = User.Identity?.Name ?? null;

            if (userName == null) return NotFound();

            var data = await _categoryService.GetSubCategoryByIdAsync(categoryId); // Visar bara om ngn är inloggad
            if (data == null) return NotFound("Underkategorier kunde inte hämtas.");
            return Ok(data);
        }

        // GET api/categories/subcategories
        [HttpGet("subcategories")] // ✅ Ingen categoryId
        public async Task<ActionResult<List<SubCategoryDto>>> GetAllSubCategories()
        {
            var userName = User.Identity?.Name ?? null;
            var data = await _categoryService.GetAllSubCategoriesAsync();
            return Ok(data);
        }



    }
}
