using BlogWebApi.Database;
using BlogWebApi.Interface;
using BlogWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogWebApi.Repository
{
    public class BlogPostRepository<T> : IBlogPostRepository<T> where T : class, new()
    {

        private readonly BlogContext context;
        //private readonly DbSet entities;

        public BlogPostRepository(BlogContext context)
        {
            this.context = context;
            //this.entities = entities;
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
            try
            {
                return context.Set<T>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public virtual IQueryable<T> IncludeAll()
        {
            var query = context.Set<T>().AsQueryable();
            foreach (var property in context.Model.FindEntityType(typeof(T)).GetNavigations())
                query = query.Include(property.Name);
            var x = query;
            return x;
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity must not be null");
            }

            try
            {
                 context.Add(entity);
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
            //if (entity == null) throw new ArgumentNullException("entity");

            //entities.Add(entity);
            //context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($" Entity must not be null");
            }

            try
            {
                context.Update(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
            //if (entity == null) throw new ArgumentNullException("entity");

            //context.Set<T>().Attach(entity);
            //context.Entry(entity).State = EntityState.Modified;
            //context.SaveChanges();
        }
    }
}
