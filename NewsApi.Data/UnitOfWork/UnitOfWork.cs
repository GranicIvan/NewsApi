using Microsoft.Extensions.Caching.Memory;
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
        private readonly DataContext _context;

        private NewsArticleRepo _newsArticleRepository;
        private CategoryRepo _categoryRepository;
        private TagRepo _tagRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            
        }

        public NewsArticleRepo NewsArticleRepository
        {
            get
            {
                if (_newsArticleRepository == null)
                {
                    _newsArticleRepository = new NewsArticleRepo(_context);
                }
                return _newsArticleRepository;
            }
        }

        public CategoryRepo CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepo(_context);
                }
                return _categoryRepository;
            }
        }

        public TagRepo TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepo(_context);
                }
                return _tagRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
