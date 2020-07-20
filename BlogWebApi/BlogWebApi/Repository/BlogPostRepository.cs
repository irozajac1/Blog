using BlogWebApi.Database;
using BlogWebApi.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogWebApi.Repository
{
    public class BlogPostRepository<T> : IBlogPostRepository<T> where T : class
    {
        protected readonly BlogContext context;
        private DbSet<T> entities;

        public BlogPostRepository(BlogContext context, DbSet<T> entities)
        {
            this.context = context;
            this.entities = entities;
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            this.context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public List<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
