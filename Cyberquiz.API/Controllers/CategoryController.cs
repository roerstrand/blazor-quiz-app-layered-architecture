
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    
    public class CategoryController : Controller
    {
        // Senare: injicera BLL-service här
        // private readonly ICategoryService _service;
        // public CategoriesController(ICategoryService service) => _service = service;

        // GET api/categories/overview
        [HttpGet("overview")]
        public ActionResult<List<CategoryDto>> GetOverview()
        {
            // DUMMY DATA (för Swagger/UI-test). Byt mot BLL senare.
            var data = new List<CategoryDto>
        {
            new()
            {
                Id = 1,
                Name = "Nätverk",
                CompletedSubCategories = 1,
                TotalSubCategories = 3,
                SubCategories = new List<SubCategoryDto>
                {
                    new() { Id = 101, Name = "TCP/IP", CategoryName = "Nätverk", Order = 1, IsLocked = false, IsCompleted = true },
                    new() { Id = 102, Name = "DNS",   CategoryName = "Nätverk", Order = 2, IsLocked = false, IsCompleted = false },
                    new() { Id = 103, Name = "TLS",   CategoryName = "Nätverk", Order = 3, IsLocked = true,  IsCompleted = false }
                }
            },
            new()
            {
                Id = 2,
                Name = "Webbsäkerhet",
                CompletedSubCategories = 0,
                TotalSubCategories = 2,
                SubCategories = new List<SubCategoryDto>
                {
                    new() { Id = 201, Name = "OWASP Top 10", CategoryName = "Webbsäkerhet", Order = 1, IsLocked = false, IsCompleted = false },
                    new() { Id = 202, Name = "XSS",         CategoryName = "Webbsäkerhet", Order = 2, IsLocked = true,  IsCompleted = false }
                }
            }
        };

            return Ok(data);
        }

        // GET api/categories/{categoryId}/subcategories
        [HttpGet("{categoryId:int}/subcategories")]
        public ActionResult<List<SubCategoryDto>> GetSubCategories(int categoryId)
        {
            // DUMMY: i riktig version hämtar ni från BLL/DB baserat på categoryId + user progression
            var subs = new List<SubCategoryDto>
        {
            new() { Id = 101, Name = "TCP/IP", CategoryName = "Nätverk", Order = 1, IsLocked = false, IsCompleted = true },
            new() { Id = 102, Name = "DNS", CategoryName = "Nätverk", Order = 2, IsLocked = false, IsCompleted = false },
            new() { Id = 103, Name = "TLS", CategoryName = "Nätverk", Order = 3, IsLocked = true, IsCompleted = false }
        };

            return Ok(subs);
        }
        //// TODO: Injicera ICategoryService när den är implementerad

        ////GET: /api/categories
        //[HttpGet]
        //public ActionResult<List<CategoryDto>> GetCategories()
        //{
        //    // TODO: return await _categoryService.GetCategoriesAsync(User.Identity?.Name ?? "user");
        //    return Ok(new List<CategoryDto>());
        //}

        //// GET api/categories/{categoryId}/subcategories
        //[HttpGet("{categoryId}/subcategories")]
        //public ActionResult<List<SubCategoryDto>> GetSubCategoriesByCategoryId(int categoryId)
        //{
        //    // TODO: return await _categoryService.GetSubCategoriesByCategoryIdAsync(categoryId, User.Identity?.Name ?? "user");
        //    return Ok(new List<SubCategoryDto>());
        //}
    }
}
