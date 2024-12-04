using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.DTO;
using NewsApi.Model.Enums;
using NewsApi.Model.Models;

namespace NewsApi.Services.Implementations
{
    public class NewsArticleService : INewsArticleService
    {

        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public NewsArticleService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NewsArticleDTO> AddAsync(NewsArticleDTO newsArticleDTO)
        {
            NewsArticle? newsArticle = null;
            try
            {

                newsArticle = _mapper.Map<NewsArticle>(newsArticleDTO);



                //Mapper vidi kako da defisinsem kad koji da koristi
                newsArticle.Category = null; // Ensure the Category object is not tracked
                newsArticle.Tags = null;


                if (newsArticleDTO.Tags?.Any() ?? false)
                {
                    newsArticle.Tags = await _unitOfWork.TagRepository.GetAllTagsByID(newsArticleDTO.Tags.Select(t => t.Id));
                }

                await _unitOfWork.NewsArticleRepository.AddAsync(newsArticle);
                await _unitOfWork.SaveAsync();

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

            return _mapper.Map<NewsArticleDTO>(newsArticle);

        }

        public async Task<IEnumerable<NewsArticleDTO>> GetAllNewsArticlesAsync()
        {
             var news = await _unitOfWork.NewsArticleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<NewsArticleDTO>>(news);
        }

        public Task<NewsArticle> GetNewsArticleById(int id)
        {
            return _unitOfWork.NewsArticleRepository.GetByIdAsync(id);
        }

        public Task<NewsArticle> GetNewsArticleByName(string name)
        {
            return _unitOfWork.NewsArticleRepository.GetByNameAsync(name);
        }


        public async Task<int> UpdateNewsArticle(NewsArticleDTO newsArticleDTO)
        {
            NewsArticle newsArticle = _mapper.Map<NewsArticle>(newsArticleDTO);


            if (newsArticle.Category != null)
            {
                newsArticle.Category =  await _unitOfWork.CategoryRepository.GetByIdAsync(newsArticle.Category.Id) ;
            }

            if (newsArticleDTO.Tags?.Any() ?? false)
            {
                newsArticle.Tags = await _unitOfWork.TagRepository.GetAllTagsByID(newsArticleDTO.Tags.Select(t => t.Id));
            }

            _unitOfWork.NewsArticleRepository.Update(_mapper.Map<NewsArticle>(newsArticle));
            return await _unitOfWork.SaveAsync(); 
        }

        public Task<IEnumerable<NewsArticle>> GetActiveNewsArticlesAsync()
        {
            return _unitOfWork.NewsArticleRepository.GetActiveNewsArticlesAsync();
        }

        public Task<IEnumerable<NewsArticle>> GetNewsArticleByStatus(Status status)
        {
            return _unitOfWork.NewsArticleRepository.GetNewsArticleByStatus(status);
        }

        

        public async Task<Category> GetCategoryFromNewsArticle(int id)
        {
           return await _unitOfWork.NewsArticleRepository.GetCategoryFromNewsArticle(id);
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByCategory(int categoryId)
        {
            return await _unitOfWork.NewsArticleRepository.GetNewsArticleByCategory(categoryId);
        }

        public Task<IEnumerable<NewsArticle>> GetNewsArticleByTag(int tagId)
        {
            return _unitOfWork.NewsArticleRepository.GetNewsArticleByTag(tagId);
        }

        public Task<IEnumerable<NewsArticle>> GetNewsArticleSortByDate()
        {
            return _unitOfWork.NewsArticleRepository.GetNewsArticleSortByDate();
        }
    }
}
