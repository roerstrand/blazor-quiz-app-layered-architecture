
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
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
            var userName = User.Identity?.Name ?? "user";
            var data = await _categoryService.GetAllCategoriesAsync(userName); // Visar bara kategorier om ngn är inloggad
            return Ok(data);
        }
        

        // GET api/categories/{categoryId}/subcategories
        [HttpGet("{categoryId:int}/subcategories")]
        public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategories (int categoryId)
        {
            var userName = User.Identity?.Name ?? "user";
            var data = await _categoryService.GetSubCategoryByIdAsync(userName, categoryId);
            return Ok(data);
        }
        


        //DUMMY DATA (ta bort när ni har riktig data från BLL)-----------------------------------------------------------

        // GET api/categories
        //    [HttpGet]
        //    public ActionResult<List<CategoryDto>> GetCategories()
        //    {
        //        var data = new List<CategoryDto>
        //    {
        //        new CategoryDto
        //        {
        //            Id = 1,
        //            Name = "Nätverk",
        //            CompletedSubCategories = 1,
        //            TotalSubCategories = 3,
        //            SubCategories = new List<SubCategoryDto>
        //            {
        //                new SubCategoryDto
        //                {
        //                    Id = 101,
        //                    Name = "TCP/IP",
        //                    Description = "Grunderna i hur internettrafik transporteras.",
        //                    CategoryName = "Nätverk",
        //                    Order = 1,
        //                    IsLocked = false,
        //                    IsCompleted = true,
        //                    QuestionCount = 5
        //                },
        //                new SubCategoryDto
        //                {
        //                    Id = 102,
        //                    Name = "DNS",
        //                    Description = "Domännamn → IP-adress och vanliga attacker (spoofing).",
        //                    CategoryName = "Nätverk",
        //                    Order = 2,
        //                    IsLocked = false,
        //                    IsCompleted = false,
        //                    QuestionCount = 4
        //                },
        //                new SubCategoryDto
        //                {
        //                    Id = 103,
        //                    Name = "TLS",
        //                    Description = "Certifikat, HTTPS och krypterade anslutningar.",
        //                    CategoryName = "Nätverk",
        //                    Order = 3,
        //                    IsLocked = true,
        //                    IsCompleted = false,
        //                    QuestionCount = 6
        //                }
        //            }
        //        },
        //        new CategoryDto
        //        {
        //            Id = 2,
        //            Name = "Webbsäkerhet",
        //            CompletedSubCategories = 0,
        //            TotalSubCategories = 2,
        //            SubCategories = new List<SubCategoryDto>
        //            {
        //                new SubCategoryDto
        //                {
        //                    Id = 201,
        //                    Name = "OWASP Top 10",
        //                    Description = "Överblick över de vanligaste webbsårbarheterna.",
        //                    CategoryName = "Webbsäkerhet",
        //                    Order = 1,
        //                    IsLocked = false,
        //                    IsCompleted = false,
        //                    QuestionCount = 5
        //                },
        //                new SubCategoryDto
        //                {
        //                    Id = 202,
        //                    Name = "XSS",
        //                    Description = "Cross-site scripting: reflekterad, lagrad och DOM-baserad.",
        //                    CategoryName = "Webbsäkerhet",
        //                    Order = 2,
        //                    IsLocked = true,
        //                    IsCompleted = false,
        //                    QuestionCount = 4
        //                }
        //            }
        //        }
        //    };

        //        return Ok(data);
        //    }

        //    // GET api/categories/{categoryId}/subcategories
        //    [HttpGet("{categoryId:int}/subcategories")]
        //    public ActionResult<List<SubCategoryDto>> GetSubCategories(int categoryId)
        //    {
        //        // Returnera “rätt” lista beroende på categoryId
        //        if (categoryId == 1)
        //        {
        //            return Ok(new List<SubCategoryDto>
        //        {
        //            new() { Id = 101, Name = "TCP/IP", Description = "Grunderna i TCP/IP.", CategoryName = "Nätverk", Order = 1, IsLocked = false, IsCompleted = true, QuestionCount = 5 },
        //            new() { Id = 102, Name = "DNS",   Description = "Domännamn → IP.",     CategoryName = "Nätverk", Order = 2, IsLocked = false, IsCompleted = false, QuestionCount = 4 },
        //            new() { Id = 103, Name = "TLS",   Description = "HTTPS och certifikat.", CategoryName = "Nätverk", Order = 3, IsLocked = true,  IsCompleted = false, QuestionCount = 6 },
        //        });
        //        }

        //        if (categoryId == 2)
        //        {
        //            return Ok(new List<SubCategoryDto>
        //        {
        //            new() { Id = 201, Name = "OWASP Top 10", Description = "Vanliga webbsårbarheter.", CategoryName = "Webbsäkerhet", Order = 1, IsLocked = false, IsCompleted = false, QuestionCount = 5 },
        //            new() { Id = 202, Name = "XSS",         Description = "Cross-site scripting.",   CategoryName = "Webbsäkerhet", Order = 2, IsLocked = true,  IsCompleted = false, QuestionCount = 4 },
        //        });
        //        }

        //        return Ok(new List<SubCategoryDto>());
        //    }
    }
}
