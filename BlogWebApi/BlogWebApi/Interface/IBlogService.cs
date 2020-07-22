using BlogWebApi.Models;
using BlogWebApi.Models.Request;
using BlogWebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Interface
{
    public interface IBlogService
    {
        BlogPost GetBlogPotBySlug(Guid id);
        MultipleBlogsResponse GetBlogPostByTag(string tagName);
        BlogPost GetRecentBlog();
        BlogPost SendBlogPost(BlogRequest blog);
        BlogPost UpdateBlogPost(BlogRequest blog);
        void DeleteBlogPost(Guid blogId);

    }
}
