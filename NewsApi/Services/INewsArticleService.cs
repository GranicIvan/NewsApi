using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> getAllNewsArticlesAsync();

        Task<NewsArticle> GetNewsArticleById(int id);

        Task<NewsArticle?> AddAsync(NewsArticle newsArticle);
    }
}
