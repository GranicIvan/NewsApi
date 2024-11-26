using Microsoft.EntityFrameworkCore;
using NewsApi.Data.Base;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Data.Repositories
{
    public class CategoryRepo : BaseRepository<Category>
    {

        private DataContext dc;


        public CategoryRepo(DbContext context) : base(context)
        {
            dc = (DataContext)context; // Potrebna je konverzija

        }

        public List<Category> GetAllCategories()
        {
            return this.GetAll().ToList();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await this.GetAllAsync();
        }



    }
}
