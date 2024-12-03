using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Data.Base
{
    public abstract class BaseRepository<T> where T : class
    {

        private readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
            
        }

        public virtual  void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);            
            
            return entity;
        }


        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }



        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        
    }
}
