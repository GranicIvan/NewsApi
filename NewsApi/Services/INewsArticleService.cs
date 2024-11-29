using NewsApi.Model.DTO;
using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> getAllNewsArticlesAsync();

        Task<NewsArticle> GetNewsArticleById(int id);

        Task<NewsArticleDTO?> AddAsync(NewsArticleDTO newsArticle);
    }
}
