using NewsApi.Data.UnitOfWork;
using NewsApi.Model.Models;

namespace NewsApi.Services.Implementations
{
    public class NewsArticleService : INewsArticleService
    {

        private UnitOfWork unitOfWork;

        public NewsArticleService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<NewsArticle>> getAllNewsArticlesAsync()
        {
            return unitOfWork.NewsArticleRepository.GetAllAsync();
        }

        public Task<NewsArticle> GetNewsArticleById(int id)
        {
            return unitOfWork.NewsArticleRepository.GetByIdAsync(id);
        }
    }
}
