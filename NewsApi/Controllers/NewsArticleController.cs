using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.DTO;
using NewsApi.Model.Enums;
using NewsApi.Model.Models;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NewsArticleController : ControllerBase
    {
        private readonly ILogger<NewsArticleController> _logger;
        private readonly INewsArticleService _newsArticleService;

        public NewsArticleController(ILogger<NewsArticleController> logger, DataContext dataContext, INewsArticleService newsArticleService)
        {
            _logger = logger;
            _newsArticleService = newsArticleService;
        }


        [HttpGet("GetAllNewsArticles")]
        public async Task<IEnumerable<NewsArticleDTO>> GetNewsArticlesAsync()
        {
            return await _newsArticleService.GetAllNewsArticlesAsync();
        }

        [HttpGet("GetActiveNewsArticles")]
        public async Task<IEnumerable<NewsArticle>> GetActiveNewsArticlesAsync()
        {
            return await _newsArticleService.GetActiveNewsArticlesAsync();
        }

        [HttpGet("GetNewsArticleById")]
        public async Task<NewsArticleDTO> GetNewsArticleByIdAsync(int id)
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

        [HttpGet("GetNewsArticleByStatusAndSort")]
        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByStatusAndSortAsync(Status status = Status.Active, bool sortDescending = true)
        {
            return await _newsArticleService.GetNewsArticleByStatusAndSort(status, sortDescending);
        }

        [HttpGet("GetNAPagesByStatusAndSort")]
        public async Task<IEnumerable<NewsArticleDTO>> GetNAPagesByStatusAndSortAsync(int pageIndex, int pageSize, Status status = Status.Active, bool sortDescending = true)
        {
            return await _newsArticleService.GetNAPagesByStatusAndSort(pageIndex, pageSize, status, sortDescending);
        }



    }
}
