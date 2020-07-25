using BlogWebApi.Interface;
using BlogWebApi.Models;
using BlogWebApi.Models.Request;
using BlogWebApi.Models.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogPostRepository<BlogPost> blogRepository;
        private readonly IBlogPostRepository<Tag> tagRepository;

        public BlogService(IBlogPostRepository<BlogPost> repository, IBlogPostRepository<Tag> tagRepository)
        {
            blogRepository = repository;
            this.tagRepository = tagRepository;
        }

        public void DeleteBlogPost(Guid id)
        {
            var deletedBlog = blogRepository.GetById(id);
             blogRepository.Delete(deletedBlog);
        }


        public async Task<MultipleBlogsResponse> GetBlogPostByTag(string tagName)
        {
            List<BlogPost> blogList = blogRepository.IncludeAll().ToList();
            List<BlogPost> helpList = new List<BlogPost>();


            foreach(BlogPost blog in blogList)
            {
                foreach(Tag t in blog.TagList)
                {
                    if(t.TagName == tagName)
                    {
                        helpList.Add(blog);
                    }
                }
            }
            MultipleBlogsResponse m = new MultipleBlogsResponse
            {
                MultipleBlogs = helpList,
                NumberOfBlogs = helpList.Count

            };

            return m;

        }

        public async Task<BlogPost> GetBlogPostById(Guid id)
        {
            var blog = await blogRepository.IncludeAll().FirstOrDefaultAsync(x=>x.Id==id);
            return blog;
        }

        public async Task<BlogPost> GetRecentBlog()
        {
            BlogPost recentBlog = await blogRepository.IncludeAll().OrderByDescending(x=>x.CreatedAt).FirstAsync();
            
            return recentBlog;
        }

        public async Task<BlogPost> SendBlogPost(BlogRequest blog)
        {
            List<string> tags = blog.TagList;
            var tag = new Tag();

            List<Tag> list = new List<Tag>();
            foreach(String s in tags)
            {
                tag = new Tag
                {
                    TagName = s
                };
                list.Add(tag);
            }
            //tagRepository.Insert(tag);

            var newBlog = new BlogPost
            {
                Title = blog.Title,
                Description = blog.Description,
                Body = blog.Body,
                UpdatedAt = DateTime.Now,
                TagList = list
            };

            blogRepository.Insert(newBlog);
            return  newBlog;
        }

        public List<Tag> TagsList()
        {
            return  tagRepository.GetAll().ToList();
        }

        public async Task<BlogPost> UpdateBlogPost(BlogRequest blog, Guid id)
        {

            var updatedBlog = blogRepository.GetById(id);
            List<Tag> updatedTagList = tagRepository.FindByCondition(x => x.BlogPostId == id);

            //List<string> tagNames = blog.TagList;


            //foreach(Tag t in updatedTagList)
            //{

            //}

            List<string> tags = blog.TagList;
            var tag = new Tag();

            List<Tag> list = new List<Tag>();
            foreach (String s in tags)
            {
                tag = new Tag
                {
                    TagName = s
                };
                list.Add(tag);
            }
            updatedTagList = list;

            updatedBlog.Title = blog.Title;
            updatedBlog.Description = blog.Description;
            updatedBlog.Body = blog.Body;
            updatedBlog.UpdatedAt = DateTime.Now;
            updatedBlog.TagList = updatedTagList;


            blogRepository.Update(updatedBlog);
            return updatedBlog;

        }
    }
}
