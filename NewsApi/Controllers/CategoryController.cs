using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.DTO;
using NewsApi.Model.Models;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [Authorize]
    [ApiVersion(1)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/v{v:apiVersion}/[controller]/")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }


        [MapToApiVersion(1)]
        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {            
            return await _categoryService.GetAllAsync();
        }

        [MapToApiVersion(1)]
        [HttpGet("GetCategoryById")]
        public Task<Category> GetCategoryByIdAsync(int id)
        {

            return _categoryService.GetById(id);
        }

        [MapToApiVersion(1)]
        [HttpPost("AddCategory")]
        public  Category? AddCategoryAsync(CategoryDTO category)
        {
            return  _categoryService.AddAsync(category).Result;
        }

        [MapToApiVersion(1)]
        [HttpPut("UpdateCategory")]
        public async Task<int> UpdateCategoryAsync(CategoryDTO category)
        {
            return await _categoryService.UpdateAsync(category);
        }

        [MapToApiVersion(2)]
        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<string>> GetCategoriesAsyncV2()
        {
            return (await _categoryService.GetAllAsync()).Select(x => x.Name);
        }

    }
}
