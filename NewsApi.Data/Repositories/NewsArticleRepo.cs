using Microsoft.EntityFrameworkCore;
using NewsApi.Data.Base;
using NewsApi.Model.Enums;
using NewsApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
           return await _dbSet.Where(x => x.Title == name).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {

            return await _dbSet.Where( na => na.Id == id).ExecuteDeleteAsync();

        }

        public async Task<IEnumerable<NewsArticle>> GetActiveNewsArticlesAsync()
        {
            return await _dbSet.Where(na => na.Status == Model.Enums.Status.Active).ToListAsync();
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsArticleByStatus(Status status)
        {
            return await _dbSet.Where(na => na.Status == status).ToListAsync();
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
