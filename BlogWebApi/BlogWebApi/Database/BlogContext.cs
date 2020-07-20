﻿using BlogWebApi.Models;
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
    }
}
