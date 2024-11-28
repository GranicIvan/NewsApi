using Microsoft.EntityFrameworkCore;
using NewsApi.Data.Base;
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
        public NewsArticleRepo(DbContext context) : base(context)
        {


        }

        public override async Task<IEnumerable<NewsArticle>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Category).Include(x => x.Tags).ToListAsync();
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
