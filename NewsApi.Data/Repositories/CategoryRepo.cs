﻿using Microsoft.EntityFrameworkCore;
using NewsApi.Data.Base;
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
        public CategoryRepo(DbContext context) : base(context)
        {
        }
    }
}
