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
        public async Task<NewsArticle> GetNewsArticleByIdAsync(int id)
        {
           
            return await _newsArticleService.GetNewsArticleById(id);
        }

        [HttpPost("AddNewsArticle")]
        public async Task<NewsArticleDTO?> AddNewsArticleAsync(NewsArticleDTO newsArticle)
        {
            return await _newsArticleService.AddAsync(newsArticle);
        }

    }
}
