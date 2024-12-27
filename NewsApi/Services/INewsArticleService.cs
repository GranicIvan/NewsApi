using NewsApi.Model.DTO;
using NewsApi.Model.Enums;
using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticleDTO>> GetAllNewsArticlesAsync();

        Task<NewsArticleDTO> GetNewsArticleById(int id);

        Task<NewsArticleDTO?> AddAsync(NewsArticleDTO newsArticle);        

        Task<NewsArticle> GetNewsArticleByName(string name);


        Task<int> UpdateNewsArticle(NewsArticleDTO newsArticle);

        Task<IEnumerable<NewsArticle>> GetActiveNewsArticlesAsync();

        Task<IEnumerable<NewsArticle>> GetNewsArticleByStatus(Status status);

        Task<Category> GetCategoryFromNewsArticle(int id);

        Task<IEnumerable<NewsArticle>> GetNewsArticleByCategory(int categoryId);


        Task<IEnumerable<NewsArticle>> GetNewsArticleByTag(int tagId);

        Task<IEnumerable<NewsArticle>> GetNewsArticleSortByDate();

        Task<IEnumerable<NewsArticle>> GetNewsArticleByStatusAndSort(Status status, bool sortDescending);

        Task<IEnumerable<NewsArticleDTO>> GetNAPagesByStatusAndSort(int pageIndex, int pageSize, Status status, bool sortDescending);
        

    }
}
