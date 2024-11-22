using Microsoft.EntityFrameworkCore;
using NewsApi.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Data.Repositories
{
    internal class Category : BaseRepository<Category>
    {
        public Category(DbContext context) : base(context)
        {
        }
    }
}
