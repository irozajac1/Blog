using BlogWebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Repository
{
    public class BlogPostRepository<T> : IBlogPostRepository<T> where T : class
    {
    }
}
