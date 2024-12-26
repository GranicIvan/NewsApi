using Microsoft.EntityFrameworkCore;
using NewsApi.Data.Base;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.Enums;
using NewsApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Data.Repositories
{
    public class NewsArticleRepo : BaseRepository<NewsArticle>
    {
        DbContext _context;
        public NewsArticleRepo(DbContext context) : base(context)
        {
            _context = context;

        }

        public override async Task<IEnumerable<NewsArticle>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Category).Include(x => x.Tags).ToListAsync();
        }

        public async Task<NewsArticle> GetByNameAsync(String name)
        {
            //Exact match
            NewsArticle? newsArticle = await _dbSet.Where(x => x.Title == name).FirstOrDefaultAsync();
            if (newsArticle != null)
            {
                return newsArticle;
            }
            //Title contains query
            newsArticle = await _dbSet.Where(x => x.Title.Contains(name)).FirstOrDefaultAsync();
            if (newsArticle != null)
            {
                return newsArticle;
            }
            //query contains title
            return await _dbSet.Where(x => name.Contains(x.Title)).FirstOrDefaultAsync();

        }

        public async Task<int> DeleteAsync(int id)
        {

            return await _dbSet.Where(na => na.Id == id).ExecuteDeleteAsync();

        }

        public async Task<IEnumerable<NewsArticle>> GetActiveNewsArticlesAsync()
        {
            return await _dbSet.Where(na => na.Status == Model.Enums.Status.Active).ToListAsync();
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByStatus(Status status)
        {
            return await _dbSet.Where(na => na.Status == status).ToListAsync();
        }

        public async Task<Category> GetCategoryFromNewsArticle(int id)
        {
            return await _dbSet.Where(na => na.Id == id).Select(na => na.Category).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByCategory(int categoryId)
        {
            return await _dbSet.Where(na => na.Category.Id == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByTag(int tagId)
        {
            return await _dbSet.Where(na => na.Tags.Any(tag => tag.Id == tagId)).ToListAsync();
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsArticleSortByDate()
        {
            return await _dbSet.OrderByDescending(na => na.PublishedAt).ToListAsync();
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByStatusAndSort(Status status, bool sortDescending)
        {
            if (sortDescending)
            {
                return await _dbSet.Where(na => na.Status == status).OrderByDescending(na => na.PublishedAt).ToListAsync();
            }
            else
            {
                return await _dbSet.Where(na => na.Status == status).OrderBy(na => na.PublishedAt).ToListAsync();
            }

        }


        public async Task<IEnumerable<NewsArticle>> GetNAPagesByStatusAndSort(int pageIndex, int pageSize, Status status, bool sortDescending)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentException("Invalid page index");
            }

            if (pageSize < 1 || pageSize > 1000)
            {
                throw new ArgumentException("Invalid page size. Size can be between 1 and 1000");
            }

            var count = await _dbSet.Where(na => na.Status == status).CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            if (pageIndex > totalPages)
            {
                throw new ArgumentException("Invalid page index, no page with that index");
            }

            //var newsArticles = await _dbSet
            //.Where(na => na.Status == status)
            //.Skip((pageIndex - 1) * pageSize)
            //.Take(pageSize)
            //.ToListAsync();

            if (sortDescending)
            {
               return await _dbSet
                    .Where(na => na.Status == status)
                    .OrderByDescending(na => na.PublishedAt)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
               
            }
            else
            {
                return await _dbSet
                    .Where(na => na.Status == status)
                    .OrderBy(na => na.PublishedAt)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();               
            }
        }

        //public async Task<NewsArticle> GetByIdAsync(int id)
        //{
        //    throw await this.GetByIdAsync(id);
        //}

        //public async Task<NewsArticle> GetNewsArticleByIdAsync(int id)
        //{
        //    return await this.GetByIdAsync(id);
        //}
    }
}
