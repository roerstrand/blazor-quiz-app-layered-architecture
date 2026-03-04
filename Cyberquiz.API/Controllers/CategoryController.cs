
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    
    public class CategoryController : Controller
    {
        //private readonly ICategoryService _categoryService;

        //public CategoryController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<CategoryDto>>> GetAllCategoriesAsync()
        //{
        //    var userName = User.Identity?.Name ?? "user";
        //    var data = await _categoryService.GetAllCategoriesAsync();
        //    return Ok(data);
        //}
        //// GET api/categories/{categoryId}/subcategories
        //[HttpGet("{categoryId:int}/subcategories")]
        //public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategories(int categoryId)
        //{
        //    var userName = User.Identity?.Name ?? "user";
        //    var data = await _categoryService.GetSubCategoriesByCategoryIdAsync(userName, categoryId);
        //    return Ok(data);
        //}
    }
}
