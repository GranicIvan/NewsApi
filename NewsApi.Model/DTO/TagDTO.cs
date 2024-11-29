using NewsApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Model.DTO
{
    public class TagDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<NewsArticle>? Articles { get; set; }

    }
}
