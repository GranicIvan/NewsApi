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

            //public NewsArticle GetById<NewsArticle>()
            //{


            //}

        }
    }
}
