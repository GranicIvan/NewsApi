using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.DTO;
using NewsApi.Model.Models;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }


        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {            
            return await _categoryService.GetAllAsync();
        }

        [HttpGet("GetCategoryById")]
        public Task<Category> GetCategoryByIdAsync(int id)
        {

            return _categoryService.GetById(id);
        }

        [HttpPost("AddCategory")]
        public  Category? AddCategoryAsync(CategoryDTO category)
        {
            return  _categoryService.AddAsync(category).Result;
        }

        [HttpPut("UpdateCategory")]
        public async Task<int> UpdateCategoryAsync(CategoryDTO category)
        {
            return await _categoryService.UpdateAsync(category);
        }


    }
}
