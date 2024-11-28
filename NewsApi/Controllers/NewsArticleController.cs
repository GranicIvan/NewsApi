using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.Models;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsArticleController
    {
        private readonly ILogger<NewsArticleController> _logger;
        private readonly INewsArticleService _newsArticleService;

        public NewsArticleController(ILogger<NewsArticleController> logger, DataContext dataContext, INewsArticleService newsArticleService)
        {
            _logger = logger;
            _newsArticleService = newsArticleService;
        }


        [HttpGet("GetAllNewsArticles")]
        public Task<IEnumerable<NewsArticle>> GetNewsArticlesAsync()
        {
            return _newsArticleService.getAllNewsArticlesAsync();
        }

        [HttpGet("GetNewsArticleById")]
        public Task<NewsArticle> GetNewsArticleByIdAsync(int id)
        {
           
            return _newsArticleService.GetNewsArticleById(id);
        }



    }
}
