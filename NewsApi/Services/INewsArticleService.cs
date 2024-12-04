using NewsApi.Model.DTO;
using NewsApi.Model.Enums;
using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticleDTO>> GetAllNewsArticlesAsync();

        Task<NewsArticle> GetNewsArticleById(int id);

        Task<NewsArticleDTO?> AddAsync(NewsArticleDTO newsArticle);


        Task<NewsArticleDTO?> AddAsyncOptimal(NewsArticleDTO newsArticle);
        

        Task<NewsArticle> GetNewsArticleByName(string name);

        Task<int> DeleteNewsArticle(int id);

        Task<int> UpdateNewsArticle(NewsArticleDTO newsArticle);

        Task<IEnumerable<NewsArticle>> getActiveNewsArticlesAsync();

        Task<IEnumerable<NewsArticle>> GetNewsArticleByStatus(Status status);

        Task<Category> GetCategoryFromNewsArticle(int id);

        Task<IEnumerable<NewsArticle>> GetNewsArticleByCategory(int categoryId);


        Task<IEnumerable<NewsArticle>> GetNewsArticleByTag(int tagId);


        Task<IEnumerable<NewsArticle>> GetNewsArticleSortByDate();
    }
}
