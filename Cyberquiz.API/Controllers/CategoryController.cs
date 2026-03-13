using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [Authorize]
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
            var userName = User.Identity?.Name;
            var data = await _categoryService.GetAllCategoriesAsync(userName);
            if (data == null) return NotFound("Kategorier kunde inte hämtas");
            return Ok(data);
        }

        // GET api/categories/{categoryId}/subcategories
        [HttpGet("{categoryId:int}/subcategories")]
        public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategories(int categoryId)
        {
            var data = await _categoryService.GetSubCategoryByIdAsync(categoryId);
            if (data == null) return NotFound("Underkategorier kunde inte hämtas.");
            return Ok(data);
        }

        // GET api/categories/subcategories
        [HttpGet("subcategories")]
        public async Task<ActionResult<List<SubCategoryDto>>> GetAllSubCategories()
        {
            var data = await _categoryService.GetAllSubCategoriesAsync();
            return Ok(data);
        }
    }
}
