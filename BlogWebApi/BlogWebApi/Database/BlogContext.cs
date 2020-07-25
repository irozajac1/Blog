using BlogWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Database
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext>options):base(options)
        { }

        public DbSet<BlogPost>Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasData(

                new BlogPost {
                    Id = GenerateSeededGuid(1),
                    Title = "Augmented Reality iOS Application",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new BlogPost
                {
                    Id = GenerateSeededGuid(2),
                    Title = "Some random title",
                    Description = "Description about this title.",
                    Body = "Something interesting.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                });

           

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = GenerateSeededGuid(1),
                    TagName = "Android",
                    BlogPostId = GenerateSeededGuid(1)
                },
                new Tag
                {
                    Id = GenerateSeededGuid(2),
                    TagName = "IOS",
                    BlogPostId = GenerateSeededGuid(2)
                }
                ); 
        }

        private Guid GenerateSeededGuid(int seed)
        {
            var r = new Random(seed);
            var guid = new byte[16];
            r.NextBytes(guid);

            return new Guid(guid);
        }
    }
}
