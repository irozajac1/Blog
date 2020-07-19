using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Models
{
    public class BlogPost
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<string>TagList { get; set; }
        public DateTime CreatedAt { get; set; }
        public BlogPost()
        {
            CreatedAt = DateTime.Now;
        }
        public DateTime UpdatedAt { get; set; }
    }
}
