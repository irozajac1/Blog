using BlogWebApi.Interface;
using BlogWebApi.Models;
using BlogWebApi.Models.Request;
using BlogWebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Services
{
    public class BlogService : IBlogService
    {
        public void DeleteBlogPost(BlogPost blog)
        {
            throw new NotImplementedException();
        }

        public MultipleBlogsResponse GetBlogPostByTag(string tagName)
        {
            throw new NotImplementedException();
        }

        public BlogPost GetBlogPotBySlug(Guid id)
        {
            throw new NotImplementedException();
        }

        public BlogPost SendBlogPost(BlogRequest blog)
        {
            var newBlog = new BlogPost
            {
                Title = blog.Title,
                Description = blog.Description,
                Body = blog.Body,
            };

            return newBlog;
        }

        public BlogPost UpdateBlogPost(BlogRequest blog)
        {
            throw new NotImplementedException();
        }
    }
}
