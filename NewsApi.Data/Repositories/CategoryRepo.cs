﻿using Microsoft.EntityFrameworkCore;
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
            dc = (DataContext)context;

        }



    }
}
