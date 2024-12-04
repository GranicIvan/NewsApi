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
        public Task<IEnumerable<NewsArticleDTO>> GetNewsArticlesAsync()
        {
            return _newsArticleService.GetAllNewsArticlesAsync();
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


        [HttpPost("AddNewsArticleOptimal")]
        public async Task<NewsArticleDTO?> AddNewsArticleAsyncOptimal(NewsArticleDTO newsArticle)
        {
            return await _newsArticleService.AddAsyncOptimal(newsArticle);
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

        

        [HttpGet("GetNewsArticleByStatus")]
        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByStatusAsync(Status status)
        {
            return await _newsArticleService.GetNewsArticleByStatus(status);
        }

        [HttpGet("GetCategoryFromNewsArticle")]
        public async Task<Category> GetCategoryFromNewsArticleAsync(int id)
        {
            return await _newsArticleService.GetCategoryFromNewsArticle(id);
        }

        //[HttpGet("GetCategoryFromNewsArticle")]
        //public async Task<Category> GetCategoryFromNewsArticleAsync2(Status status = Status.Active , bool ascending = true)
        //{
        //    return await _newsArticleService.GetCategoryFromNewsArticle(id);
        //}

        [HttpGet("GetNewsArticleByCategory")]
        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByCategoryAsync(int categoryId)
        {
            return await _newsArticleService.GetNewsArticleByCategory(categoryId);
        }

        [HttpGet("GetNewsArticleByTag")]
        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByTagAsync(int tagId)
        {
            return await _newsArticleService.GetNewsArticleByTag(tagId);
        }

        [HttpGet("GetNewsArticleSortByDate")]
        public async Task<IEnumerable<NewsArticle>> GetNewsArticleSortByDateAsync()
        {
            return await _newsArticleService.GetNewsArticleSortByDate();
        }

    }
}
