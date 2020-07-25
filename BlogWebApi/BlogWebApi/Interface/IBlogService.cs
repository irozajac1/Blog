using BlogWebApi.Models;
using BlogWebApi.Models.Request;
using BlogWebApi.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Interface
{
    public interface IBlogService
    {
        Task<BlogPost> GetBlogPostById(Guid id);
        Task<MultipleBlogsResponse> GetBlogPostByTag(string tagName);
        Task<BlogPost> GetRecentBlog();
        Task<BlogPost> SendBlogPost(BlogRequest blog);
        Task<BlogPost> UpdateBlogPost(BlogRequest blog, Guid id);
        void DeleteBlogPost(Guid blogId);
        List<Tag> TagsList();

    }
}
