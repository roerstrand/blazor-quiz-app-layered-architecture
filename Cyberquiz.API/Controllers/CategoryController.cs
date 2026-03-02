using Cyberquiz.DAL.Interface;
using Cyberquiz.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberquiz.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IQuizRepository _quizRepo;
        public CategoryController(IQuizRepository quizRepo)
        {
            _quizRepo = quizRepo;
        }
        // GET-anrop för att hämta alla kategorier
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            // TODO: Implementera när CategoryRepository finns
            // var categories = await _categoryRepo.GetAllAsync();
            // return Ok(categories.Select(c => MapToCategoryDto(c)));

            return Ok(new List<CategoryDto>());
        }
        // GET-anrop för att hämta alla subkategorier för en specifik kategori
        [HttpGet("{categoryId}/subcategories")]
        public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategoriesByCategoryId(int categoryId)
        {
            // TODO: Implementera när SubCategoryRepository finns
            // var subCategories = await _subCategoryRepo.GetByCategoryIdAsync(categoryId);
            // return Ok(subCategories.Select(sc => MapToSubCategoryDto(sc)));

            return Ok(new List<SubCategoryDto>());
        }
    }
}
