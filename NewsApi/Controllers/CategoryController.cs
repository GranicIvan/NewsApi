﻿using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
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


    }
}
