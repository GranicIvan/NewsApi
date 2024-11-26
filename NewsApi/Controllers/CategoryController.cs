using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.Models;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dataContext;

        public CategoryController(ILogger<WeatherForecastController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet("GetAllCategories")]
        public List<Category>? GetCategories()
        {
            CategoryRepo cr = new CategoryRepo(_dataContext);

            return cr.GetAllCategories();
        }

        [HttpGet("GetAllCategoriesAsync")]
        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            CategoryRepo cr = new CategoryRepo(_dataContext);

            return cr.GetAllCategoriesAsync();
        }







    }
}
