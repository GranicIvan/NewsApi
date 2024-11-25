using NewsApi.Data.Base;
using NewsApi.Data.Repositories;
using NewsApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Data.UnitOfWork
{
    internal class UnitOfWork : IDisposable
    {
        private DataContext context;
        private BaseRepository<NewsArticle> newsArticleRepository;
        private BaseRepository<Category> categoryReposotpry;
        private BaseRepository<Tag> tagReposotpry;
       

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public BaseRepository<NewsArticle> NewsArticleRepository
        {
            get
            {

                if (this.newsArticleRepository == null)
                {
                    this.newsArticleRepository = new NewsArticleRepo(context);
                }
                return newsArticleRepository;
            }
        }

        public BaseRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryReposotpry == null)
                {
                    this.categoryReposotpry = new CategoryRepo(context);
                }
                return categoryReposotpry;
            }
        }

        public BaseRepository<Tag> TagRepository
        {
            get
            {

                if (this.tagReposotpry == null)
                {
                    this.tagReposotpry = new TagRepo(context);
                }
                return tagReposotpry;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
