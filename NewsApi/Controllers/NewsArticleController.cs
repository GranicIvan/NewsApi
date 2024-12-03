using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.DTO;
using NewsApi.Model.Enums;
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

        [HttpGet("GetActiveNewsArticles")]
        public Task<IEnumerable<NewsArticle>> GetActiveNewsArticlesAsync()
        {
            return _newsArticleService.getActiveNewsArticlesAsync();
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


        [HttpGet("GetNewsArticleByName")]
        public async Task<NewsArticle> GetNewsArticleByNameAsync(string name)
        {
            return await _newsArticleService.GetNewsArticleByName(name);
        }

        [HttpDelete("DeleteNewsArticle")]
        public async Task<int> DeleteNewsArticleAsync(int id)
        {
            return await _newsArticleService.DeleteNewsArticle(id);
        }

        [HttpPut("UpdateNewsArticle")]
        public async Task<int> UpdateNewsArticleAsync(NewsArticleDTO newsArticle)
        {
            return await _newsArticleService.UpdateNewsArticle(newsArticle);
        }

        //[HttpGet("GetNewsArticleByCategory")]

        [HttpGet("GetNewsArticleByStatus")]
        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByStatusAsync(Status status)
        {
            return await _newsArticleService.GetNewsArticleByStatus(status);
        }   
    }
}
