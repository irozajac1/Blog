using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Models.Response
{
    public class MultipleBlogsResponse
    {
        public List<BlogPost>MultipleBlogs { get; set; }
        public int NumberOfBlogs { get; set; }
    }
}
