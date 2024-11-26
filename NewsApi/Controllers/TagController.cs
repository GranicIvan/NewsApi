using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.Models;

namespace NewsApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dataContext;


        public TagController(ILogger<WeatherForecastController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;

        }


        [HttpGet("GetAllTags")]
        public List<Tag>? GetNewsArticlesTest()
        {


            TagRepo tr = new TagRepo(_dataContext);


            return tr.GetAll().ToList();
        }
    }
}
