﻿using NewsApi.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Model.Models
{
    public class NewsArticle
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public Status Status { get; set; }

        //public DateTime LastModifiedAt { get; set; }

        public List<Tag>? Tags { get; set; }   
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public string? ImageUrl { get; set; }

    }
}
