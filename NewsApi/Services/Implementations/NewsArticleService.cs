using NewsApi.Data.UnitOfWork;
using NewsApi.Model.Models;

namespace NewsApi.Services.Implementations
{
    public class NewsArticleService : INewsArticleService
    {

        private UnitOfWork _unitOfWork;

        public NewsArticleService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NewsArticle> AddAsync(NewsArticle newsArticle)
        {
            try
            {
                //newsArticle.Category = _unitOfWork.CategoryRepository.GetById( newsArticle.Category.Id );
                //Sta raditi ako kategorija ne postoji


                await _unitOfWork.NewsArticleRepository.AddAsync(newsArticle);
                _unitOfWork.Save();
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Adding NewsArticle faild. {ex.Message}");
                newsArticle = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding NewsArticle faild. {ex.Message}");
                newsArticle = null;
            }

            return newsArticle;

        }

        public Task<IEnumerable<NewsArticle>> getAllNewsArticlesAsync()
        {
            return _unitOfWork.NewsArticleRepository.GetAllAsync();
        }

        public Task<NewsArticle> GetNewsArticleById(int id)
        {
            return _unitOfWork.NewsArticleRepository.GetByIdAsync(id);
        }
    }
}
