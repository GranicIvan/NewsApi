﻿using NewsApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Model.DTO
{
    public class NewsArticleDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime PublishedAt { get; set; }


        public List<TagDTO>? Tags { get; set; }
        public CategoryDTO? Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
