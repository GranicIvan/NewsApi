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
    public class UnitOfWork : IDisposable
    {
        private DataContext context;
        private NewsArticleRepo newsArticleRepository;
        private CategoryRepo categoryReposotpry;
        private TagRepo tagReposotpry;
       

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public NewsArticleRepo NewsArticleRepository
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

        public CategoryRepo CategoryRepository
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

        public TagRepo TagRepository
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

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
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
